using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceFinancialSystem : IServiceFinancialSystem
    {
        private readonly InterfaceFinancialSystem _interfaceFinancialSystem;    

        public ServiceFinancialSystem(InterfaceFinancialSystem interfaceFinancialSystem) 
        {
            _interfaceFinancialSystem = interfaceFinancialSystem;     
        }

        public async Task AddFinancialSystem(FinancialSystem financialSystem)
        {
            var isValid = financialSystem.ValidateStringProperty(financialSystem.Name, "Name");

            if (isValid)
            {
                var date = DateTime.Now;

                financialSystem.ClosingDay = 1;
                financialSystem.Year = date.Year;
                financialSystem.Month = date.Month;
                financialSystem.YearCopy = date.Year;
                financialSystem.MonthCopy = date.Month;
                financialSystem.GenerateExpenseCopy = true;

                await _interfaceFinancialSystem.Add(financialSystem);
            }
        }

        public async Task UpdateFinancialSystem(FinancialSystem financialSystem)
        {
            var isValid = financialSystem.ValidateStringProperty(financialSystem.Name, "Name");

            if (isValid)
            {
                financialSystem.ClosingDay = 1;
                await _interfaceFinancialSystem.Update(financialSystem);
            }
        }
    }
}
