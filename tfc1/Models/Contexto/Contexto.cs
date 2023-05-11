using Microsoft.EntityFrameworkCore;

namespace tfc1.Models.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            //public DbSet<Usuarios> Usuarios { get; set; }
            //public DbSet<Eventos> Eventos { get; set; }
            //public DbSet<Participantes> Participantes { get; set; }

        }

    }
}
