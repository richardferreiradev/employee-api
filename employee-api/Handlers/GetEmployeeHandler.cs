using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using employee_api.Models;
using employee_api.Queries;
using employee_api.Services.Interfaces;

namespace employee_api.Handlers
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeQuery, Employee>
    {
        private readonly IEmployeeService _employeeService;

        public GetEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _employeeService.GetEmployee(request.EmployeeId);
        }
    }
}
