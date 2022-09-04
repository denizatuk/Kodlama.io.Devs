using Application.Services.Repositories.SkillRepository;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skills.Rules
{
    public class SkillBusinessRules
    {
        private readonly ISkillRepository _skillRepository;

        public SkillBusinessRules(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task SkillNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Skill> result = await _skillRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Skill Name is exists.");
        }
    }
    
}
