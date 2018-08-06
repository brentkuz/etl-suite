using AutoMapper;
using ETLSuite.Business.Objects;
using ETLSuite.Crosscutting.Enums;
using ETLSuite.Data.Entities;
using ETLSuite.Models.Project;
using ETLSuite.Models.Project.Tabs;
using ETLSuite.Models.Project.Tabs.DbConnection;
using ETLSuite.Models.Project.Tabs.EditModals.DbConnection;
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
                .ForMember(dest => dest.TypeDisplay, opts => opts.MapFrom(src => src.Type.ToDisplay()));

            CreateMap<SqlServerConnectionDefinition, SqlServerConnectionDefinitionViewModel>()
                .ForMember(dest => dest.DataSource, opts => opts.MapFrom(src => src.ConnectionString.DataSource))
                .ForMember(dest => dest.InitialCatalog, opts => opts.MapFrom(src => src.ConnectionString.InitialCatalog))
                .ForMember(dest => dest.ConnectionRetryCount, opts => opts.MapFrom(src => src.ConnectionString.ConnectRetryCount))
                .ForMember(dest => dest.ConnectionRetryInterval, opts => opts.MapFrom(src => src.ConnectionString.ConnectRetryCount))
                .ForMember(dest => dest.Encrypt, opts => opts.MapFrom(src => src.ConnectionString.Encrypt))
                .ForMember(dest => dest.IntegratedSecurity, opts => opts.MapFrom(src => src.ConnectionString.IntegratedSecurity))
                .ForMember(dest => dest.MultipleActiveResultSets, opts => opts.MapFrom(src => src.ConnectionString.MultipleActiveResultSets))
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.ConnectionString.Password))
                .ForMember(dest => dest.UserID, opts => opts.MapFrom(src => src.ConnectionString.UserID));
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
