using Microsoft.AspNetCore.Mvc;
using TestTaskYanenko.Models;
using TestTaskYanenko.Models.Repository;

namespace TestTaskYanenko.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActivityTypeController : ControllerBase
    {
        private readonly IDataRepository<ActivityType> _dataRepository;
        public ActivityTypeController(IDataRepository<ActivityType> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ActivityType> activityType = _dataRepository.GetAll();
            return Ok(activityType);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            ActivityType activityType = _dataRepository.Get(id);
            if (activityType == null)
            {
                return NotFound("The ActivityType record couldn't be found.");
            }
            return Ok(activityType);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ActivityType activityType)
        {
            if (activityType == null)
            {
                return BadRequest("ActivityType is null.");
            }
            _dataRepository.Add(activityType);
            return Created(string.Empty, activityType);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ActivityType activityType)
        {
            if (activityType == null)
            {
                return BadRequest("ActivityType is null.");
            }
            ActivityType activityTypeToUpdate = _dataRepository.Get(id);
            if (activityTypeToUpdate == null)
            {
                return NotFound("The AtivityType record couldn't be found.");
            }
            _dataRepository.Update(activityTypeToUpdate, activityType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            ActivityType activityType = _dataRepository.Get(id);
            if (activityType == null)
            {
                return NotFound("The ActivityType record couldn't be found.");
            }
            _dataRepository.Delete(activityType);
            return NoContent();
        }
    }
}
