using expenses_project.Data.Models;
using expenses_project.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace expenses_project.Data.Services
{
    public class expensesService
    {
        private AppDbContext _context;
        

        public expensesService(AppDbContext context)
        {
            _context=context;   
        }

        public void Addexpense(expenseVM expense)
        {

            var _expense = new expense()
            {
                Description = expense.Description,

                Amount = expense.Amount
            };

            _context.expenses.Add(_expense);    
            _context.SaveChanges();
        }

        public List<expense> GetAllexpenses() => _context.expenses.ToList();

        public expense GetexpenseById( int expenseId) => _context.expenses.FirstOrDefault(n => n.Id == expenseId);

        public expense UpdateexpenseById(int expenseId, expenseVM expense)
        {
            var _expense = _context.expenses.FirstOrDefault(n => n.Id == expenseId);
            if (_expense != null)
            {

                _expense.Description = expense.Description;

               _expense.Amount = expense.Amount;

                _context.SaveChanges();
            }
            return _expense;

        }
        public void DeleteexpenseById(int expenseId)
        {
            var _expense = _context.expenses.FirstOrDefault(n => n.Id == expenseId);
            if( _expense != null)
            {
                _context.expenses.Remove(_expense);
                _context.SaveChanges();
            }
        }

    }
}
