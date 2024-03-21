using Employee_CRUD_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Employee_CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _context;

        public EmployeeController(IEmployeeRepository context)
        {

            _context = context;
        }

        //POST METHOD:api/Employees
        [HttpPost]
        public async Task<ActionResult<bool>> PostEmployee([FromBody] Employee employee)
        {
            var emp = await _context.AddEmployeeData(employee);
            if (emp)
            {
                return Ok("Employee record added successfully");
            }
            else
                return BadRequest("Employee record  not added successfully ");

        }

        //GET METHOD:api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            IEnumerable<Employee> emplist = await _context.GetAllEmployees();
            if (emplist.Count() > 0)
                return Ok(emplist);
            else
                return NotFound("Employee list not found");

        }

        //GET METHOD:api/Employees/id
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeDetailsById(int id)
        {

            var employee = await _context.GetEmployeeDetailsById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        //PUT METHOD:api/Employees/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("Id is not exist in the object");
            }
            else
            {
                var emp = await _context.UpdateEmployeeData(employee);
                if (emp != null)
                {
                    return Ok(emp);
                }
                else
                {
                    return BadRequest("Failed to update");
                }
            }


        }

        //DELETE METHOD:api/Employees/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.DeleteEmployeeData(id);
            if (employee)
            {
                return Ok("Employee deleted");
            }
            else
            {
                return BadRequest("Employee not deleted");
            }

        }
    }
}
