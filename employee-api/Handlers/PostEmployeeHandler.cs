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
    public class PostEmployeeHandler : IRequestHandler<PostEmployeeCommand, Employee>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public PostEmployeeHandler(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<Employee> Handle(PostEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request.Employee);
            return await _employeeService.PostEmployee(employee);
        }
    }
}
