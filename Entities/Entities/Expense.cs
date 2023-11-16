using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Table("Expenses")]
    public class Expense : Base
    {
        public decimal Price { get; set; }
        public int Month {  get; set; }
        public int Year { get; set; }

        public EnumTypeExpense TypeExpense { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ChangeDate { get; set;}
        public DateTime PaymentDate { get; set;}
        public DateTime DueDate { get; set;}
        public bool Paid { get; set; }
        public bool DelayedExpense { get; set;}

        [ForeignKey("Categories")]
        [Column(Order = 1)]
        public int CategoriesId { get; set; }
        public virtual Category Categories { get; set; }
    }
}
