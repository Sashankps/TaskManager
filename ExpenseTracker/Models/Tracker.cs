using ExpenseTracker.Data;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Tracker
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool isExpense { get; set; }
    }
}
