using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Data.Entities;

namespace Core.AppServices
{
    //todo : sellele oleks kena testid ka 
    public sealed class GetStudentsResultsInExerciseQuery : IQuery<List<Result>> 
    {
        public List<int> StudentIds{ get; set; }
        public int ExerciseId { get; set; }

        public GetStudentsResultsInExerciseQuery(List<int> studentIds, int exerciseId)
        {
            StudentIds = studentIds;
            ExerciseId = exerciseId;
        }
        public class GetStudentsResultsInExerciseQueryHandler : IQueryHandler<GetStudentsResultsInExerciseQuery, List<Result>>
        {
            private readonly PeSportsTrackingContext _context;

            public GetStudentsResultsInExerciseQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public List<Result> Handle(GetStudentsResultsInExerciseQuery query )
            {
                return _context.Results.Where(x=>query.StudentIds.Contains(x.StudentId) && x.ExerciseId == query.ExerciseId).ToList();
            }
        }
    }
}