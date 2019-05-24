using testApp.Models;
using testApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.BusinessLayer
{
    public class EmployeeManager : IEmployeeManager
    {
        public readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Task<List<Employee>> GetEmployeeList()
        {
            try
            {
                return (_employeeRepository.GetEmployeeList());
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
                _employeeRepository.PostEmployeeList(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
