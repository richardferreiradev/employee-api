using System;
using MediatR;
using employee_api.Models;

namespace employee_api.Commands
{
    public record PutEmployeeCommand(int Id, Employee Employee) : IRequest<Employee>
    {

    }
}
