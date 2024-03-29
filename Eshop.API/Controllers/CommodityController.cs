﻿using System;
using System.Collections.Generic;
using System.Linq;
using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.API.Dtos;
using Eshop.DAL.QueryObjects;
using Eshop.DAL.QueryObjects.Filters;
using Eshop.DAL.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eshop.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly ILogger<CommodityController> _logger;
        private readonly IRepository<CommodityEntity> _repo;
        private readonly IMapper _mapper;
        private readonly GetCommoditiesByCommodityDataFilterQuery _query;
        public CommodityController(ILogger<CommodityController> logger, IRepository<CommodityEntity> repo, IMapper mapper, GetCommoditiesByCommodityDataFilterQuery query)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
            _query = query;
        }

        [HttpGet(Name = "GetCommodities")]
        public IActionResult Get(ApiVersion version)
        {
            var filtered = _query.Execute(new CommodityDataFilter()).ToList();

            if (!filtered.Any())
            {
                return new EmptyResult();
            }
            else
            {
                return Ok(filtered.Select(x => _mapper.Map<CommodityDto>(x)));
            }
        }
        
        [HttpGet]
        [Route("{id:Guid}", Name = nameof(GetSingleCommodity))]
        public ActionResult<CommodityDto> GetSingleCommodity(ApiVersion version, Guid id)
        {
            return new OkObjectResult(_mapper.Map<CommodityDto>(_repo.GetById(id)));
        }

        [HttpPost(Name = nameof(AddCommodity))]
        public ActionResult<Guid> AddCommodity(ApiVersion version, [FromBody] CommodityCreateDto commodityCreateDto)
        {
            var ent = _mapper.Map<CommodityEntity>(commodityCreateDto);
            var newG = _repo.Create(ent);
            return  new OkObjectResult(newG);
        }
        
        [HttpDelete]
        [Route("{id:Guid}", Name = nameof(RemoveCommodity))]
        public ActionResult RemoveCommodity(Guid id)
        {
            _repo.Delete(id);

            return new OkResult();
        }
        
        [HttpPost]
        [Route($"[action]")]
        public ActionResult<List<CommodityEntity>> FilterCommodity(ApiVersion version, CommodityDataFilter commodityDataFilter)
        {
            return _query.Execute(commodityDataFilter).ToList();
        }
    }
}