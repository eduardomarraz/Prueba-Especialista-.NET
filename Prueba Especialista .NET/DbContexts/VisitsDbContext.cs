using Prueba_Especialista_.NET.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace Prueba_Especialista_.NET.DbContexts
{
    public class VisitsDbContext : DbContext
    {
        public VisitsDbContext(DbContextOptions<VisitsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Commercial> Commercials { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones adicionales si es necesario
        }
    }
}
