using Application.Features.Skills.Commands.CreateSkill;
using Application.Features.Skills.Commands.DeleteSkill;
using Application.Features.Skills.Commands.UpdateSkill;
using Application.Features.Skills.Dtos;
using Application.Features.Skills.Models;
using Application.Features.Skills.Queries.GetByIdSkill;
using Application.Features.Skills.Queries.GetListSkill;
using Core.Application.Requests;
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
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedSkillCommand updatedSkillCommand)
        {
            UpdatedSkillDto result = await Mediator!.Send(updatedSkillCommand);
            return Ok(result);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletedSkillCommand deletedSkillCommand)
        {
            DeletedSkillDto result = await Mediator!.Send(deletedSkillCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSkillQuery getListSkillQuery = new() { PageRequest = pageRequest };
            SkillListModel result = await Mediator!.Send(getListSkillQuery);

            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromQuery] GetByIdSkillQuery getByIdSkillQuery)
        {
            SkillGetByIdDto result = await Mediator!.Send(getByIdSkillQuery);
            return Ok(result);

        }

    }
}
