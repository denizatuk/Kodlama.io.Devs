using Application.Features.Skills.Commands.CreateSkill;
using Application.Features.Skills.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSkillCommand createSkillCommand)
        {
            CreatedSkillDto result = await Mediator.Send(createSkillCommand);
            return Created("", result);
        }  
    }
}
