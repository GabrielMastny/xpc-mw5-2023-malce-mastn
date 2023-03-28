using System.Collections;
using System.Collections.Generic;

namespace WebAPI.Models;

public class QueryParameters
{
    public QueryBase Query { get; set; }

    public string OrderBy { get; set; }
}

public abstract class QueryBase
{
    public QueryBase Next;

    public IEnumerable<object> Execute()
    {
        return new List<object>();
    }
}

public class Query : QueryBase
{
    
}