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

        [HttpGet]
        public IEnumerable<CommodityEntity> Get()
        {
            var rng = new Random();
            return new List<CommodityEntity>();
        }
    }
}