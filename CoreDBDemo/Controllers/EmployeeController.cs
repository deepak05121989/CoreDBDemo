using CoreDBDemo.Model;
using CoreDBDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreDBDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;

        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            try
            {
                return await _employeeServices.GetEmployee();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            try
            {
                return await _employeeServices.GetEmployeeById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //  return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post(Employee employee)
        {
            try
            {
                await _employeeServices.SaveEmployee(employee);
                return Ok(HttpStatusCode.Created);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

           

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
