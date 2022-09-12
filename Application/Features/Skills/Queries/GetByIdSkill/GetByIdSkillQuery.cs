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

namespace Application.Features.Skills.Queries.GetByIdSkill
{
    public class GetByIdSkillQuery:IRequest<SkillGetByIdDto>
    {
        public int Id { get; set; }

       public class GetByIdSkillQueryHandler : IRequestHandler<GetByIdSkillQuery, SkillGetByIdDto>
        {
            private readonly ISkillRepository _skillRepository;
            private readonly IMapper _mapper;
            private readonly SkillBusinessRules _skillBusinessRules;

            public GetByIdSkillQueryHandler(ISkillRepository skillRepository, IMapper mapper, SkillBusinessRules skillBusinessRules)
            {
                _skillRepository = skillRepository;
                _mapper = mapper;
                _skillBusinessRules = skillBusinessRules;
            }

            public async Task<SkillGetByIdDto> Handle(GetByIdSkillQuery request, CancellationToken cancellationToken)
            {
                Skill? skill = await _skillRepository.GetAsync(s => s.Id == request.Id);

                _skillBusinessRules.SkillShouldExistWhenRequested(skill);

                SkillGetByIdDto skillGetByIdDto = _mapper.Map<SkillGetByIdDto>(skill);
                return skillGetByIdDto;
                   
            }
        }
    }
}
