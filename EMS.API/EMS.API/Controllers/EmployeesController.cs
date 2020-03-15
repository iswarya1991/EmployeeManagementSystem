using EMS.Business;
using EMS.Data;
using System.Web.Http;

namespace EMS.API.Controllers
{
    [RoutePrefix("api/Employees")]
    public class EmployeesController : ApiController
    {
       private EMSLogic _EMSLogic;
        public EmployeesController()
        {
            _EMSLogic = new EMSLogic();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEmployees()
        {
            return Ok(_EMSLogic.GetEmployees());
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEmployeeLastname(int id)
        {
            return Ok(_EMSLogic.GetEmployeeById(id));

        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddEmployee([FromBody]Employee employee)
        {
            return Ok(_EMSLogic.CreateEmployee(employee));
        }
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            return Ok(_EMSLogic.DeleteEmployee(id));
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateEmployee(int id, Employee employee)
        {
            return Ok(_EMSLogic.UpdateEmployee(id, employee));
        }
    }
}
