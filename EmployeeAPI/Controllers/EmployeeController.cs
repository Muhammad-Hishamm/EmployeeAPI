using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]

        public ActionResult <List<Employee>> GetAllEmployees()=>EmplyeeServices.GetAllEmployees();

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var emp = EmplyeeServices.Get(id);
            if (emp == null) return NotFound();
            return emp;
        }
        [HttpPost]
        public ActionResult Post( Employee emp)
        {
            if (emp == null) return BadRequest();
            EmplyeeServices.Add(emp);
            return CreatedAtAction(nameof(GetEmployee), new { id = emp.Id }, emp);
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id,Employee employee)
        {
            if(id != employee.Id) return BadRequest();
            var emp = EmplyeeServices.Get(id);
            if (emp is null) return NotFound();
            EmplyeeServices.update(emp);
            return NoContent();
        }
    }
}
