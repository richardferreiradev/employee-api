using System;
using System.Collections.Generic;
using MediatR;
using employee_api.Models;

namespace employee_api.Queries
{
    public record GetEmployeeQuery(int EmployeeId) : IRequest<Employee>
    {

    }
}
