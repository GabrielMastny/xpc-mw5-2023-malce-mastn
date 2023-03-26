using System;
using System.Collections.Generic;
using System.Linq;
using App.DAL;
using App.DAL.Entities;
using App.DAL.QueryObjects;
using App.DAL.QueryObjects.Filters;
using App.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using EFDb.Context;
using EFDb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly ILogger<CommodityController> _logger;
        private readonly CommodityRepository _commodityRepository;
        private readonly EshopContext _db;

        public CommodityController(ILogger<CommodityController> logger, CommodityRepository commodityRepository, EshopContext db)
        {
            _logger = logger;
            _db = db;
            
            if (commodityRepository is CommodityRepository commRep)
                _commodityRepository = commRep;
        }

        private bool ValidateApiVersion(ApiVersion version)
        {
            return !((ApiVersionAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(ApiVersionAttribute)))
                .Versions.Any(x => x == version);
        }

        [HttpGet(Name = nameof(Get))]
        public ActionResult<IEnumerable<CommodityEntity>> Get(ApiVersion version, [FromQuery] QueryParameters par)
        {
            if (ValidateApiVersion(version))
                return BadRequest();

            return Ok();
        }
        
        [HttpGet]
        [Route("{id:Guid}", Name = nameof(GetSingleCommodity))]
        public ActionResult<CommodityEntity> GetSingleCommodity(ApiVersion version, Guid id)
        {
            Commodity com = null;
            CommodityEntity commodityItem = null;
            try
            {
                com = _db.Comodities.Single(x => x.ID == id);
            }
            catch (InvalidOperationException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
            if (com is default(Commodity))
                return NotFound();

            commodityItem = new CommodityEntity()
            {
                Id = com.ID,
                Description = com.Description,
                Reviews = new List<ReviewEntity>(),
                Weight = com.Weight,
                Name = com.Name,
                Category = "",
                Image = com.ImagePath,
                Manufacturer = "",
                Price = com.Price,
                NumberOfPiecesInStock = com.NumberOfPiecesInStock
            };
            
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
            if (ValidateApiVersion(version))
                return new BadRequestResult();

            var ret = _db.Comodities.Add(new Commodity()
            {
                Category = new Category() {Name = "Ahoj", ID = Guid.NewGuid()},
                Weight = commodityCreateDto.Weight,
                Name = commodityCreateDto.Name,
                Description = commodityCreateDto.Description,
                ImagePath = commodityCreateDto.Image,
                Manufacturer = new Manufacturer() {Name = "Ahoj", ID = Guid.NewGuid()},
                Price = commodityCreateDto.Price,
                Reviews = new List<Review>(),
                NumberOfPiecesInStock = commodityCreateDto.NumberOfPiecesInStock
            });
            _db.SaveChanges();

            var newG = ret.Entity.ID;
            
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
           return newG.ToString();
#else
            return Ok();
#endif
        }
    }
}