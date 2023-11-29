using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IServices;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialSystemController : ControllerBase
    {
        private readonly InterfaceFinancialSystem _InterfaceFinancialSystem;
        private readonly IServiceFinancialSystem _IServiceFinancialSystem;

        public FinancialSystemController(InterfaceFinancialSystem InterfaceFinancialSystem, IServiceFinancialSystem IServiceFinancialSystem)
        {
            _InterfaceFinancialSystem = InterfaceFinancialSystem;
            _IServiceFinancialSystem = IServiceFinancialSystem;
        }

        [HttpGet("/api/ListFinancialSystemsUser")]
        [Produces("application/json")]
        public async Task<object> ListFinancialSystemsUser(string emailUser)
        {
            return await _InterfaceFinancialSystem.ListFinancialSystemsUser(emailUser);
        }

        [HttpPost("/api/AddFinancialSystem")]
        [Produces("application/json")]
        public async Task<object> AddFinancialSystem(FinancialSystem financialSystem)
        {
            await _IServiceFinancialSystem.AddFinancialSystem(financialSystem);

            return Task.FromResult(financialSystem);
        }

        [HttpPut("/api/UpdateFinancialSystem")]
        [Produces("application/json")]
        public async Task<object> UpdateFinancialSystem(FinancialSystem financialSystem)
        {
            await _IServiceFinancialSystem.UpdateFinancialSystem(financialSystem);

            return Task.FromResult(financialSystem);
        }

        [HttpGet("/api/GetFinancialSystem")]
        [Produces("application/json")]
        public async Task<object> GetFinancialSystem(int id)
        {
            return await _InterfaceFinancialSystem.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteFinancialSystem")]
        [Produces("application/json")]
        public async Task<object> DeleteFinancialSystem(int id)
        {
            try
            {
                var financialSystem = await _InterfaceFinancialSystem.GetEntityById(id);
                await _InterfaceFinancialSystem.Delete(financialSystem);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
