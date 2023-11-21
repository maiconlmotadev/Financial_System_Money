using Domain.Interfaces.ICategories;
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
    public class CategoryRepository : GenericsRepository<Category>, InterfaceCategory
    {
        private readonly DbContextOptions<ContextBase> _OptoinBuilder;
        public CategoryRepository()
        {
            _OptoinBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Category>> UserCategoriesList(string emailUser)
        {
            using (var db = new ContextBase(_OptoinBuilder))
            {
                return await
                    (from fs in db.FinancialSystem
                     join c in db.Category on fs.Id equals c.SystemId
                     join fsu in db.FinancialSystemUser on fs.Id equals fsu.SystemId
                     where fsu.UserEmail.Equals(emailUser) && fsu.CurrentSystem
                     select c).AsNoTracking().ToListAsync();
            }
        }
    }
}
