﻿using System;
using System.Collections.Generic;
using System.Linq;
using App.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly IRepository<CommodityEntity> _repo;
        private readonly IMapper _mapper;
        public CommodityController(ILogger<CommodityController> logger, IRepository<CommodityEntity> repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(Get))]
        public ActionResult<IEnumerable<CommodityEntity>> Get(ApiVersion version, [FromQuery] QueryParameters queryParameters)
        {
            
            return Ok(_repo.Get().Select(x => _mapper.Map<CommodityBriefDto>(x)));
        }
        
        [HttpGet]
        [Route("{id:Guid}", Name = nameof(GetSingleCommodity))]
        public ActionResult<CommodityDto> GetSingleCommodity(ApiVersion version, Guid id)
        {
            return _mapper.Map<CommodityDto>(_repo.Get().Single(x => x.Id == id));
        }

        [HttpPost(Name = nameof(AddCommodity))]
        public ActionResult<string> AddCommodity(ApiVersion version, [FromBody] CommodityCreateDto commodityCreateDto)
        {
            var ent = _mapper.Map<CommodityEntity>(commodityCreateDto);
            var newG = _repo.Create(ent);
#if DEBUG
            return newG.ToString();
#else
            return Ok();
#endif
        }
        
        
    }
}