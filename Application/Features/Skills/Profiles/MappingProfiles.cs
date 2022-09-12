using Application.Features.Skills.Commands.CreateSkill;
using Application.Features.Skills.Commands.DeleteSkill;
using Application.Features.Skills.Commands.UpdateSkill;
using Application.Features.Skills.Dtos;
using Application.Features.Skills.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skills.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            //created
            CreateMap<CreateSkillCommand, Skill>().ReverseMap();
            CreateMap<Skill, CreatedSkillDto>().ReverseMap();
            //updated
            CreateMap<UpdatedSkillCommand,Skill>().ReverseMap();
            CreateMap<Skill, UpdatedSkillDto>().ReverseMap();
            //Deleted
            CreateMap<DeletedSkillCommand, Skill>().ReverseMap();
            CreateMap<Skill,DeletedSkillDto>().ReverseMap();

            //Listed paginate extension
            CreateMap<IPaginate<Skill>, SkillListModel>().ReverseMap();
            //GetById
            CreateMap<Skill, SkillGetByIdDto>().ReverseMap();
        }
    }
}
