using System.Linq;
using Core.Data;
using Core.Data.Entities;

namespace Core.AppServices
{
    public sealed class GetInviteQuery : IQuery<Invite> 
    {
        public GetInviteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }

        internal sealed class GetInviteQueryHandler : IQueryHandler<GetInviteQuery, Invite>
        {
            private readonly PeSportsTrackingContext _context;

            public GetInviteQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Invite Handle(GetInviteQuery query)
            {
                return _context.Invites.Find(query.Id);
            }
        }
    }
    public sealed class GetInviteByTokenQuery : IQuery<Invite> 
    {
        public GetInviteByTokenQuery(string token)
        {
            Token = token;
        }

        public string Token { get; }

        public class GetInviteByTokenQueryHandler : IQueryHandler<GetInviteByTokenQuery, Invite>
        {
            private readonly PeSportsTrackingContext _context;

            public GetInviteByTokenQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Invite Handle(GetInviteByTokenQuery query)
            {
                return _context.Invites.FirstOrDefault(x => x.Token == query.Token);
            }
        }
    }
}