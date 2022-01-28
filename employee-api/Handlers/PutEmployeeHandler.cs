using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using employee_api.Commands;
using employee_api.Models;
using employee_api.Services.Interfaces;

namespace employee_api.Handlers
{
    public class PutEmployeeHandler : IRequestHandler<PutEmployeeCommand, Employee>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public PutEmployeeHandler(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<Employee> Handle(PutEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request.Employee);
            employee.EmployeeId = request.Id;
            return await _employeeService.PutEmployee(employee);
        }
    }
}
