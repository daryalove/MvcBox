using Entities.Context;
using Entities.Models;
using Entities.ViewModels;
using Entities.ViewModels.ContainerViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repository
{
    public class ContainerMethods
    {
        private readonly SmartBoxContext _boxContext;
        public ContainerMethods(SmartBoxContext boxContext)
        {
            _boxContext = boxContext;
        }

        /// <summary>
        /// Добавление контейнера в бд
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<ServiceResponseObject<ContainerResponse>> Create(string name)
        {
            ServiceResponseObject<ContainerResponse> DataContent = new ServiceResponseObject<ContainerResponse>();
            var box = new SmartBox
            {
                Name = name
            };

            var result = await _boxContext.SmartBoxes.AddAsync(box);
            _boxContext.SaveChanges();
            DataContent.Status = ResponseResult.OK;
            DataContent.Message = "Объект успешно добавлен!";
            DataContent.ResponseData = new ContainerResponse
            {
                SmartBoxId = box.Id,
                Name = box.Name
            };
            return DataContent;
        }

        /// <summary>
        /// Логгирование объекта по GPS
        /// </summary>
        /// <param name="model.Id"></param>
        /// <param name="model.Lon1"></param>
        /// <param name="model.Lat1"></param>
        /// <param name="model.Signal"></param>
        /// <param name="model.Date"></param>
        /// <returns></returns>
        public async Task<ServiceResponseObject<BaseResponseObject>> SetContainerLocation(LocationViewModel model)
        {
            SmartBox box = await _boxContext.SmartBoxes.FirstOrDefaultAsync(s => s.Id == model.Id);
            ServiceResponseObject<BaseResponseObject> DataContent = new ServiceResponseObject<BaseResponseObject>();

            
            if (box != null)
            {
                Location location = new Location
                {
                    BoxId = box.Id,
                    Latitude = model.Lat1,
                    Longitude = model.Lon1,
                    SignalLevel = model.Signal,
                    CurrentDate = model.Date,
                    Name = box.Name
                };

                _boxContext.Locations.Add(location);
                await _boxContext.SaveChangesAsync();
                DataContent.Message = "Успешно!";
                DataContent.Status = ResponseResult.OK;
                return DataContent;
            }

            DataContent.Message = "Контейнер не найден!";
            DataContent.Status = ResponseResult.Error;
            return DataContent;
        }
        
        /// <summary>
        /// Получение данных контейнера
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponseObject<BoxDataResponse>> GetBox(Guid id)
        {
            ServiceResponseObject<BoxDataResponse> ContentData = new ServiceResponseObject<BoxDataResponse>();
            var box = await _boxContext.SmartBoxes.FindAsync(id);

            if (box != null)
            {
                ContentData.ResponseData = new BoxDataResponse
                {
                    Id = box.Id,
                    BatteryPower = box.BatteryPower,
                    Code = box.Code,
                    BoxState = box.BoxState,
                    IsOpenedBox = box.IsOpenedBox,
                    IsOpenedDoor = box.IsOpenedDoor,
                    Light = box.Light,
                    Temperature = box.Temperature,
                    Weight = box.Weight,
                    Wetness = box.Wetness
                };
                ContentData.Message = "Данные контейнера получены.";
                ContentData.Status = ResponseResult.OK;
                return ContentData;
            }
            else
            {
                ContentData.Message = "Ошибка, нет данных.";
                ContentData.Status = ResponseResult.Error;
                return ContentData;
            }
        }

        /// <summary>
        /// Редактирование данных объекта
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ServiceResponseObject<BaseResponseObject>> EditBox(EditBoxViewModel model)
        {
            ServiceResponseObject<BaseResponseObject> ContentData = new ServiceResponseObject<BaseResponseObject>();
            if (model == null)
            {
                ContentData.Message = "Не указаны данные для контейнера.";
                ContentData.Status = ResponseResult.Error;
                return ContentData;
            }
            var box = await _boxContext.SmartBoxes.FirstOrDefaultAsync(s => s.Id == model.Id);
            //var team = await _teamContext.Teams.FirstOrDefaultAsync(f => f.Id == user.TeamId);
            
            if (box == null)
            {
                ContentData.Message = "Контейнер не найден.";
                ContentData.Status = ResponseResult.Error;
                return ContentData;
            }

            box.Name = model.Name;
            box.BoxState = model.BoxState;
            box.BatteryPower = model.BatteryPower;
            box.Code = model.Code;
            box.IsOpenedBox = model.IsOpenedBox;
            box.IsOpenedDoor = model.IsOpenedDoor;
            box.Light = model.Light;
            box.Temperature = model.Temperature;
            box.Weight = model.Weight;
            box.Wetness = model.Wetness;

            _boxContext.Update(box);
            await _boxContext.SaveChangesAsync();
            ContentData.Message = "Успешно.";
            ContentData.Status = ResponseResult.OK;
            return ContentData;
        }

       /// <summary>
       /// Получение первых 20 контейнеров
       /// </summary>
       /// <returns></returns>
        public async Task<ServiceResponseObject<ListResponse<ContainerResponse>>> GetBoxesByName(string name)
        {
            var boxes = await _boxContext.SmartBoxes.Where(b => b.Name.ToLower().StartsWith(name.ToLower())).OrderBy(b => b.Name).Take(20).Select(b => new ContainerResponse
            {
                Name = b.Name,
                SmartBoxId = b.Id
            }).ToListAsync();
            
            ServiceResponseObject<ListResponse<ContainerResponse>> ContentData = new ServiceResponseObject<ListResponse<ContainerResponse>>();
            if (boxes != null && boxes.Count != 0)
            {
                ContentData.ResponseData = new ListResponse<ContainerResponse>
                {
                    Objects = boxes
                };
                ContentData.Message = "Успешно!";
                ContentData.Status = ResponseResult.OK;
                return ContentData;
            }
            ContentData.Message = "Ничего не найдено.";
            ContentData.Status = ResponseResult.Error;
            return ContentData;
        }

        /// <summary>
        /// Получение последних координат каждого объекта
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponseObject<ListResponse<BoxLocation>>> GetBoxesLocation()
        {
            ServiceResponseObject<ListResponse<BoxLocation>> ContentData = new ServiceResponseObject<ListResponse<BoxLocation>>();
            var boxes = await _boxContext.SmartBoxes.ToListAsync();
            
            if (boxes == null || boxes.Count == 0)
            {
                ContentData.Message = "Контейнеры не добавлены еще в базу данных.";
                ContentData.Status = ResponseResult.Error;
                return ContentData;
            }

            //Загрузка связанных данных
            ContentData.ResponseData = new ListResponse<BoxLocation>();
            foreach (var box in boxes)
            {
                _boxContext.Entry(box)
            .Collection(c => c.Locations)
            .Load();
                
                if (box.Locations == null || box.Locations.Count == 0)
                    continue;
                
                // Получить последние координаты с объекта
                var lastItem = box.Locations.OrderBy(p => p.CurrentDate).Select(f => new BoxLocation
                { 
                    SmartBoxId = f.BoxId,
                    Name = f.Name,
                    Latitude = f.Latitude,
                    Longitude = f.Longitude,
                    BatteryPower = box.BatteryPower,
                    IsOpenedDoor = box.IsOpenedDoor,
                    BoxState = box.BoxState,
                    Code = box.Code,
                    IsOpenedBox = box.IsOpenedBox,
                    Light = box.Light,
                    Temperature = box.Temperature,
                    Weight = box.Weight,
                    Wetness = box.Wetness
                }
                ).Last();

                if (lastItem != null)
                    ContentData.ResponseData.Objects.Add(lastItem);
            }

            if (ContentData.ResponseData.Objects.Count == 0)
            {
                ContentData.Message = "Геолокация не найдена.";
                ContentData.Status = ResponseResult.Error;
                return ContentData;
            }

            ContentData.Message = "Успешно!";
            ContentData.Status = ResponseResult.OK;
            return ContentData;
        }

    }
}
