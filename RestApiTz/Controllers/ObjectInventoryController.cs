using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            service = objectService;
        }

        [HttpPost]
        public void Post([FromBody] JToken value)
        {
            var newObj = JsonConvert.DeserializeObject<ObjectInventoryView>(value.ToString());

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventoryView, ObjectInventoryDTO>()).CreateMapper();
            var mObject = mapper.Map<ObjectInventoryView, ObjectInventoryDTO>(newObj);
            objectService.AddObjectInventory(mObject);
        }

        //[HttpGet]
        //public JArray Get()
        //{
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventoryDTO, ObjectInventoryView>()).CreateMapper();
        //    var mObjects = mapper.Map<IEnumerable<ObjectInventoryDTO>, List<ObjectInventoryView>>(objectService.GetObjects());

        //    return new JArray(JsonConvert.SerializeObject(mObjects));
        //}

        [HttpGet("{id}", Name = "GetObjectsFiltSortPage")]
        public JObject Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventoryDTO, ObjectInventoryView>()).CreateMapper();
            var mObject = mapper.Map<ObjectInventoryDTO, ObjectInventoryView>(objectService.GetObject(id));

            return JObject.Parse(JsonConvert.SerializeObject(mObject));
        }

        [HttpPut("{value}")]
        public void Put(int id, [FromBody] JToken value)
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
