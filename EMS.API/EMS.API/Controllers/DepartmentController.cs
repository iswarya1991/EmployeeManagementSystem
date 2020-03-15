using EMS.Business;
using EMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMS.API.Controllers
{
    [RoutePrefix("departments")]
    public class DepartmentController : ApiController
    {
        private EMSLogic _EMSLogic;
        public DepartmentController()
        {
            _EMSLogic = new EMSLogic();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetDepartments()
        {
            return Ok(_EMSLogic.GetDepartments());
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetDepartmentById(int id)
        {
            return Ok(_EMSLogic.GetDepartmentById(id));
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult AddDepartment([FromBody] Department department)
        {
            if (department == null) return BadRequest();
            _EMSLogic.CreateDepartment(department);
            return Ok("Added successfully!"); 
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateDepartment([FromBody] Department department)
        {
           return Ok(_EMSLogic.UpdateDepartment(department));
        }
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteDepartment(int id)
        {
            return Ok(_EMSLogic.DeleteDepartment(id));
        }
    }
}
