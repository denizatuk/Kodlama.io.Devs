using Application.Features.Skills.Models;
using Application.Services.Repositories.SkillRepository;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skills.Queries.GetListSkill
{
    public class GetListSkillQuery : IRequest<SkillListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListBranQueryHandler : IRequestHandler<GetListSkillQuery, SkillListModel>
        {
            private readonly ISkillRepository _skillRepository;
            private readonly IMapper _mapper;

            public GetListBranQueryHandler(ISkillRepository skillRepository, IMapper mapper)
            {
                _skillRepository = skillRepository;
                _mapper = mapper;
            }

            public async Task<SkillListModel> Handle(GetListSkillQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Skill> skills = await _skillRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                SkillListModel mappedSkillListModel = _mapper.Map<SkillListModel>(skills);

                return mappedSkillListModel;

            }

        }



    }
}
