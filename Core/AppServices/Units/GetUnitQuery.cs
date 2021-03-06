using Core.Data;
using Core.Data.Entities;

namespace Core.AppServices.Units
{
    public sealed class GetUnitQuery : IQuery<Unit> 
    {
        public GetUnitQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }


        public class GetUnitQueryHandler : IQueryHandler<GetUnitQuery, Unit>
        {
            private readonly PeSportsTrackingContext _context;

            public GetUnitQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Unit Handle(GetUnitQuery query)
            {
                return _context.Units.Find(query.Id);
            }
        }
    }
}