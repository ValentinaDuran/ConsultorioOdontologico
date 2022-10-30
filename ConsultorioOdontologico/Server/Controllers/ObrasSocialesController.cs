using CONSULTORIODONTOLOGICO.BD.Data;
using CONSULTORIODONTOLOGICO.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CONSULTORIODONTOLOGICO.Server.Controllers
{
    [ApiController]
    [Route("api/ObrasSociales")]
    public class ObrasSocialesController : ControllerBase
    {
        private readonly DBContext context;

        //private readonly DBContext context;
        public ObrasSocialesController(DBContext Context)
        {
            this.context = Context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(ObraSocial obrasocial)
        {
            try
            {
                context.ObrasSociales.Add(obrasocial);
                await context.SaveChangesAsync();
                return obrasocial.Id;

            }
            catch (Exception o)
            {

                return BadRequest(o.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ObraSocial>>> Get()
        {
            return await context.ObrasSociales.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ObraSocial>> Get(int id)
        {
            var obrasosical = await context.ObrasSociales.Where(o => o.Id == id).FirstOrDefaultAsync();
            if (obrasosical == null)
            {
                return NotFound($"No existe la obra social de Id={id}");
            }
            return obrasosical;
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var amnis = context.ObrasSociales.Where(x => x.Id == id).FirstOrDefault();
            if (amnis == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.ObrasSociales.Remove(amnis);
                context.SaveChanges();
                return Ok($"El registro de {amnis.NombreObrasocial} ha sido eliminado");
            }
            catch (Exception o)
            {
                return BadRequest($"No se logro eliminar por:{o.Message}");

            }
        }
        //[HttpPut("{id:int}")]
        //public ActionResult Put(int id, [FromBody] ObraSocial obrasocial)
        //{
        //    if (id != obrasocial.Id)
        //    {
        //        return BadRequest("Datos incorrectos");
        //    }
        //    var amnis = context.ObrasSociales.Where(o => o.Id == id).FirstOrDefault();
        //    if (amnis == null)
        //    {
        //        return NotFound("No exixte el paciente para modificar");
        //    }
        //    amnis.Nombre = paciente.Nombre;


     
        



    }




}


