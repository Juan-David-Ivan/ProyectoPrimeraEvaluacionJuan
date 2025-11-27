using Microsoft.EntityFrameworkCore;
using ProyectoPrimeraEvaluacionJuan.Models;

namespace ProyectoPrimeraEvaluacionJuan.Data;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=usuarios.db");
    }
}