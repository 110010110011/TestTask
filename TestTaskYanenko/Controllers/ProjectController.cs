using Microsoft.AspNetCore.Mvc;
using TestTaskYanenko.Models;
using TestTaskYanenko.Models.Repository;

namespace TestTaskYanenko.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IDataRepository<Project> _dataRepository;
        public ProjectController(IDataRepository<Project> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Project> projects = _dataRepository.GetAll();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Project project = _dataRepository.Get(id);
            if (project == null)
            {
                return NotFound("The Project record couldn't be found.");
            }
            return Ok(project);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest("Project is null.");
            }
            _dataRepository.Add(project);
            return Created(string.Empty, project);

        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest("Project is null.");
            }
            Project projectToUpdate = _dataRepository.Get(id);
            if (projectToUpdate == null)
            {
                return NotFound("The Project record couldn't be found.");
            }
            _dataRepository.Update(projectToUpdate, project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Project project = _dataRepository.Get(id);
            if (project == null)
            {
                return NotFound("The Project record couldn't be found.");
            }
            _dataRepository.Delete(project);
            return NoContent();
        }
    }
}
