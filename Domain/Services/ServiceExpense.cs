using Domain.Interfaces.IExpense;
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

        public async Task<object> LoadsGraphics(string userEmail)
        {
            var userExpense = await _interfaceExpense.ListUserExpenses(userEmail);
            var previousExpenses = await _interfaceExpense.ListUserExpensesNotPayingPreviousMonths(userEmail);

            var userExpensesNotPayingPreviousMonths = previousExpenses.Any() ?
                previousExpenses.ToList().Sum(x => x.Price) : 0;

            var expensesPaid = userExpense.Where(e => e.Paid && e.TypeExpense == Entities.Enums.EnumTypeExpense.Expenses)
                .Sum(x => x.Price);

            var pendingExpenses = userExpense.Where(e => !e.Paid && e.TypeExpense == Entities.Enums.EnumTypeExpense.Expenses)
                .Sum(x => x.Price);

            var investments = userExpense.Where(e => e.TypeExpense == Entities.Enums.EnumTypeExpense.Investment)
                .Sum(x => x.Price);

            return new
            {
                success = "Ok",
                expenses_Paid = expensesPaid,
                pending_Expenses = pendingExpenses,
                userExpenses_NotPayingPreviousMonths = userExpensesNotPayingPreviousMonths,
                investments = investments
            };
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
