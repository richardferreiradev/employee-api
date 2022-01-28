using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using employee_api.Commands;
using employee_api.Services.Interfaces;

namespace employee_api.Handlers
{
    public class EmptyClass : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeService _employeeService;

        public EmptyClass(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var results = await _employeeService.DeleteEmployee(request.EmployeeId);
            return results;
        }
    }
}
