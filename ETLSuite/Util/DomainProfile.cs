using AutoMapper;
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
            CreateMap<Project, ProjectSummaryViewModel>();
        }
    }
}
