using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;
using TestAPI.Models.Repository;

namespace TestAPI.Controllers
{
    [Route("api/[test]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository<Item> _dataRepository;
        public ItemController(IDataRepository<Item> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Item> items = _dataRepository.GetAll();
            return Ok(items);
        }
        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Item item = _dataRepository.Get(id);
            if (item == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            return Ok(item);
        }
        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest("Employee is null.");
            }
            _dataRepository.Add(item);
            return CreatedAtRoute(
                  "Get", 
                  new { Id = item.Id },
                  item);
        }
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest("Employee is null.");
            }
            Item employeeToUpdate = _dataRepository.Get(id);
            if (employeeToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            _dataRepository.Update(itemToUpdate, item);
            return NoContent();
        }
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Item item = _dataRepository.Get(id);
            if (item == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            _dataRepository.Delete(item);
            return NoContent();
        }
    }
}
