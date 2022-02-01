using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProyectoMVC.Models.DBContext
{
    public class EmpleadosDbContext : DbContext
    {
        public DbSet<Trabajadores> Trabajador{ get; set; }
        public DbSet<TiposDeDocumentos> TipoIdentificacion { get; set; }
        public DbSet<Contratos> Contrato { get; set; }
    }
}