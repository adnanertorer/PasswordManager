using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Persistence;

public class PasswordManagerDbContext : DbContext
{
    public PasswordManagerDbContext(DbContextOptions options) : base(options)
    {
    }

    protected PasswordManagerDbContext()
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<UserAccount> UsersAccounts { get; set; }
    public DbSet<UserNote> UserNotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
    }
}
