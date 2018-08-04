using AutoMapper;
using ETLSuite.Crosscutting.Enums;
using ETLSuite.Data.Entities;
using ETLSuite.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSuite.Util
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProjectStatus, Dictionary<int, string>>().ConvertUsing(x => new Dictionary<int, string>());
            });            

            CreateMap<Project, ProjectSummaryViewModel>();
            CreateMap<Project, ProjectInfoViewModel>()
                .ForMember(dest => dest.SelectedStatus, opts => opts.MapFrom(src => (int)src.Status))
                .ForMember(dest => dest.StatusOptions, opts => opts.ResolveUsing(new ProjectStatusToDictionaryResolver()));
            CreateMap<ProjectInfoViewModel, Project>()
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => (ProjectStatus)src.SelectedStatus));
            CreateMap<DbConnectionDefinition, DbConnectionDefinitionSummaryViewModel>()
                .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.Type.ToDisplay()));
        }

       
    }
    public class ProjectStatusToDictionaryResolver : IValueResolver<Project, ProjectInfoViewModel, Dictionary<int, string>>
    {
        public Dictionary<int, string> Resolve(Project source, ProjectInfoViewModel destination, Dictionary<int, string> destMember, ResolutionContext context)
        {
            var type = typeof(ProjectStatus);
            return Enum.GetValues(type).Cast<int>().ToDictionary(e => e, e => Enum.GetName(type, e));
        }
    }
}
