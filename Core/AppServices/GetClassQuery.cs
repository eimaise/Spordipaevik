using Core.Data;
using WebApplication2.Data.Entities;

namespace Core.AppServices
{
    public sealed class GetClassQuery : IQuery<SchoolClass> 
    {
        public GetClassQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }


        public class GetClassQueryHandler : IQueryHandler<GetClassQuery, SchoolClass>
        {
            private readonly PeSportsTrackingContext _context;

            public GetClassQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public SchoolClass Handle(GetClassQuery query)
            {
                return _context.Classes.Find(query.Id);
            }
        }
    }
}