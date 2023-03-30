﻿using System;
using System.Linq;
using App.DAL.Entities;
using CommonDbProperties.Interfaces;
using CommonDbProperties.Interfaces.Entities;
using CommonDbProperties.Interfaces.Repositories;

namespace App.DAL.Repositories;

public class CommodityRepository : IRepository<CommodityEntity>
{
    public Guid Create(CommodityEntity? entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));

        entity.Id = Guid.NewGuid();
        
        Database.Instance.Manufacturers.Single(m => m.Name == entity.Manufacturer.Name).ListOfCommodities.Add(entity);
        Database.Instance.Commodities.Add(entity);

        return entity.Id;
    }

    public IEnumerable<CommodityEntity> Get()
    {
        return Database.Instance.Commodities;
    }

    public CommodityEntity GetById(Guid id)
    {
        return Database.Instance.Commodities.Single(s => s.Id == id);
    }

    public CommodityEntity GetByName(string name)
    {
        if(name == null) throw new ArgumentNullException();
        return Database.Instance.Commodities.Single(s => s.Name == name);
    }

    public CommodityEntity Update(CommodityEntity? entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        
        var commodity = Database.Instance.Commodities.Single(s => s.Id == entity.Id);
        commodity.Name = entity.Name;
        return commodity;
    }

    public void Delete(Guid id)
    {
        if(!Database.Instance.Commodities.Any(c => c.Id == id)) throw new ArgumentException();
        
        var commodity = Database.Instance.Commodities.Single(s => s.Id == id);
        Database.Instance.Manufacturers.Single(m => m == commodity.Manufacturer).ListOfCommodities.Remove(commodity);
        foreach (var r in commodity.Reviews)
        {
            Database.Instance.Reviews.Remove(r);
        }
        Database.Instance.Commodities.Remove(commodity);
    }
}