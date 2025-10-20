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

    DbSet<User> Users { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<UserAccount> UsersAccount { get; set; }
    DbSet<UserNote> UserNotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
    }
}
