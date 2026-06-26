using AutoMapper;
using HumanResource.Data;
using HumanResource.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controller
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;            
            _mapper = mapper;
        }

        [HttpGet]
        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>A list of employees.</returns>
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetEmployees()
        {
            var employees = await _employeeRepo.GetAllEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employees));
        }

        // [HttpGet("{id}")]
        // public IActionResult Get(int id)
        // {
        //     var employee = _employeeRepo.GetById(id);
        //     if (employee == null)
        //     {
        //         return NotFound();
        //     }
        //     var employeeDto = _mapper.Map<EmployeeReadDto>(employee);
        //     return Ok(employeeDto);
        // }

        // [HttpPost]
        // public IActionResult Create([FromBody] EmployeeCreateRequest request)
        // {
        //     if (request == null || string.IsNullOrWhiteSpace(request.Name))
        //     {
        //         return BadRequest("Invalid employee data.");
        //     }

        //     var employee = new
        //     {
        //         Id = 1,
        //         Name = request.Name,
        //         Position = request.Position
        //     };

        //     return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        // }
    }

    public class EmployeeCreateRequest
    {
        public string Name { get; set; }
        public string Position { get; set; }
    }
}
