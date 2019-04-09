using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NHibernate.Mapping.ByCode.Impl;

namespace Core.AppServices
{
    public sealed class GetStudentListQuery : IQuery<List<Student>>
    {
        public GetStudentListQuery(bool? registeredInSystem = null, string name = "")
        {
            RegisteredInSystem = registeredInSystem;
            Name = name;
        }

        public bool? RegisteredInSystem { get; }
        public string Name { get; }

       public class GetStudentListQueryHandler : IQueryHandler<GetStudentListQuery, List<Student>>
        {
            private readonly PeSportsTrackingContext _context;

            public GetStudentListQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public List<Student> Handle(GetStudentListQuery query)
            {
                IQueryable<Student> students = _context.Students;
                if (!string.IsNullOrWhiteSpace(query.Name))
                {
                    students = students.Where(x => x.Name.Contains(query.Name));
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
