using System.Collections.Generic;
using System.Linq;
using Core.Data.Entities;
using WebApplication2.ViewModels.Exercises;

namespace WebApplication2.Mappers
{
    public interface IExerciseMapper
    {
        List<ExerciseVm> ToExerciseListVm(List<Exercise> exercises);
    }

    public class ExerciseMapper : IExerciseMapper
    {
        public List<ExerciseVm> ToExerciseListVm(List<Exercise> exercises)
        {
            return exercises.Select(x => new ExerciseVm
            {
                Id = x.Id,
                Name = x.Name,
                Comment = x.Comment
            }).ToList();
        }
    }
}