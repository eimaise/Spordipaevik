using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;

namespace Core.AppServices.Students
{
    public sealed class GetStudentListQuery : IQuery<List<Data.Entities.Student>>
    {
        public GetStudentListQuery(bool? registeredInSystem = null, string name = "")
        {
            RegisteredInSystem = registeredInSystem;
            Name = name;
        }

        public bool? RegisteredInSystem { get; }
        public string Name { get; }

       public class GetStudentListQueryHandler : IQueryHandler<GetStudentListQuery, List<Data.Entities.Student>>
        {
            private readonly PeSportsTrackingContext _context;

            public GetStudentListQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public List<Data.Entities.Student> Handle(GetStudentListQuery query)
            {
                IQueryable<Data.Entities.Student> students = _context.Students;
                if (!string.IsNullOrWhiteSpace(query.Name))
                {
                    students = students.Where(x => x.Name.Contains(query.Name,StringComparison.InvariantCultureIgnoreCase));
                }

                if (query.RegisteredInSystem != null)
                {
                    students = students.Where(x => x.RegisteredInSystem == query.RegisteredInSystem);
                }

                return students.ToList();
            }
        }
    }
}
