using System.Collections.Generic;
using System.Data;
using employee_api.Services.Interfaces;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using employee_api.Models;

namespace employee_api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration _appConfig;

        public EmployeeService(IConfiguration appConfig)
        {
            _appConfig = appConfig;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            using IDbConnection connection = new SqlConnection(_appConfig.GetValue<string>("DbConnection"));
            connection.Open();
            var query = $"SELECT * FROM dbo.Employees";
            var result = await connection.QueryAsync<Employee>(query);
            return result.ToList();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            using IDbConnection connection = new SqlConnection(_appConfig.GetValue<string>("DbConnection"));
            connection.Open();
            var query = $"SELECT * FROM dbo.Employees WHERE EmployeeID = {employeeId}";
            return await connection.QueryFirstOrDefaultAsync<Employee>(query);
        }

        public async Task<Employee> PostEmployee(Employee employee)
        {
            using IDbConnection connection = new SqlConnection(_appConfig.GetValue<string>("DbConnection"));
            connection.Open();
            var insert = "INSERT INTO dbo.Employees (FirstName, LastName, EmailAddress, Department, DateOfBirth) Values (@FirstName, @LastName, @EmailAddress, @Department, @DateOfBirth)";
            var exec = await connection.ExecuteAsync(insert, employee);
            var getRecentRow = $"SELECT TOP 1 * FROM dbo.Employees ORDER BY EmployeeID DESC";
            var readRow = await connection.QueryFirstOrDefaultAsync<Employee>(getRecentRow);
            return readRow;
        }

        public async Task<Employee> PutEmployee(Employee employee)
        {
            using IDbConnection connection = new SqlConnection(_appConfig.GetValue<string>("DbConnection"));
            connection.Open();
            var update = "UPDATE dbo.Employees SET FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress, Department = @Department, DateOfBirth = @DateOfBirth WHERE EmployeeID = @EmployeeId";
            var exec = await connection.ExecuteAsync(update, new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmailAddress = employee.EmailAddress,
                Department = employee.Department,
                DateOfBirth = employee.DateOfBirth,
                EmployeeId = employee.EmployeeId
            });
            var getRecentRow = $"SELECT * FROM dbo.Employees WHERE EmployeeID = {employee.EmployeeId}";
            var readRow = await connection.QueryFirstOrDefaultAsync<Employee>(getRecentRow);
            return readRow;
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            using IDbConnection connection = new SqlConnection(_appConfig.GetValue<string>("DbConnection"));
            connection.Open();
            var query = $"DELETE FROM dbo.Employees WHERE EmployeeID = {employeeId}";
            var exec = await connection.ExecuteReaderAsync(query);
            var results = exec.RecordsAffected;
            return results > 0;
        }
    }
}