using Core.Data;
using Core.Data.Entities;

namespace Core.AppServices
{
    public sealed class GetResultQuery : IQuery<Result> 
    {
        public GetResultQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }


        public class GetResultQueryHandler : IQueryHandler<GetResultQuery, Result>
        {
            private readonly PeSportsTrackingContext _context;

            public GetResultQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Result Handle(GetResultQuery query)
            {
                return _context.Results.Find(query.Id);
            }
        }
    }
}