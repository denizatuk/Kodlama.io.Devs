using Application.Services.Repositories.SkillRepository;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SkillRepository : EfRepositoryBase<Skill, BaseDbContext>, ISkillRepository
    {
        public SkillRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
