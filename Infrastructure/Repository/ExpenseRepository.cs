using Domain.Interfaces.Generics;
using Domain.Interfaces.IExpenses;
using Entities.Entities;
using Infrastructure.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ExpenseRepository : GenericsRepository<Expense>, InterfaceExpense
    {
        public Task<IList<Expense>> UserExpenseList(string emailUser)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Expense>> UserExpenseListNotPayingPreviousMonths(string emailUser)
        {
            throw new NotImplementedException();
        }
    }
}
