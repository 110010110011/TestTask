using Microsoft.AspNetCore.Mvc;
using TestTaskYanenko.Models;
using TestTaskYanenko.Models.Repository;

namespace TestTaskYanenko.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IDataRepository<Role> _dataRepository;
        public RoleController(IDataRepository<Role> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Role> roles = _dataRepository.GetAll();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Role role = _dataRepository.Get(id);
            if (role == null)
            {
                return NotFound("The Role record couldn't be found.");
            }
            return Ok(role);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Role role)
        {
            if (role == null)
            {
                return BadRequest("Role is null.");
            }
            _dataRepository.Add(role);
            return Created(string.Empty, role);

        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Role role)
        {
            if (role == null)
            {
                return BadRequest("Role is null.");
            }
            Role roleToUpdate = _dataRepository.Get(id);
            if (roleToUpdate == null)
            {
                return NotFound("The Role record couldn't be found.");
            }
            _dataRepository.Update(roleToUpdate, role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Role role = _dataRepository.Get(id);
            if (role == null)
            {
                return NotFound("The Role record couldn't be found.");
            }
            _dataRepository.Delete(role);
            return NoContent();
        }
    }
}
