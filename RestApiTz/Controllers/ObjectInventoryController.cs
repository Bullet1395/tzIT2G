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
        public IActionResult Post([FromBody] JToken value)
        {
            var newObj = JsonConvert.DeserializeObject<ObjectInventoryView>(value.ToString());

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventoryView, ObjectInventoryDTO>()).CreateMapper();
            var mObject = mapper.Map<ObjectInventoryView, ObjectInventoryDTO>(newObj);
            objectService.AddObjectInventory(mObject);

            return Ok();
        }

        [HttpGet]
        public JObject Get()
        {
            return JObject.Parse(JsonConvert.SerializeObject(objectService.GetExampleOptions()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (objectService.GetObject(id) != null)
            {
                return new ObjectResult(JsonConvert.SerializeObject(objectService.GetObject(id)));
            } else
            {
                return NotFound();
            }
        }

        [Route("FilterSortPage/")]
        [HttpGet]
        public JArray Get([FromBody]JToken optionsFilter)
        {
            var dOptions = JsonConvert.DeserializeObject<Options>(optionsFilter.ToString());
            return JArray.Parse(JsonConvert.SerializeObject(objectService.GetObjects(dOptions)));            
        }

        [HttpPut]
        public IActionResult Put([FromBody]JToken value)
        {
            var newType = JsonConvert.DeserializeObject<ObjectInventoryView>(value.ToString());

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventoryView, ObjectInventoryDTO>()).CreateMapper();
            var mObject = mapper.Map<ObjectInventoryView, ObjectInventoryDTO>(newType);

            objectService.UpdateObject(mObject);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (objectService.GetObject(id) != null)
            {
                objectService.RemoveObject(id);

                return NoContent();
            } else
            {
                return NotFound();
            }            
        }
    }
}
