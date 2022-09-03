using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skills.Commands.CreateSkill
{
    public partial class CreateSkillCommand:IRequest<CreateSkillDto>
    {
    }
}
