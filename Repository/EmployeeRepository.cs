using Dapper;
using testApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public EmployeeRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<List<Employee>> GetEmployeeList()
        {
            try
            {
                List<Employee> employeeList = new List<Employee>();
                using (IDbConnection connection = _sqlConnectionFactory.CreateConnection())
                {
                    employeeList = (await connection.QueryAsync<Employee>(@"select * from Employee;")).ToList();
                }
                return employeeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void PostEmployeeList(Employee employee)
        {
            try
            {
                using (IDbConnection connection = _sqlConnectionFactory.CreateConnection())
                {
                    await connection.ExecuteAsync(@"insert into Employee(EmployeeName,Experience) values(@EmployeeName,@Experience);" , new {employee.EmployeeName,employee.Experience});
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
