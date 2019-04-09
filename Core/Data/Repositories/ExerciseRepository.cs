using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;
using WebApplication2.Data.Entities;

namespace WebApplication2.Data.Repositories
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise>GetAllExercises();
        void AddExercise(Exercise excersice);
        Exercise GetById(int exerciseId);
    }

    public class ExerciseRepository : IExerciseRepository
    {
        private readonly PeSportsTrackingContext _context;

        public ExerciseRepository(PeSportsTrackingContext context)
        {
            _context = context;
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
            return _context.Exercises;
        }

        public void AddExercise(Exercise excersice)
        {
            _context.Exercises.Add(excersice);
            _context.SaveChanges();
        }

        public Exercise GetById(int exerciseId)
        {
             return  _context.Exercises.FirstOrDefault(x => x.Id == exerciseId);
        }
    }
}