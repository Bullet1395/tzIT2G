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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestApiTz.ModelsView;

namespace RestApiTz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectInventoryController : ControllerBase
    {
        private readonly IObjectInventoryService objectService;

        public ObjectInventoryController(IObjectInventoryService service)
        {
            objectService = service;
        }

        [HttpPost]
        public void Post([FromBody] JToken value)
        {
            var newObj = JsonConvert.DeserializeObject<ObjectInventoryView>(value.ToString());

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventoryView, ObjectInventoryDTO>()).CreateMapper();
            var mObject = mapper.Map<ObjectInventoryView, ObjectInventoryDTO>(newObj);
            objectService.AddObjectInventory(mObject);
        }

        [HttpGet]
        public JObject Get()
        {
            return JObject.Parse(JsonConvert.SerializeObject(objectService.GetExampleOptions()));
        }

        [HttpGet("{id}")]
        public JArray Get(int id)
        {
            return JArray.Parse(JsonConvert.SerializeObject(objectService.GetObjects(id, null)));
        }

        [Route("FilterSortPage/")]
        [HttpGet]
        public JArray Get([FromBody]JToken optionsFilter)
        {
            var dOptions = JsonConvert.DeserializeObject<Options>(optionsFilter.ToString());
            return JArray.Parse(JsonConvert.SerializeObject(objectService.GetObjects(null, dOptions)));            
        }

        [HttpPut]
        public void Put([FromBody]JToken value)
        {
            var newType = JsonConvert.DeserializeObject<ObjectInventoryView>(value.ToString());

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventoryView, ObjectInventoryDTO>()).CreateMapper();
            var mObject = mapper.Map<ObjectInventoryView, ObjectInventoryDTO>(newType);

            objectService.UpdateObject(mObject);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            objectService.RemoveObject(id);
        }
    }
}
