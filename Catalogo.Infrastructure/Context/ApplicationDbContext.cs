using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Catalogo.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
            .Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
                "Server=localhost;DataBase=catalogoapidb;Uid=root;Pwd=",
                new MySqlServerVersion(new Version(9, 0, 1)) // Ajuste a versão do seu MySQL
            );
        }
    }
}
