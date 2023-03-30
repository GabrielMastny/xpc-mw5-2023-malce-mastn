using System;
using System.Collections.Generic;
using System.Linq;
using App.DAL.Entities;
using App.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using CommonDbProperties.Interfaces.Repositories;
using EFDb.Context;
using EFDb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version}/[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly ILogger<CommodityController> _logger;
        private readonly CommodityRepository _commodityRepository;

        public CommodityController(ILogger<CommodityController> logger, CommodityRepository commodityRepository)
        {
            _logger = logger;
            if (commodityRepository is CommodityRepository commRep)
                _commodityRepository = commRep;
        }

        [HttpGet(Name = nameof(Get))]
        public ActionResult<IEnumerable<CommodityEntity>> Get(ApiVersion version, [FromQuery] QueryParameters queryParameters)
        {
            return Ok(_db.Comodities.Cast<CommodityEntity>());
        }
        
        [HttpGet]
        [Route("{id:Guid}", Name = nameof(GetSingleCommodity))]
        public ActionResult<CommodityEntity> GetSingleCommodity(ApiVersion version, Guid id)
        {
            CommodityEntity commodityItem = null;
            
            
            if (com is default(Commodity))
                return NotFound();
            
            // // should be removed later on when repository yielding is stable
            // try
            // {
            //     commodityItem = _commodityRepository.GetById(id);
            // }
            // catch (Exception e)
            // {
            //     _logger.LogError(0, e, "");
            //     Console.WriteLine(e);
            // }
            

            if (commodityItem is default(CommodityEntity))
            {
                return NotFound();
            }

            return commodityItem;
            //return Ok<CommodityEntity>(commodityItem);
        }

        [HttpPost(Name = nameof(AddCommodity))]
        public ActionResult<string> AddCommodity(ApiVersion version, [FromBody] CommodityCreateDto commodityCreateDto)
        {
            // var newG = _commodityRepository.Create(new CommodityEntity()
            // {
            //     Category = commodityCreateDto.Category,
            //     Weight = commodityCreateDto.Weight,
            //     Name = commodityCreateDto.Name,
            //     Description = commodityCreateDto.Description,
            //     Image = commodityCreateDto.Image,
            //     Manufacturer = commodityCreateDto.Manufacturer,
            //     Price = commodityCreateDto.Price,
            //     Reviews = new List<ReviewEntity>(),
            //     NumberOfPiecesInStock = commodityCreateDto.NumberOfPiecesInStock
            // });
#if DEBUG
            return string.Empty;
#else
            return Ok();
#endif
        }
    }
}