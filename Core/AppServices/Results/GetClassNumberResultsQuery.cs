using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Data.Entities;

namespace Core.AppServices.Results
{
    public sealed class GetClassNumberResultsQuery : IQuery<List<Result>> 
    {
        public GetClassNumberResultsQuery(int exerciseId, int classNumber, bool allResult)
        {
            ExerciseId = exerciseId;
            ClassNumber = classNumber;
            AllResults = allResult;
        }

        public bool AllResults { get; set; }

        public int ExerciseId { get; set; }
        public int ClassNumber{ get; set; }
        public class GetClassNumberResultsQueryHandler : IQueryHandler<GetClassNumberResultsQuery, List<Result>>
        {
            private readonly PeSportsTrackingContext _context;

            public GetClassNumberResultsQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public List<Result> Handle(GetClassNumberResultsQuery query)
            {
                if (query.AllResults)
                {
                    return _context.Results.Where(x=>x.ClassNumber == query.ClassNumber && x.ExerciseId == query.ExerciseId)
                        .OrderByDescending(x=>x.ResultValue.Value).ToList();
                }
                else
                {
                    return _context.Results.Where(x=>x.ClassNumber == query.ClassNumber
                                                     && x.ExerciseId == query.ExerciseId
                                                     && !x.Student.HiddenResults)
                        .OrderByDescending(x=>x.ResultValue.Value).ToList();

                }
            }
        }
    }
}