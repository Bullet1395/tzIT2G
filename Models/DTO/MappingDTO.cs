using AutoMapper;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class MappingDTO : Profile
    {
        public MappingDTO()
        {
            CreateMap<GuidebookTypes, GuidebookTypesDTO>();
            CreateMap<GuidebookTypesDTO, GuidebookTypes>();

            CreateMap<ObjectInventory, ObjectInventoryDTO>();
            CreateMap<ObjectInventoryDTO, ObjectInventory>();
        }
    }
}
