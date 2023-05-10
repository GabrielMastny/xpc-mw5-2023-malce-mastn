using System;
using System.Collections.Generic;
using System.Linq;
using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.API.Dtos;
using Eshop.DAL.QueryObjects;
using Eshop.DAL.QueryObjects.Filters;
using Eshop.DAL.Repositories;
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
        public ActionResult<IEnumerable<CommodityEntity>> Get(ApiVersion version)
        {
            
            //return Ok(_repo.Get().Select(x => _mapper.Map<CommodityBriefDto>(x)));
            return Ok();
        }
        
        [HttpGet]
        [Route("{id:Guid}", Name = nameof(GetSingleCommodity))]
        public ActionResult<CommodityDto> GetSingleCommodity(ApiVersion version, Guid id)
        {
            //return _mapper.Map<CommodityDto>(_repo.Get().Single(x => x.Id == id));
            return new OkResult();
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
            var results = _query.Execute(commodityDataFilter);
            List<CommodityEntity> names = new List<CommodityEntity>();
            foreach (var r in results)
            {
                names.Add(r);
            }
            return names;
        }
    }
}