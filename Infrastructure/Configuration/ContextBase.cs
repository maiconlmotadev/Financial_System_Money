using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<FinancialSystem> FinancialSystem { get; set; }
        public DbSet<FinancialSystemUser> FinancialSystemUser { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Expense> Expense { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        // Colocaremos a string de conexão aqui (Infrastruture) para ficar compilado (protegido)
        // Podendo ficar também no projeto web (outra opção)

        public string GetConnectionString()
        {
            return "Data Source=WINMACBOOK\\SQLEXPRESS;Initial Catalog=dbFinancialSystem; User ID=sa; Password=0000;";
        }
    }
}
