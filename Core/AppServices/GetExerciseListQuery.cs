using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Data.Entities;

namespace Core.AppServices
{
    public sealed class GetExerciseListQuery : IQuery<List<Exercise>> 
    {
        public string Name { get; set; }

        public GetExerciseListQuery(string name="")
        {
            Name = name;
        }
        public class GetExerciseListQueryHandler : IQueryHandler<GetExerciseListQuery, List<Exercise>>
        {
            private readonly PeSportsTrackingContext _context;

            public GetExerciseListQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public List<Exercise> Handle(GetExerciseListQuery query)
            {
                if (string.IsNullOrWhiteSpace(query.Name))
                {
                    return _context.Exercises.ToList();
                }
                return _context.Exercises.Where(x=>x.Name.Contains(query.Name,StringComparison.CurrentCultureIgnoreCase)
                                                   || x.Comment.Contains(query.Name,StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }
        }
    }
}