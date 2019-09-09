using DTO;
using RestApiTz.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace RestApiTz.ModelsView
{
    public class MappingView : Profile
    {
        public MappingView()
        {
            CreateMap<GuidebookTypesView, GuidebookTypesDTO>();
            CreateMap<GuidebookTypesDTO, GuidebookTypesView>();

            CreateMap<ObjectInventoryView, ObjectInventoryDTO>();
            CreateMap<ObjectInventoryDTO, ObjectInventoryView>();
        }
    }
}
