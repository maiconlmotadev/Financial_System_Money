using Domain.Interfaces.IFinancialSystemUser;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceFinancialSystemUser : IServiceFinancialSystemUser
    {
        private readonly InterfaceFinancialSystemUser _interfaceFinancialSystemUser;

        public ServiceFinancialSystemUser(InterfaceFinancialSystemUser interfaceFinancialSystemUser)
        {
            _interfaceFinancialSystemUser = interfaceFinancialSystemUser;
        }

        public async Task RegisterUserInTheSystem(FinancialSystemUser financialSystemUser)
        {
            await _interfaceFinancialSystemUser.Add(financialSystemUser);
        }
    }
}
