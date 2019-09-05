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
    public class GuidbookController : ControllerBase
    {
        //GuidbookService guidBookService = new GuidbookService(new DbRepository.Repositories.GuidbookRepository(new DbRepository.Context()));
        private readonly IGuidBookService guidBookService;

        public GuidbookController(IGuidBookService service)
        {
            guidBookService = service;
        }

        [HttpPost]
        public void Post([FromBody] JToken value)
        {
            var newType = JsonConvert.DeserializeObject<GuidbookView>(value.ToString());

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidbookView, GuidbookDTO>()).CreateMapper();
            var mGuidbook = mapper.Map<GuidbookView, GuidbookDTO>(newType);
            guidBookService.AddTypeGuidBook(mGuidbook);
        }

        [HttpGet]
        public JArray Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidbookDTO, GuidbookView>()).CreateMapper();
            var mGuidbookList = mapper.Map<IEnumerable<GuidbookDTO>, List<GuidbookView>>(guidBookService.GetGuidBooks());

            return new JArray(JsonConvert.SerializeObject(mGuidbookList));
        }

        [HttpGet("{id}", Name = "GetGuidbook")]
        public JObject Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidbookDTO, GuidbookView>()).CreateMapper();
            var mGuidbook = mapper.Map<GuidbookDTO, GuidbookView>(guidBookService.GetGuidBook(id));

            return JObject.Parse(JsonConvert.SerializeObject(mGuidbook));
        }

        [HttpPut("{value}")]
        public void Put([FromBody] JToken value)
        {
            var newType = JsonConvert.DeserializeObject<GuidbookView>(value.ToString());

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidbookView, GuidbookDTO>()).CreateMapper();
            var mGuidbook = mapper.Map<GuidbookView, GuidbookDTO>(newType);

            guidBookService.UpdateGuidBook(mGuidbook);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            guidBookService.RemoveGuidBook(id);
        }
    }
}
