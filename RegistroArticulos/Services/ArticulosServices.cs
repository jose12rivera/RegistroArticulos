using Microsoft.EntityFrameworkCore;
using RegistroArticulos.DAL;
using RegistroArticulos.Models;
using System.Linq.Expressions;

namespace RegistroArticulos.Services
{
    public class ArticulosServices
    {
        private readonly Contexto _contexto;

        public ArticulosServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task <bool>Existe(int ArticuloId,string nombre)
        {
            return await _contexto.Articulos.AnyAsync(a=>a.ArticuloId !=ArticuloId &&a.Nombre.Equals(nombre));
        }

        private async Task<bool>Insertar(Articulos articulo)
        {
            _contexto.Articulos.Add(articulo);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Articulos articulo)
        {
            _contexto.Articulos.Update(articulo);
          var modicicado= await _contexto.SaveChangesAsync() > 0;
            _contexto.Entry(articulo).State = EntityState.Detached;
            return modicicado;
        }

        public async Task<bool>Guardar(Articulos articulo)
        {
            if(!await Existe(articulo.ArticuloId, articulo.Nombre))
            {
                return await Insertar(articulo);
            }
            else
            {
                return await Modificar(articulo);
            }
        }

        public async Task<bool>Eliminar(int id)
        {
            var eliminado = await _contexto.Articulos.Where(a => a.ArticuloId == id).ExecuteDeleteAsync();
            return eliminado > 0;
        }
        public async Task<Articulos?>Buscar(int id)
        {
            return await _contexto.Articulos.AsNoTracking().FirstOrDefaultAsync(a=>a.ArticuloId==id);

        }

        public async Task<List<Articulos>>Listar(Expression<Func<Articulos, bool>> Criterio)
        {
            return await _contexto.Articulos.Where(Criterio).ToListAsync(); 
        }
    }
}
