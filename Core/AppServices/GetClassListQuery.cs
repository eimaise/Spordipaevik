using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Data.Entities;

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
}