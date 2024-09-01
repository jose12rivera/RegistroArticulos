using Microsoft.EntityFrameworkCore;
using RegistroArticulos.Models;

namespace RegistroArticulos.DAL
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto>options) 
        :base(options){ }

        public DbSet<Articulos> Articulos { get; set; }
    }
}
