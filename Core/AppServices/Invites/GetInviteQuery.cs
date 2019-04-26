using Core.Data;

namespace Core.AppServices.Invites
{
    public sealed class GetInviteQuery : IQuery<Data.Entities.Invite> 
    {
        public GetInviteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public sealed class GetInviteQueryHandler : IQueryHandler<GetInviteQuery, Data.Entities.Invite>
        {
            private readonly PeSportsTrackingContext _context;

            public GetInviteQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Data.Entities.Invite Handle(GetInviteQuery query)
            {
                return _context.Invites.Find(query.Id);
            }
        }
    }
}