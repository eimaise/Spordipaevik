using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data.Entities;

namespace WebApplication2.Services
{
    public interface IResultService
    {
        HashSet<DateTime> GetUniqueDates(IEnumerable<Result> results);
    }

    public class ResultService : IResultService
    {
        public HashSet<DateTime> GetUniqueDates(IEnumerable<Result> results)
        {
            return results.OrderBy(x => x.CreatedOn.Date).Select(x=>x.CreatedOn.Date).Distinct().ToHashSet();
        } 
    }
}