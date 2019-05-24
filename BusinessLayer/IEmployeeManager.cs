using testApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.BusinessLayer
{
    public interface IEmployeeManager
    {
        Task<List<Employee>> GetEmployeeList();
        void PostEmployeeList(Employee employee);
    }
}
