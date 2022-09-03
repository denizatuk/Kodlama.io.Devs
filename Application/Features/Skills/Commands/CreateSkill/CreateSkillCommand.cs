using Application.Features.Skills.Dtos;
using Application.Features.Skills.Rules;
using Application.Services.Repositories.SkillRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skills.Commands.CreateSkill
{
    public partial class CreateSkillCommand : IRequest<CreatedSkillDto>
    {
        public string Name { get; set; }
        public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, CreatedSkillDto>

        {
            private readonly ISkillRepository _skillRepository;
            private readonly IMapper _mapper;
            private readonly SkillBusinessRules _skillBussinesRules;
            public CreateSkillCommandHandler(ISkillRepository skillRepository, IMapper mapper, SkillBusinessRules skillBussinesRules)
            {
                _skillRepository = skillRepository;
                _mapper = mapper;
                _skillBussinesRules = skillBussinesRules;
            }
            public async Task<CreatedSkillDto> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
            {
                await _skillBussinesRules.SkillNameCanNotBeDuplicatedWhenInserted(request.Name);
                Skill mappedSkill = _mapper.Map<Skill>(request);
                Skill createdSkill = await _skillRepository.AddAsync(mappedSkill);
                CreatedSkillDto createdSkillDto = _mapper.Map<CreatedSkillDto>(createdSkill);

                return createdSkillDto;
            }


        }
    }
}
