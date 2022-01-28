using System;
using MediatR;
using employee_api.Models;

namespace employee_api.Commands
{
    public record PostEmployeeCommand(Employee Employee) : IRequest<Employee>
    {

    }
}
