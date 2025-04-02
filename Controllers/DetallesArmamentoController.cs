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
    public interface IDetallesArmamentoController
    {
        Task<List<DetallesArmamento>> GetDetallesArmamentos();
        Task<DetallesArmamento> GetDetallesArmamento(int Id);
        Task<List<Armamento>> GetArmamentos();
        Task<int> Insert(DetallesArmamento Entidad);
        Task<bool> Update(DetallesArmamento Entidad);
        Task<bool> Delete(DetallesArmamento Entidad);
    }
    public class DetallesArmamentoController: IDetallesArmamentoController
    {
        readonly IDbContextFactory<dbContext> db;

        public DetallesArmamentoController(IDbContextFactory<dbContext> dbContext)
        {
            db = dbContext;
        }
        public async Task<List<DetallesArmamento>> GetDetallesArmamentos()
        {
            using var conexion = db.CreateDbContext();
            return await conexion.DetallesArmamentos.Where(b => b.Activo).ToListAsync();
        }
        public async Task<DetallesArmamento> GetDetallesArmamento(int Id)
        {
            using var conexion = db.CreateDbContext();
            return await conexion.DetallesArmamentos.FindAsync(Id) ?? new();
        }
        public async Task<List<Armamento>> GetArmamentos()
        {
            using var conexion = db.CreateDbContext();
            return await conexion.Armamento.ToListAsync();
        }
        public async Task<int> Insert(DetallesArmamento Entidad)
        {
            using var conexion = db.CreateDbContext();
            Entidad.Activo = true;
            conexion.DetallesArmamentos.Add(Entidad);
            var result = await conexion.SaveChangesAsync();
            return result;
        }
        public async Task<bool> Update(DetallesArmamento Entidad)
        {
            using var Conexion = db.CreateDbContext();
            var Registro = await Conexion.DetallesArmamentos.Where(a => a.IdDetalle == Entidad.IdDetalle).SingleOrDefaultAsync();
            if (Registro != null)
            {
                Registro.NPiston = Entidad.NPiston;
                Registro.NCierre = Entidad.NCierre;
                Registro.Cargador = Entidad.Cargador;
                Registro.IdArma = Entidad.IdArma;
                return await Conexion.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<bool> Delete(DetallesArmamento Entidad)
        {
            using var Conexion = db.CreateDbContext();
            var Registro = await Conexion.DetallesArmamentos.Where(a => a.IdDetalle == Entidad.IdDetalle).SingleOrDefaultAsync();
            if (Registro != null)
            {
                Registro.Activo = false;
                return await Conexion.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
