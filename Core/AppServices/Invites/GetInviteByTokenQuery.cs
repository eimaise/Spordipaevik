using System.Linq;
using Core.Data;

namespace Core.AppServices.Invite
{
    public sealed class GetInviteByTokenQuery : IQuery<Data.Entities.Invite>
    {
        public GetInviteByTokenQuery(string token)
        {
            Token = token;
        }

        public string Token { get; }

        public class GetInviteByTokenQueryHandler : IQueryHandler<GetInviteByTokenQuery, Data.Entities.Invite>
        {
            private readonly PeSportsTrackingContext _context;

            public GetInviteByTokenQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Data.Entities.Invite Handle(GetInviteByTokenQuery query)
            {
                return _context.Invites.FirstOrDefault(x => x.Token == query.Token);
            }
        }
    }
}