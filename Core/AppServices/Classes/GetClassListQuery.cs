using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Data.Entities;
using Core.Helpers;

namespace Core.AppServices.Classes
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
                return _context.Classes.ToList().OrderBy(x=>Helper.GetClassNumberFromClassName(x.Name)).ToList();
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