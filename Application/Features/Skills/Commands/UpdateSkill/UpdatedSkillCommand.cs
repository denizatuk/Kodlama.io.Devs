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

namespace Application.Features.Skills.Commands.UpdateSkill
{
    public partial class UpdatedSkillCommand:IRequest<UpdatedSkillDto>
    {
        public string Name { get; set; }
        public class UpdateSkillCommandHandler : IRequestHandler<UpdatedSkillCommand, UpdatedSkillDto>
        {
            private readonly ISkillRepository _skillRepository;
            private readonly IMapper _mapper;
            private readonly SkillBusinessRules _skillBussinesRules;

            public UpdateSkillCommandHandler(ISkillRepository skillRepository, IMapper mapper, SkillBusinessRules skillBussinesRules)
            {
                _skillRepository = skillRepository;
                _mapper = mapper;
                _skillBussinesRules = skillBussinesRules;
            }

            public async Task<UpdatedSkillDto> Handle(UpdatedSkillCommand request, CancellationToken cancellationToken)
            {
                await _skillBussinesRules.SkillNameCanNotBeDuplicatedWhenInserted(request.Name);
                Skill mappedSkill = _mapper.Map<Skill>(request);
                Skill updatedSkill = await _skillRepository.UpdateAsync(mappedSkill);
                UpdatedSkillDto updatedSkillDto = _mapper.Map<UpdatedSkillDto>(updatedSkill);

                return updatedSkillDto;
            }
        }
    }
}
