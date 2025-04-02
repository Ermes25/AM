using Microsoft.EntityFrameworkCore;
using AM.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AM.Controllers
{
    public interface IMunicionController
    {

    }
    public class MunicionController : IMunicionController
    {
        readonly IDbContextFactory<dbContext> db;
        public MunicionController(IDbContextFactory<dbContext> dbContextFactory)
        {
            db = dbContextFactory;
        }
        public async Task<List<Municion>> Get()
        {
            using var context = db.CreateDbContext();
            return await context.Municion.Where(a => a.Activo).ToListAsync();
        }
        public async Task<int> Insert(Municion Entidad)
        {
            using var Conexion = db.CreateDbContext();
            Conexion.Municion.Add(Entidad);
            await Conexion.SaveChangesAsync();
            return Entidad.IdMunicion;
        }
        public async Task<bool> Update(Municion Entidad)
        {
            using var Conexion = db.CreateDbContext();
            var Registro = await Conexion.Municion.Where(a => a.IdMunicion == Entidad.IdMunicion).SingleOrDefaultAsync();
            if (Registro != null)
            {
                Registro.Tipo = Entidad.Tipo;
                Registro.Calibre = Entidad.Calibre;
                Registro.CantidadDisponible = Entidad.CantidadDisponible;
                return await Conexion.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<bool> Delete(Municion Entidad)
        {
            using var Conexion = db.CreateDbContext();
            var Registro = await Conexion.Municion.Where(a => a.IdMunicion == Entidad.IdMunicion).SingleOrDefaultAsync();
            if (Registro != null)
            {
                Registro.Activo = false;
                return await Conexion.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
