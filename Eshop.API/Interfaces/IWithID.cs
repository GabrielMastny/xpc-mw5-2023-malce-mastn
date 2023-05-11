using System;

namespace Eshop.API.Interfaces;

public interface IWithId
{
    Guid Id { get; set; }
}