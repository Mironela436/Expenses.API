using expenses_project.Data.Services;
using expenses_project.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace expenses_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class expensesController : ControllerBase

    {
        public expensesService _expensesService;

        public expensesController(expensesService expensesService)
        {
            _expensesService = expensesService;
        }

        [HttpGet("get-all-expenses")]

        public IActionResult GetAllexpenses()
        {
            var allexpenses = _expensesService.GetAllexpenses();
            return Ok(allexpenses);
        }

        [HttpGet("get-expense-by-id/{id}")]

        public IActionResult GetexpenseById(int id)
        {
            var expense = _expensesService.GetexpenseById(id);
            return Ok(expense);
        }

        [HttpPost("add-expense")]

        public IActionResult Addexpense([FromBody]expenseVM expense)
        {
            _expensesService.Addexpense(expense);
            return Ok();    
        }

        [HttpPut("update-expense-by-id/{id}")]
        public IActionResult UpdateexpenseById(int id,[FromBody]expenseVM expense)
        {
            var updatedexpense = _expensesService.UpdateexpenseById(id, expense);
            return Ok(updatedexpense);
        }
        [HttpDelete("delete-expense-by-id/{id}")]
        public IActionResult DeleteexpenseById(int id)
        {
            _expensesService.DeleteexpenseById(id);
            return Ok();
        }
    }
}
