using AutoMapper;
using Vega.Domain.Models;
using Vega.WebApi.Controllers.Resources;

namespace Vega.WebApi.Controllers.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
        }
    }
}