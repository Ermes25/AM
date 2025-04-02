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

    public interface IArmamentoController
    {
        Task<List<Armamento>> Get();
        Task<int> Insert(Armamento Entidad);
        Task<bool> Update(Armamento Entidad);
        Task<bool> Delete(Armamento Entidad);
    }
    public class ArmamentoController : IArmamentoController
    {
        readonly IDbContextFactory<dbContext> db;
        public ArmamentoController(IDbContextFactory<dbContext> dbContextFactory)
        {
            db = dbContextFactory;
        }
        public async Task<List<Armamento>> Get()
        {
            using var context = db.CreateDbContext();
            return await context.Armamento.Where(a => a.Activo).ToListAsync();
        }
        public async Task<int> Insert(Armamento Entidad)
        {
            using var Conexion = db.CreateDbContext();
            Conexion.Armamento.Add(Entidad);
            await Conexion.SaveChangesAsync();
            return Entidad.IdArma;
        }
        public async Task<bool> Update(Armamento Entidad)
        {
            using var Conexion = db.CreateDbContext();
            var Registro = await Conexion.Armamento.Where(a => a.IdArma == Entidad.IdArma).SingleOrDefaultAsync();
            if (Registro != null)
            {
                Registro.Tipo = Entidad.Tipo;
                Registro.Año = Entidad.Año;
                Registro.Letra = Entidad.Letra;
                Registro.NSerie = Entidad.NSerie;
                return await Conexion.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<bool> Delete(Armamento Entidad)
        {
            using var Conexion = db.CreateDbContext();
            var Registro = await Conexion.Armamento.Where(a => a.IdArma == Entidad.IdArma).SingleOrDefaultAsync();
            if (Registro != null)
            {
                Registro.Activo = false;
                return await Conexion.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
