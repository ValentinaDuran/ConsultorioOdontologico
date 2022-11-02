using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultorioOdontologico;

namespace ConsultorioOdontologico.BD.Data.Entidades
{
    public class Paciente 
    {
        // un paciente tiene una obra social RELACION 1:MUCHOS
        public int Id { get; set; } 

        [Required(ErrorMessage ="Campo obligatorio")]
        public string NombreObraSocial { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int DNI { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public long Teléfono { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Mail { get; set; }

        //Relacion con tabla obra social

        //public int ObraSocialId { get; set; }//id+propiedad siempre unidos y en ese orden id arriba y propiedad abajo
        //public ObraSocial ObraSocial { get; set; }//propiedad de tipo obrasocial. relacion 1=1

    }
}
