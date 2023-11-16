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


    }
}
