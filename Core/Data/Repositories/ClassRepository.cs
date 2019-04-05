using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data.Entities;

namespace WebApplication2.Data.Repositories
{
    public interface IClassRepository
    {
        IEnumerable<SchoolClass> GetAllClasses();
        SchoolClass GetById(int classId);
    }

    public class ClassRepository : IClassRepository
    {
        private readonly PeSportsTrackingContext _context;

        public ClassRepository(PeSportsTrackingContext context)
        {
            _context = context;
        }
        public IEnumerable<SchoolClass> GetAllClasses()
        {
            return _context.Classes;
        }

        public SchoolClass GetById(int classId)
        {
            return _context.Classes.Include(x=>x.Students).FirstOrDefault(x=>x.Id == classId);
        }
    }
}