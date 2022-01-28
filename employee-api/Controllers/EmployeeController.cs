using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using employee_api.Commands;
using employee_api.Models;
using employee_api.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace employee_api.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetTweets()
        {
            var result = await _mediator.Send(new GetEmployeesQuery());
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetTweet(int id)
        {
            var result = await _mediator.Send(new GetEmployeeQuery(id));
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] Employee employee)
        {
            var result = await _mediator.Send(new PostEmployeeCommand(employee));
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> PutEmployee(int id, [FromBody] Employee employee)
        {
            var result = await _mediator.Send(new PutEmployeeCommand(id, employee));
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteEmployee(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            return result ? "Employee deleted successfully" : "Employee failed to delete";
        }
    }
}
