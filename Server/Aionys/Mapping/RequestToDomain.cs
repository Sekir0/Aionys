using Aionys.Contractss.Requests;
using Aionys.DAL.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aionys.Mapping
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
        }
    }
}
