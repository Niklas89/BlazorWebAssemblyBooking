using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBooking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    { 
        private static List<Employee> Employees = new List<Employee>
        {
            new Employee
            {
                IdEmployee = 1,
                Lastname = "Dupont",
                Firstname = "Jacques",
                Mail = "jdupont@gmail.com"
            },
            new Employee
            {
                IdEmployee = 2,
                Lastname = "Vidal",
                Firstname = "Jules",
                Mail = "julesvidal@gmail.com"
            },
            new Employee
            {
                IdEmployee = 3,
                Lastname = "Lopin",
                Firstname = "Daniel",
                Mail = "daniellopin@gmail.com"
            },
        };

        [HttpGet]
        //public async Task<IActionResult> GetEmployee()
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            return Ok(Employees);
        } 
    }
}
