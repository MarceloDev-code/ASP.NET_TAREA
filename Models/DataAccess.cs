using Microsoft.EntityFrameworkCore;

namespace negamed.Models
{
    public class negamedContext : DbContext
    {
        public negamedContext(DbContextOptions<negamedContext> options)
        : base(options)
        {

        }
        public DbSet<booking> bookings {get; set;}
        public DbSet<paciente> pacientes {get; set;}
    }
}