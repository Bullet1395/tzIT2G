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
        private readonly IMapper mapper;

        public ObjectInventoryController(IObjectInventoryService service, IMapper mapperConf)
        {
            objectService = service;
            mapper = mapperConf;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JToken value)
        {
            var newObj = JsonConvert.DeserializeObject<ObjectInventoryView>(value.ToString());

            var mObject = mapper.Map<ObjectInventoryView, ObjectInventoryDTO>(newObj);
            await objectService.AddObjectInventory(mObject);

            return Ok();
        }

        [HttpGet]
        public JObject Get()
        {
            return JObject.Parse(JsonConvert.SerializeObject(objectService.GetExampleOptions()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (objectService.GetObject(id) != null)
            {
                return new ObjectResult(JsonConvert.SerializeObject(await objectService.GetObject(id)));
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
