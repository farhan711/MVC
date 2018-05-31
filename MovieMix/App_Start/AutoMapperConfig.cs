using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieMix.App_Start
{
    public static class AutoMapperConfig
    {

        public static void Init()
        {
            Mapper.Initialize(c => c.AddProfile<DomainToDtoMappingProfile>());
        }
    }
}