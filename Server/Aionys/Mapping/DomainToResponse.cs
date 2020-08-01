using Aionys.Contracts.Responses;
using Aionys.DAL.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aionys.Mapping
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Note, NoteResponse>();
        }
    }
}
