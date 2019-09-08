using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.BL;
using Models.Interfaces;
using Models.Services;
using RestApiTz.ModelsView;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestApiTz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidebookTypesController : ControllerBase
    {
        private readonly IGuideBookTypesService guideBookTypesService;

        public GuidebookTypesController(IGuideBookTypesService service)
        {
            guideBookTypesService = service;
        }

        [HttpPost]
        public void Post([FromBody] JToken value)
        {
            var newType = JsonConvert.DeserializeObject<GuidebookTypesView>(value.ToString());

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidebookTypesView, GuidebookTypesDTO>()).CreateMapper();
            var mGuidebookType = mapper.Map<GuidebookTypesView, GuidebookTypesDTO>(newType);
            guideBookTypesService.AddTypeGuideBookType(mGuidebookType);
        }

        [HttpGet]
        public JArray Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidebookTypesDTO, GuidebookTypesView>()).CreateMapper();
            var mGuidebookTypesList = mapper.Map<IEnumerable<GuidebookTypesDTO>, List<GuidebookTypesView>>(guideBookTypesService.GetGuideBookTypes());

            return JArray.Parse(JsonConvert.SerializeObject(mGuidebookTypesList));
        }

        [HttpGet("{id}", Name = "GetGuidbook")]
        public JObject Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidebookTypesDTO, GuidebookTypesView>()).CreateMapper();
            var mGuidebookType = mapper.Map<GuidebookTypesDTO, GuidebookTypesView>(guideBookTypesService.GetGuideBookType(id));

            return JObject.Parse(JsonConvert.SerializeObject(mGuidebookType));
        }

        [HttpPut]
        public void Put([FromBody] JToken value)
        {
            var newType = JsonConvert.DeserializeObject<GuidebookTypesView>(value.ToString());

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidebookTypesView, GuidebookTypesDTO>()).CreateMapper();
            var mGuidebookType = mapper.Map<GuidebookTypesView, GuidebookTypesDTO>(newType);

            guideBookTypesService.UpdateGuideBookType(mGuidebookType);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            guideBookTypesService.RemoveGuideBookType(id);
        }
    }
}
