using Domain.Interfaces.ICategories;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceCategory : IServiceCategory
    {
        private readonly InterfaceCategory _interfaceCategory;

        public ServiceCategory(InterfaceCategory interfaceCategory)
        {
            _interfaceCategory = interfaceCategory;
        }

        public async Task AddCategory(Category category)
        {
            var isValid = category.ValidateStringProperty(category.Name, "Name");
            if (isValid)
            {
                await _interfaceCategory.Add(category);
            }
        }

        public async Task UpdateCategory(Category category)
        {
            var isValid = category.ValidateStringProperty(category.Name, "Name");
            if (isValid)
            {
                await _interfaceCategory.Update(category);
            }
        }
    }
}
