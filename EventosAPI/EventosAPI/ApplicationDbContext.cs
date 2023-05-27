using EventosAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EventosAPI
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento_Usuario>()
                .HasOne(e => e.Evento)
                .WithMany(ea => ea.Evento_Usuarios)
                .HasForeignKey(ei => ei.EventoId);

            modelBuilder.Entity<Evento_Usuario>()
                .HasOne(e => e.Usuario)
                .WithMany(ea => ea.Evento_Usuarios)
                .HasForeignKey(ei => ei.UsuarioId);
        }
        //Tablas para modelos
        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento_Usuario> Eventos_Usuarios { get; set; }       
        public DbSet<Organizador> Organizadores { get; set; }
    }
}
