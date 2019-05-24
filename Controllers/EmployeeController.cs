using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testApp.BusinessLayer;
using testApp.Models;

namespace testApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet]
        public IActionResult GetEmployeeList()
        {
            try
            {
                var employeeList = _employeeManager.GetEmployeeList().Result;
                return Ok(employeeList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong. Please contact the admin.");
            }
        }

        [HttpPost]
        public IActionResult PostEmployeeList(Employee employee)
        {
            try
            {
               _employeeManager.PostEmployeeList(employee);
                return Ok();
     
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong. Please contact the admin.");
            }
        }
    }
}
