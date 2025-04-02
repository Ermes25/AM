using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AM.Controllers
{
    public class dbContext : DbContext
    {
        //TABLAS
        public virtual DbSet<Armamento> Armamento { get; set; }
        public virtual DbSet<Municion> Municion { get; set; }
        public virtual DbSet<DetallesArmamento> DetallesArmamentos { get; set; }

        // VISTAS
        public virtual DbSet<vDetallesArmamento> VDetallesArmamentos { get; set; }
        public dbContext(DbContextOptions<dbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
