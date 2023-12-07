using Domain.Interfaces.Generics;
using Domain.Interfaces.IExpense;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ExpenseRepository : GenericsRepository<Expense>, InterfaceExpense
    {
        private readonly DbContextOptions<ContextBase> _OptoinBuilder;

        public ExpenseRepository()
        {
            _OptoinBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Expense>> ListUserExpenses(string emailUser)
        {
            using (var db = new ContextBase(_OptoinBuilder))
            {
                return await
                    (from fs in db.FinancialSystem
                     join c in db.Category on fs.Id equals c.SystemId
                     join fsu in db.FinancialSystemUser on fs.Id equals fsu.SystemId
                     join e in db.Expense on c.Id equals e.CategoryId
                     where fsu.UserEmail.Equals(emailUser) && fs.Month == e.Month && fs.Year == e.Year
                     select e)
                     .AsNoTracking()
                     .ToListAsync();
            }

                       //--select * from AspNetUsers where UserName = 'tibiocoelho@gmail.com'

                       //select *
                       //from FinancialSystem as fs                       
                       //inner join Categories as ct on fs.Id = ct.SystemId
                       //inner join FinancialSystemUser as fsu on fs.Id = fsu.SystemId
                       //inner join Expenses as ex on ct.Id = ex.CategoryId
                       //where fsu.UserEmail = 'tibiocoelho@gmail.com'--and fs.Month = ex.Month
        }         

        public async Task<IList<Expense>> ListUserExpensesNotPayingPreviousMonths(string emailUser)
        {
            using (var db = new ContextBase(_OptoinBuilder))
            {
                return await
                    (from fs in db.FinancialSystem
                     join c in db.Category on fs.Id equals c.SystemId
                     join fsu in db.FinancialSystemUser on fs.Id equals fsu.SystemId
                     join e in db.Expense on c.Id equals e.CategoryId
                     where fsu.UserEmail.Equals(emailUser) && e.Month < DateTime.Now.Month && !e.Paid
                     select e)
                     .AsNoTracking()
                     .ToListAsync();
            }
        }
    }
}
