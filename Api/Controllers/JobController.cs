using System.Threading.Tasks;
using Application.Jobs.Commands.UpsertJob;
using Application.Jobs.Queries.GetJobsList;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class JobController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<JobListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetJobsListQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(UpsertCategoryCommand command)
        {
            var hasSucceeded = await Mediator.Send(command);
            if(hasSucceeded)
                return Ok();

            return BadRequest();
        }

        [HttpGet("hello")]
        public IActionResult HelloWorld()
        {
            return Ok(new {message = "Hello there!"});
        }
    }
}