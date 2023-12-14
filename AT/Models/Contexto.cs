using AT.Services;
using Microsoft.EntityFrameworkCore;
using AT.Services;

namespace AT.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<AT.Models.Time> Time { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=localhost\MSSQLSERVER01;Initial Catalog=master;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Jogador jogador = new Jogador();
            Time time = new Time();
             modelBuilder.Entity<Jogador>().HasData(
                new Jogador
                {
                    Id = 1,
                    Nome = "Vegetti",
                    dataCriacao = DateTime.Now
                },
                new Jogador
                {
                    Id = 2,
                    Nome = "Ribamar",
                    dataCriacao = DateTime.Now
                }
                );
            modelBuilder.Entity<Time>().HasData(
                new Time
                {
                    Id = 1,
                    Nome = "Vasco",
                    dataCriacao = DateTime.Now
                },
                new Time
                {
                    Id = 2,
                    Nome = "Atlético MG",
                    dataCriacao = DateTime.Now
                }
            );
        }
    }
}
