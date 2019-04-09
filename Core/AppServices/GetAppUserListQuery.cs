using System.Collections.Generic;
using System.Linq;
using Core.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.AppServices
{
    public sealed class GetAppUserListQuery : IQuery<List<ApplicationUser>>
    {
        public string Role { get;}

        public GetAppUserListQuery(string role ="")
        {
            Role = role;
        }
        public class GetListQueryHandler : IQueryHandler<GetAppUserListQuery, List<ApplicationUser>>
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public GetListQueryHandler(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            public List<ApplicationUser> Handle(GetAppUserListQuery query)
            {
                if (string.IsNullOrWhiteSpace(query.Role))
                {
                    return _userManager.Users.ToList();
                }

                return _userManager.Users.Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                    .Where(x => x.UserRoles.Any(c => c.Role.Name == query.Role)).ToList();
            }
        }
    }
}
