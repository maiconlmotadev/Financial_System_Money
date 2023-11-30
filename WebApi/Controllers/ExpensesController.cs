using Domain.Interfaces.ICategories;
using Domain.Interfaces.IExpenses;
using Domain.Interfaces.IServices;
using Domain.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly InterfaceExpense _InterfaceExpense;
        private readonly IServiceExpense _IServiceExpense;
        public ExpensesController(InterfaceExpense InterfaceExpense, IServiceExpense IServiceExpense)
        {
            _InterfaceExpense = InterfaceExpense;
            _IServiceExpense = IServiceExpense;
        }

        [HttpGet("/api/ListUserExpenses")]
        [Produces("application/json")]
        public async Task<object> ListUserExpenses(string emailUser)
        {
            return _InterfaceExpense.ListUserExpenses(emailUser);
        }

        [HttpPost("/api/AddExpense")]
        [Produces("application/json")]
        public async Task<object> AddExpense(Expense expense)
        {
            await _IServiceExpense.AddExpense(expense);
            return expense;
        }

        [HttpPut("/api/UpdateExpense")]
        [Produces("application/json")]
        public async Task<object> UpdateExpense(Expense expense)
        {
            await _IServiceExpense.UpdateExpense(expense);
            return expense;
        }

        [HttpGet("/api/GetExpense")]
        [Produces("application/json")]
        public async Task<object> GetExpense(int Id)
        {
            return await _InterfaceExpense.GetEntityById(Id);
        }

        [HttpDelete("/api/GetExpense")]
        [Produces("application/json")]
        public async Task<object> DeleteExpense(int Id)
        {
            try
            {
                var category = await _InterfaceExpense.GetEntityById(Id);
                await _InterfaceExpense.Delete(category);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        [HttpGet("/api/LoadsGraphics")]
        [Produces("application/json")]
        public async Task<object> LoadsGraphics(string userEmail)
        {
            return await _IServiceExpense.LoadsGraphics(userEmail);
        }
    }
}
