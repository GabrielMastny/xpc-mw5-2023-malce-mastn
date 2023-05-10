﻿using System;
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

namespace Eshop.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ReviewController
{
    private readonly ILogger<ReviewController> _logger;
    private readonly IRepository<ReviewEntity> _repo;
    private readonly IMapper _mapper;
    private readonly GetReviewsByReviewFilterQuery _query;
    public ReviewController(ILogger<ReviewController> logger, IRepository<ReviewEntity> repo, IMapper mapper, GetReviewsByReviewFilterQuery query)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
        _query = query;
    }
    
    [HttpGet(Name = "GetReviews")]
    public IEnumerable<ReviewDTO> Get()
    {
       // return _repo.Get().Select(x => _mapper.Map<ReviewDTO>(x));
       return null;
    }
    
    [HttpPost(Name = nameof(AddReview))]
    public ActionResult<string> AddReview(ApiVersion version, [FromBody] ReviewCreateDTO reviewCreateDto)
    {
        var newG = _repo.Create(_mapper.Map<ReviewEntity>(reviewCreateDto));
        
#if DEBUG
        return newG.ToString(); 
#else
        return (Guid.Empty == newG) ? new BadRequestResult() : new OkResult();
#endif
    }
    
    [HttpGet]
    [Route("{id:Guid}", Name = nameof(GetSingleReview))]
    public ActionResult<ReviewDTO> GetSingleReview(ApiVersion version, Guid id)
    {
        var rev =  _repo.GetById(id);
       
        if (Guid.Empty == rev.Id)
        {
            return new NotFoundResult();
        }
       
        return _mapper.Map<ReviewDTO>(rev);
    }

    [HttpPut]
    [Route("{id:Guid}", Name = nameof(UpdateReview))]
    public ActionResult<ReviewDTO> UpdateReview(ApiVersion version, Guid id, [FromBody] ReviewDTO ReviewDTO)
    {
        if (ReviewDTO == null)
            return new BadRequestResult();
        
        var rev = _repo.Update(_mapper.Map<ReviewEntity>(ReviewDTO));

        if (Guid.Empty == rev.Id)
            return new NotFoundResult();

        return _mapper.Map<ReviewDTO>(rev);
    }

    [HttpDelete]
    [Route("{id:Guid}", Name = nameof(RemoveReview))]
    public ActionResult RemoveReview(Guid id)
    {
        _repo.Delete(id);

        return new OkResult();
    }
    
    [HttpPost]
    [Route($"[action]")]
    public ActionResult<List<ReviewEntity>> FilterReview(ApiVersion version, ReviewFilter reviewFilter)
    {
        var results = _query.Execute(reviewFilter);
        List<ReviewEntity> names = new List<ReviewEntity>();
        foreach (var r in results)
        {
            names.Add(r);
        }
        return names;
    }
}