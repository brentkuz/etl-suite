using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETLSuite.Controllers
{
    public abstract class BaseController<T> : Controller where T : class
    {
        protected readonly IMapper mapper;
        protected ILogger<T> logger;

        public BaseController(IMapper mapper, ILogger<T> logger)
        {
            this.mapper = mapper;
            this.logger = logger;
        }
    }

}