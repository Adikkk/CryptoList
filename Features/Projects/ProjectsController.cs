using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace List.Features.Projects
{
    [Route("api/[controller]")]
    public partial class ProjectsController : Controller
    {
        private readonly IMediator _mediator;
        
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _mediator.Send(new Get.Query()));

        /*[HttpGet]
        public async Task<IActionResult> Masno([FromBody]string id)
            => Ok(await _mediator.Send(new Details.Query(id)));
        */

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post.Command command)
            => Ok(await _mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Put.Command command)
            => Ok(await _mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Delete.Command command)
            => Ok(await _mediator.Send(command));
    }
}
