using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Data.Entities;

namespace Core.AppServices
{
    public sealed class GetExerciseListQuery : IQuery<List<Exercise>> 
    {
        public class GetExerciseListQueryHandler : IQueryHandler<GetExerciseListQuery, List<Exercise>>
        {
            private readonly PeSportsTrackingContext _context;

            public GetExerciseListQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public List<Exercise> Handle(GetExerciseListQuery query )
            {
                return _context.Exercises.ToList();
            }
        }
    }
}