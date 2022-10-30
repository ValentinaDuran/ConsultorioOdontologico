//using CONSULTORIODONTOLOGICO.BD.Data;
//using CONSULTORIODONTOLOGICO.BD.Data.Entidades;
using ConsultorioOdontologico.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CONSULTORIODONTOLOGICO.Server.Controllers
{
    [ApiController]
    [Route("api/Pacientes")]//ruta que permite acceder a lo recursos metodos
    public class PacientesController : ControllerBase
    {
        private readonly BDContext context;

        public PacientesController(BDContext Context)
        {
            this.context = Context;
        }
        [HttpGet]//[HttpGet] //metodo get es un metodo http /ActionResult= devuelve codigo de status
        public async Task<ActionResult<List<Paciente>>> Get() 
        {
            //return await context.Pacientes.ToListAsync();
            var resp = await context.Pacientes.ToListAsync();
            return resp;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Paciente>> Get(int id)
        {
            var paciente = await context.Pacientes.Where(o => o.Id == id).FirstOrDefaultAsync();
            if (paciente == null)
            {
                return NotFound($"No existe la obra social de Id={id}");
            }
            return paciente;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Paciente paciente)
        {
            try
            {
                context.Pacientes.Add(paciente);
                await context.SaveChangesAsync();
                return paciente.Id;

            }
            catch (Exception o)
            {

                return BadRequest(o.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody]Paciente paciente)
        {
            if(id!= paciente.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var amnis = context.Pacientes.Where(o => o.Id == id).FirstOrDefault();
            if(amnis == null)
            {
                return NotFound("No exixte el paciente para modificar");
            }
            amnis.Nombre = paciente.Nombre;
            amnis.Apellido = paciente.Apellido;
            amnis.Id = paciente.Id;
            amnis.NombreObraSocial = paciente.NombreObraSocial;
            amnis.DNI = paciente.DNI;
            amnis.Teléfono = paciente.Teléfono;
            amnis.Mail = paciente.Mail; 

            try
            {
                context.Pacientes.Update(amnis);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception o)
            {
                return BadRequest("No se logro actualizar datos");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var amnis = context.Pacientes.Where(x => x.Id == id).FirstOrDefault();
            if (amnis == null) 
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.Pacientes.Remove(amnis);
                context.SaveChanges();
                return Ok($"El registro de {amnis.NombreObraSocial} ha sido eliminado");
            }
            catch (Exception o)
            {
                return BadRequest($"No se logro eliminar por:{o.Message}");

            }
        }

    }
}
