using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Api.Core.UOW;
using RepositoryPattern.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        [Route(template: "GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Employees.GetAllAsync());
        }

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route(template: "GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee is null)
                return NotFound();
            return Ok(employee);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Route(template: "AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            if (employee is not null)
            {
                await _unitOfWork.Employees.InsertAsync(employee);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<EmployeeController>/5
        [HttpPost]
        [Route(template: "UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            if (employee is null) return NotFound();

            var employeeEntity = await _unitOfWork.Employees.GetByIdAsync(employee.Id);
            if (employeeEntity is not null)
            {
                employeeEntity.Name = employee.Name;
                employeeEntity.Email = employee.Email;
                employeeEntity.Address = employee.Address;
                await _unitOfWork.Employees.UpdateAsync(employeeEntity);
                await _unitOfWork.CompleteAsync();
                return Ok(employeeEntity);
            }
            return NoContent();



        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete]
        [Route(template: "DeleteEmployee")]
        public async Task<IActionResult> Delete(int id)
        {
            var employeeEntity = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employeeEntity is null) return NotFound();
            await _unitOfWork.Employees.DeleteAsync(employeeEntity);
            return Ok(employeeEntity);
        }
    }
}
