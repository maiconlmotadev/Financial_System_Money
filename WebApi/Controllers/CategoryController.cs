using Domain.Interfaces.ICategories;
using Domain.Interfaces.IServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly InterfaceCategory _InterfaceCategory;
        private readonly IServiceCategory _IServiceCategory;
        public CategoryController(InterfaceCategory InterfaceCategory, IServiceCategory IServiceCategory)
        {
            _InterfaceCategory = InterfaceCategory;
            _IServiceCategory = IServiceCategory;
        }

        [HttpGet("/api/ListUserCategories")]
        [Produces("application/json")]
        public async Task<object> ListUserCategories(string emailUser)
        {
            return _InterfaceCategory.ListUserCategories(emailUser);
        }

        [HttpPost("/api/AddCategory")]
        [Produces("application/json")]
        public async Task<object> AddCategory(Category category)
        {
            await _IServiceCategory.AddCategory(category);
            return category;
        }

        [HttpPut("/api/UpdateCategory")]
        [Produces("application/json")]
        public async Task<object> UpdateCategory(Category category)
        {
            await _IServiceCategory.UpdateCategory(category);
            return category;
        }

        [HttpGet("/api/GetCategory")]
        [Produces("application/json")]
        public async Task<object> GetCategory(int Id)
        {
            return await _InterfaceCategory.GetEntityById(Id);
        }

        [HttpDelete("/api/GetCategory")]
        [Produces("application/json")]
        public async Task<object> DeleteCategory(int Id)
        {
            try
            {
                var category = await _InterfaceCategory.GetEntityById(Id);
                await _InterfaceCategory.Delete(category);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
