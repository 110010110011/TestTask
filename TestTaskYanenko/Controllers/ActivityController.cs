using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTaskYanenko.Models.Repository;

namespace TestTaskYanenko.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ITimeTracker _timeTracker;
        public ActivityController(ITimeTracker timeTracker)
        {
            _timeTracker = timeTracker;
        }

        [HttpGet("{id}/{date}")]
        public IActionResult Get([FromQuery] int id, [FromQuery] DateTime date)
        {
            IEnumerable<Models.Activity> activity = _timeTracker.GetActivityList(id, date);
            return Ok(activity);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Models.Activity> activity = _timeTracker.GetAll();
            return Ok(activity);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Models.Activity activity = _timeTracker.Get(id);
            if (activity == null)
            {
                return NotFound("The Activity record couldn't be found.");
            }
            return Ok(activity);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Activity activity)
        {
            if (activity == null)
            {
                return BadRequest("Activity is null.");
            }
            _timeTracker.Add(activity);
            return Created(string.Empty, activity);

        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Models.Activity activity)
        {
            if (activity == null)
            {
                return BadRequest("Activity is null.");
            }
            Models.Activity activityToUpdate = _timeTracker.Get(id);
            if (activityToUpdate == null)
            {
                return NotFound("The Ativity record couldn't be found.");
            }
            _timeTracker.Update(activityToUpdate, activity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Models.Activity activity = _timeTracker.Get(id);
            if (activity == null)
            {
                return NotFound("The Activity record couldn't be found.");
            }
            _timeTracker.Delete(activity);
            return NoContent();
        }
    }
}
