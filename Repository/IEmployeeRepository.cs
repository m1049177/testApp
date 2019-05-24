using testApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeeList();
        void PostEmployeeList(Employee employee);
    }
}
