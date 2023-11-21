using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IExpenses
{
    public interface InterfaceExpense : InterfaceGeneric<Expense>
    {
        Task<IList<Expense>> UserExpensesList(string emailUser);
        Task<IList<Expense>> UserExpensesListNotPayingPreviousMonths(string emailUser);
    }
}
