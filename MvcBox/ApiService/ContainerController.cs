﻿using System;
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
using Entities.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MvcBox.ApiService
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly SmartBoxContext _boxContext;
        private readonly UserManager<User> _userManager;

        public ContainerController(SmartBoxContext boxContext, UserManager<User> userManager)
        {
            _boxContext = boxContext;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ServiceResponseObject<ContainerResponse>> Create(string name)
        {
            ContainerMethods BoxData = new ContainerMethods(_boxContext);
            var Result = await BoxData.Create(name);
            return Result;
        }

        [HttpGet]
        [Route("SearchCommandPhoto")]
        public async Task<ServiceResponseObject<BaseResponseObject>> SearchCommandPhoto(string name)
        {
            ContainerMethods BoxData = new ContainerMethods(_boxContext);
            var Result = await BoxData.SearchCommandPhoto(name);
            return Result;
        }

        [HttpPut]
        [Route("EditBox")]
        public async Task<ServiceResponseObject<BaseResponseObject>> EditBox(EditBoxViewModel model)
        {
            if (ModelState.IsValid)
            {
                ContainerMethods BoxData = new ContainerMethods(_boxContext);
                var Result = await BoxData.EditBox(model);
                return Result;
            }
            ServiceResponseObject<BaseResponseObject> response = new ServiceResponseObject<BaseResponseObject>();
            response.Status = ResponseResult.Error;
     
            List<string> errors = ModelState.Values.Aggregate(
               new List<string>(),
               (a, c) =>
               {
                   a.AddRange(c.Errors.Select(r => r.ErrorMessage));
                   return a;
               },
               a => a
            );

            response.Message = errors[0];
            return response;
        }

        [HttpPost]
        [Route("SetContainerLocation")]
        public async Task<ServiceResponseObject<BaseResponseObject>> SetContainerLocation(LocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ContainerMethods BoxData = new ContainerMethods(_boxContext);
                var Result = await BoxData.SetContainerLocation(model);
                return Result;
            }

            ServiceResponseObject<BaseResponseObject> response = new ServiceResponseObject<BaseResponseObject>();
            response.Status = ResponseResult.Error;

            List<string> errors = ModelState.Values.Aggregate(
               new List<string>(),
               (a, c) =>
               {
                   a.AddRange(c.Errors.Select(r => r.ErrorMessage));
                   return a;
               },
               a => a
            );

            response.Message = errors[0];
            return response;
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
        public async Task<ServiceResponseObject<BoxDataResponse>> GetBox(Guid id, Guid driverId, Guid orderId)
        {
            ContainerMethods BoxData = new ContainerMethods(_boxContext);
            var Result = await BoxData.GetBox(id);
            if (Result.Status == ResponseResult.OK)
            {
                if (SearchDriver(driverId))
                {
                    OrderHasBox order = new OrderHasBox
                    {
                        BoxId = Result.ResponseData.Id,
                        IsBusy = true,
                        OrderId = orderId
                    };

                    DriverHasBox hasBox = new DriverHasBox
                    {
                        BoxId = Result.ResponseData.Id,
                        DriverId = driverId
                    };
                    _boxContext.DriverHasBoxes.Add(hasBox);
                    _boxContext.OrderHasBoxes.Add(order);
                    _boxContext.SaveChanges();
                    Result.Message += " Контейнер привязан.";
                }
            }
            return Result;
        }

        [HttpGet]
        [Route("GetBoxForUser")]
        public async Task<ServiceResponseObject<BoxDataResponse>> GetBoxForUser(string userId)
        {
            ContainerMethods BoxData = new ContainerMethods(_boxContext);
            var access = await _boxContext.UserHasAccesses.Where(p => p.UserId == userId).FirstOrDefaultAsync();
            if (access != null)
            {
                var Result = await BoxData.GetBox(access.BoxId);
                Result.Message += " Оплатите заказ.";
                return Result;
            }
            ServiceResponseObject<BoxDataResponse> response = new ServiceResponseObject<BoxDataResponse>();
            response.Message = "Нет доступа.";
            response.Status = ResponseResult.Error;
            return response;
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

        [HttpGet]
        [Route("PriceComputation")]
        public ServiceResponseObject<ComputationResponse> PriceComputation(PriceComputationViewModel model)
        {
            ServiceResponseObject<ComputationResponse> response = new ServiceResponseObject<ComputationResponse>();
            if (model.CargeType == "Выбор" || model.DangerClassType == "Выбор")
            {
                ModelState.AddModelError(string.Empty, "Укажите характер груза или класс опасности");
            }

            if (ModelState.IsValid)
            {
                OrderMethods BoxData = new OrderMethods(_boxContext, _userManager);
                var price = BoxData.PriceComputation(model);
                response.Message = "Успешно!";
                response.ResponseData = new ComputationResponse { Price = price };
                response.Status = ResponseResult.OK;
                return response;
            }
            response.Status = ResponseResult.Error;
            List<string> errors = ModelState.Values.Aggregate(
               new List<string>(),
               (a, c) =>
               {
                   a.AddRange(c.Errors.Select(r => r.ErrorMessage));
                   return a;
               },
               a => a
            );

            response.ResponseData = new ComputationResponse();
            response.Message = errors[0];
            return response;
        }

        // GET: api/Container
        [HttpGet]
        [Route("Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        private bool SearchDriver(Guid driverId)
        {
            try
            {
                var driver = _boxContext.Drivers.Find(driverId);
                if (driver == null)
                    return false;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
