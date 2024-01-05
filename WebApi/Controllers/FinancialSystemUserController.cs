using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IFinancialSystemUser;
using Domain.Interfaces.IServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FinancialSystemUserController : ControllerBase
    {
        private readonly InterfaceFinancialSystemUser _InterfaceFinancialSystemUser;
        private readonly IServiceFinancialSystemUser _IServiceFinancialSystemUser;
        public FinancialSystemUserController(InterfaceFinancialSystemUser InterfaceFinancialSystemUser, IServiceFinancialSystemUser IServiceFinancialSystemUser)
        {
            _InterfaceFinancialSystemUser = InterfaceFinancialSystemUser;
            _IServiceFinancialSystemUser = IServiceFinancialSystemUser;
        }

        [HttpGet("/api/ListFinancialSystemsUsers")]
        [Produces("application/json")]
        public async Task<object> ListFinancialSystemsUsers(int systemId)
        {
            return await _InterfaceFinancialSystemUser.ListFinancialSystemsUsers(systemId);
        }

        [HttpPost("/api/RegisterUserInTheSystem")]
        [Produces("application/json")]
        public async Task<object> RegisterUserInTheSystem(int systemId, string userEmail)
        {
            try
            {
                await _IServiceFinancialSystemUser.RegisterUserInTheSystem(
                    new FinancialSystemUser
                    {
                        SystemId = systemId,
                        UserEmail = userEmail,
                        Administrator = false,
                        CurrentSystem = true,
                    }
                );
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        [HttpDelete("/api/DeleteUserFinancialSystem")]
        [Produces("application/json")]
        public async Task<object> DeleteUserFinancialSystem(int id)
        {
            try
            {
                var userFinancialSystem = await _InterfaceFinancialSystemUser.GetEntityById(id);
                await _InterfaceFinancialSystemUser.Delete(userFinancialSystem);

            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
