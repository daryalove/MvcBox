using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Context;
using Entities.Repository;
using Entities.ViewModels;
using Entities.ViewModels.ContainerViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Entities.Models;

namespace MvcBox.ApiService
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly SmartBoxContext _boxContext;

        public ContainerController(SmartBoxContext boxContext)
        {
            _boxContext = boxContext;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ServiceResponseObject<ContainerResponse>> Create(string name)
        {
            ContainerMethods BoxData = new ContainerMethods(_boxContext);
            var Result = await BoxData.Create(name);
            return Result;
        }

        [HttpPut]
        [Route("EditBox")]
        public async Task<ServiceResponseObject<BaseResponseObject>> EditBox([FromBody]SmartBox model)
        {
            ContainerMethods BoxData = new ContainerMethods(_boxContext);
            var Result = await BoxData.EditBox(model);
            return Result;
        }

        [HttpPost]
        [Route("SetContainerLocation")]
        public async Task<ServiceResponseObject<BaseResponseObject>> SetContainerLocation(Guid id, double lon1, double lat1, double signal, DateTime date)
        {
            ContainerMethods BoxData = new ContainerMethods(_boxContext);
            var Result = await BoxData.SetContainerLocation(id, lon1, lat1, signal, date);
            return Result;
        }

        [HttpGet]
        [Route("GetBoxesByName")]
        public async Task<ServiceResponseObject<ListResponse<ContainerResponse>>> GetBoxesByName(string name)
        {
            ContainerMethods BoxData = new ContainerMethods(_boxContext);
            var Result = await BoxData.GetBoxesByName(name);
            return Result;
        }

        [HttpGet]
        [Route("GetBox")]
        public async Task<ServiceResponseObject<BoxDataResponse>> GetBox(Guid id)
        {
            ContainerMethods BoxData = new ContainerMethods(_boxContext);
            var Result = await BoxData.GetBox(id);
            return Result;
        }

        [HttpGet]
        [Route("GetBoxesLocation")]
        public async Task<JsonResult> GetBoxesLocation()
        {
            ContainerMethods BoxData = new ContainerMethods(_boxContext);
            JsonResult result = null;
            var data = await BoxData.GetBoxesLocation();
            var boxes = data.ResponseData.Objects;
            result = new JsonResult(boxes);
            return result;
        }

        // GET: api/Container
        [HttpGet]
        [Route("Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
    }
}
