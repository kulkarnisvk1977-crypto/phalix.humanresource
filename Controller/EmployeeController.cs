using AutoMapper;
using HumanResource.Data;
using HumanResource.Dtos;
using HumanResource.Models;
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

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeReadDto>> GetEmployeeById(int id)
        {
            var employee = await _employeeRepo.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            //var employeeDto = _mapper.Map<EmployeeReadDto>(employee);
            return Ok(_mapper.Map<EmployeeReadDto>(employee));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeReadDto>> Create(EmployeeCreateDto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.FirstName))
            {
                return BadRequest("Invalid employee data.");
            }

            var newEmployee = _mapper.Map<Employee>(request);
            await _employeeRepo.CreateEmployee(newEmployee);
           
            var employeeReadDto = _mapper.Map<EmployeeReadDto>(newEmployee);
            return CreatedAtRoute(nameof(GetEmployeeById), new { id = employeeReadDto.EmployeeId }, employeeReadDto);
        }
    }

    public class EmployeeCreateRequest
    {
        public string Name { get; set; }
        public string Position { get; set; }
    }
}
