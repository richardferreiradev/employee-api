using employee_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employee_api.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployees();

        public Task<Employee> GetEmployee(int employeeId);

        public Task<Employee> PostEmployee(Employee employee);

        public Task<Employee> PutEmployee(Employee employee);

        public Task<bool> DeleteEmployee(int employeeId);
    }
}
