using Domain.Interfaces.IFinancialSystemUser;
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
    public class FinancialSystemUserRepository : GenericsRepository<FinancialSystemUser>, InterfaceFinancialSystemUser
    {
        private readonly DbContextOptions<ContextBase> _OptoinBuilder;

        public FinancialSystemUserRepository()
        {
            _OptoinBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<FinancialSystemUser>> ListFinancialSystemsUsers(int systemId)
        {
            using (var db = new ContextBase(_OptoinBuilder))
            {
                return await
                    db.FinancialSystemUser
                    .Where(fs => fs.SystemId == systemId)
                    .AsNoTracking().ToListAsync();
            }
        }

        public async Task<FinancialSystemUser> GetUsersByEmail(string emailUser)
        {
            using (var db = new ContextBase(_OptoinBuilder))
            {
                return await
                    db.FinancialSystemUser.AsNoTracking().FirstOrDefaultAsync(x => x.UserEmail.Equals(emailUser));
            }
        }

        public async Task RemoveUsers(List<FinancialSystemUser> users)
        {
            using (var db = new ContextBase(_OptoinBuilder))
            {
                db.FinancialSystemUser
                .RemoveRange(users);

                await db.SaveChangesAsync();
            }
        }
    }
}
