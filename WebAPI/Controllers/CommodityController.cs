using System;
using System.Collections.Generic;
using System.Linq;
using App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly ILogger<CommodityController> _logger;

        public CommodityController(ILogger<CommodityController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = nameof(Get))]
        public IEnumerable<CommodityEntity> Get()
        {
            return new List<CommodityEntity>();
        }
        
        [HttpGet]
        [Route("{id:int}", Name = nameof(GetSingleCommodity))]
        public ActionResult GetSingleCommodity(int id)
        {
            CommodityEntity commodityItem = null;

            if (commodityItem == null)
            {
                return NotFound();
            }

            

            return Ok();
        }

        [HttpPost(Name = nameof(AddCommodity))]
        public ActionResult AddCommodity()
        {
            return Ok();
        }
    }
}