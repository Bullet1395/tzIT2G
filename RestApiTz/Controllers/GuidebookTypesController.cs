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
        private readonly IMapper mapper;

        public GuidebookTypesController(IGuideBookTypesService service, IMapper mapperConf)
        {
            guideBookTypesService = service;
            mapper = mapperConf;
        }

        [HttpPost]
        public IActionResult Post([FromBody] JToken value)
        {
            var newType = JsonConvert.DeserializeObject<GuidebookTypesView>(value.ToString());
                        
            var mGuidebookType = mapper.Map<GuidebookTypesView, GuidebookTypesDTO>(newType);
            guideBookTypesService.AddTypeGuideBookType(mGuidebookType);

            return Ok();
        }

        [HttpGet]
        public JArray Get()
        {
            var mGuidebookTypesList = mapper.Map<IEnumerable<GuidebookTypesDTO>, List<GuidebookTypesView>>(guideBookTypesService.GetGuideBookTypes());

            return JArray.Parse(JsonConvert.SerializeObject(mGuidebookTypesList));
        }

        [HttpGet("{id}", Name = "GetGuidbook")]
        public IActionResult Get(int id)
        {
            var mGuidebookType = mapper.Map<GuidebookTypesDTO, GuidebookTypesView>(guideBookTypesService.GetGuideBookType(id));

            if (mGuidebookType != null)
            {
                return new ObjectResult(JObject.Parse(JsonConvert.SerializeObject(mGuidebookType)));
            }
            else
            {
                return NotFound();
            }            
        }

        [HttpPut]
        public IActionResult Put([FromBody] JToken value)
        {
            var newType = JsonConvert.DeserializeObject<GuidebookTypesView>(value.ToString());

            var mGuidebookType = mapper.Map<GuidebookTypesView, GuidebookTypesDTO>(newType);

            guideBookTypesService.UpdateGuideBookType(mGuidebookType);

            return Ok(mGuidebookType);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (guideBookTypesService.GetGuideBookType(id) != null)
            {
                guideBookTypesService.RemoveGuideBookType(id);

                return NoContent();
            } else
            {
                return NotFound();
            }

           
        }
    }
}
