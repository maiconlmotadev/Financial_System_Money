using Domain.Interfaces.IFinancialSystem;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class FinancialSystemRepository : GenericsRepository<FinancialSystem>, InterfaceFinancialSystem
    {
        private readonly DbContextOptions<ContextBase> _OptoinBuilder;

        public FinancialSystemRepository()
        {
            _OptoinBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<FinancialSystem>> FinancialSystemsUserList(string emailUser)
        {
            using (var db = new ContextBase(_OptoinBuilder))
            {
                return await
                    (from fs in db.FinancialSystem
                     join fsu in db.FinancialSystemUser on fs.Id equals fsu.SystemId
                     where fsu.UserEmail.Equals(emailUser) 
                     select fs).AsNoTracking().ToListAsync();
            }
        }
    }
}
