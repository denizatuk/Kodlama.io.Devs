using Application.Features.Skills.Dtos;
using Application.Features.Skills.Rules;
using Application.Services.Repositories.SkillRepository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skills.Commands.DeleteSkill
{
    public class DeletedSkillCommand : IRequest<DeletedSkillDto>
    {
        public int Id { get; set; }
        public class DeletedSkillCommandHandler : IRequestHandler<DeletedSkillCommand, DeletedSkillDto>
        {
            private readonly ISkillRepository _skillRepository;
            private readonly IMapper _mapper;
            private readonly SkillBusinessRules _skillBusinessRules;

            public DeletedSkillCommandHandler(ISkillRepository skillRepository, IMapper mapper, SkillBusinessRules skillBusinessRules)
            {
                _skillRepository = skillRepository;
                _mapper = mapper;
                _skillBusinessRules = skillBusinessRules;
            }

            public async Task<DeletedSkillDto> Handle(DeletedSkillCommand request, CancellationToken cancellationToken)
            {
                var existingSkill = await _skillRepository.GetAsync(s => s.Id == request.Id);

                _skillBusinessRules.SkillShouldExist(existingSkill);

                var deletedSkill = await _skillRepository.DeleteAsync(existingSkill!);
                var deletedSkillDto = _mapper.Map<DeletedSkillDto>(deletedSkill);
                return deletedSkillDto;
            }
        }
    }
}
