using Core.Data;
using WebApplication2.Data.Entities;

namespace Core.AppServices
{
    public sealed class GetExerciseQuery : IQuery<Exercise> 
    {
        public GetExerciseQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }


        public class GetExerciseQueryHandler : IQueryHandler<GetExerciseQuery, Exercise>
        {
            private readonly PeSportsTrackingContext _context;

            public GetExerciseQueryHandler(PeSportsTrackingContext context)
            {
                _context = context;
            }

            public Exercise Handle(GetExerciseQuery query)
            {
                return _context.Exercises.Find(query.Id);
            }
        }
    }
}