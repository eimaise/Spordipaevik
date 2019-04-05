using System.Collections.Generic;
using System.Linq;
using Core.Data;
using WebApplication2.Data.Entities;

namespace Core.AppServices
{
    public sealed class GetUnitListQuery : IQuery<List<Unit>>
    {
        public class GetUnitListQueryHandler : IQueryHandler<GetUnitListQuery,List<Unit>>
        {
            private readonly PeSportsTrackingContext _context;

            public GetUnitListQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }
            public List<Unit> Handle(GetUnitListQuery query)
            {
                return _context.Units.ToList();
            }
        }
    }
}