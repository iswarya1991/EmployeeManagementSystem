using EMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMS.API.Controllers
{
    [RoutePrefix("api/Employees")]
    public class EmployeesController : ApiController
    {
        public List<Employee> Employees;
        public EmployeesController()
        {
            Employees = new List<Employee>
            {
                new Employee
                {
                Id=1,Name="iswaryak",DeptName="IT"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Indu",
                    DeptName = "Fullstack developer"
                }
            };

        }

        [HttpGet]
        [Route("GetEmp")]
        public IHttpActionResult GetEmployee()
        {
            return Ok(Employees);

        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEmployeeLastname(int id)
        {
            return Ok("KIRANMAYEE");

        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddEmployee([FromBody]Employee employee)
        {
            Employees.Add(employee);
            return Ok(Employees);
        }
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employee = Employees.Find(x => x.Id == id);
            if(employee != null)
            {
                Employees.Remove(employee);
            }
            return Ok(Employees);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateEmployee(int id, string deptName)
        {
            Employee emp = Employees.Find(x => x.Id == id);
            if(emp != null)
            {
                emp.DeptName = deptName;
                return Ok(Employees);
            }
            return Ok("No record to update the employee");
        }
    }
}
