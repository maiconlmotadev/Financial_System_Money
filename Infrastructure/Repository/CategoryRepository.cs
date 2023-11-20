using Domain.Interfaces.ICategories;
using Entities.Entities;
using Infrastructure.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CategoryRepository : GenericsRepository<Category>, InterfaceCategory
    {
        public Task<IList<Category>> UserCategoryList(string emailUser)
        {
            throw new NotImplementedException();
        }
    }
}
