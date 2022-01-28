using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using employee_api.Models;
using employee_api.Queries;
using employee_api.Services.Interfaces;

namespace employee_api.Handlers
{
    public class GetTweetHandler : IRequestHandler<GetEmployeesQuery, List<Employee>>
    {
        private readonly IEmployeeService _employeeService;

        public GetTweetHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<List<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _employeeService.GetEmployees();
        }
    }
}
