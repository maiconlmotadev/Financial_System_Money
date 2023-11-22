using Domain.Interfaces.IExpenses;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceExpense : IServiceExpense
    {
        private readonly InterfaceExpense _interfaceExpense;

        public ServiceExpense(InterfaceExpense interfaceExpense)
        {
            _interfaceExpense = interfaceExpense;
        }

        public async Task AddExpense(Expense expense)
        {
            var date = DateTime.UtcNow;
            expense.RegistrationDate = date;
            expense.Year = date.Year;
            expense.Month = date.Month;

            var isValid = expense.ValidateStringProperty(expense.Name, "Name");
            if (isValid)
            {
                await _interfaceExpense.Add(expense);
            }
        }

        public async Task UpdateExpense(Expense expense)
        {
            var date = DateTime.UtcNow;
            expense.ChangeDate = date;

            if(expense.Paid)
            {
                expense.PaymentDate = date;
            }


            var isValid = expense.ValidateStringProperty(expense.Name, "Name");
            if (isValid)
            {
                await _interfaceExpense.Update(expense);
            }
        }
    }
}
