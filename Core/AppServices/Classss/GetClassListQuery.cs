using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Core.Data;
using Core.Data.Entities;
using Remotion.Linq.Clauses.ResultOperators;

namespace Core.AppServices
{
    public sealed class GetClassListQuery : IQuery<List<SchoolClass>> 
    {
        public class GetClassListQueryHandler : IQueryHandler<GetClassListQuery, List<SchoolClass>>
        {
            private readonly PeSportsTrackingContext _context;

            public GetClassListQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public List<SchoolClass> Handle(GetClassListQuery query )
            {
                return _context.Classes.ToList();
            }
        }
    }
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
    public class StudentComparer : IEqualityComparer<Result>
    {
        public bool Equals(Result x, Result y)
        {
            return x.StudentId == y.StudentId;
        }

        public int GetHashCode(Result obj)
        {
            return obj.StudentId.GetHashCode();
        }
    }
}