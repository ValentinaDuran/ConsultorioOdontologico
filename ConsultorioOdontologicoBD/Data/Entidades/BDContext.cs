using CONSULTORIODONTOLOGICO.BD.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.BD.Data.Entidades
{
    public class BDContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        //constructor: parandome arriba de BDContext y ctrl+., seleccionar opcion "generar constructor con options"
        //DbContextOptions "opcions" agarra los parámetros "options" de la 'base' heredada
        public DbSet<ObraSocial> ObrasSociales { get; set; }
        public BDContext(DbContextOptions options) : base(options)
        {
        }
    }
}
