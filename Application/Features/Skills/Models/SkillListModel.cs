using Application.Features.Skills.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skills.Models
{
    public class SkillListModel : BasePageableModel
    {
       
        public IList<SkillListDto> Items { get; set; }
    }
}
