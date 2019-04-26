using System.Linq;
using Core.Data.Entities;
using WebApplication2.ViewModels.Results;
using WebApplication2.ViewModels.Students;

namespace WebApplication2.Mappers
{
    public interface IResultMapper
    {
        ResultVm ToResultVm(int gender, SchoolClass aclass, Exercise exercise);
        LeaderBoardResultVm ToLeaderBoardResultVm(Result result);
    }

    public class ResultMapper : IResultMapper
    {
        public ResultVm ToResultVm(int gender, SchoolClass aclass, Exercise exercise)
        {
            var model = new ResultVm
            {
                ClassId = aclass.Id,
                ExerciseId = exercise.Id,
                ClassName = aclass.Name,
                ExerciseName = exercise.Name,
                IsTime = exercise.Unit.IsTime,
                Students = aclass.Students.Where(x => x.Gender == (Gender) gender).Select(x => new StudentVm
                {
                    Name = x.Name,
                    Id = x.Id,
                    Results = x.Results.Where(r => r.IsTodaysResult && r.ExerciseId == exercise.Id)
                        .Select(o => new StudentVm.ResultVm
                        {
                            Id = o.Id,
                            ResultValue = o.ResultValue.Value.ToString()
                        }).ToList(),
                    BestResult = x.Results.Where(r => r.ExerciseId == exercise.Id && !r.IsTodaysResult)
                        .OrderByDescending(r => r.ResultValue.Value).Select(r => r.ResultValue.Value.ToString())
                        .FirstOrDefault()
                }).ToList()
            };
            return model;
        }

        public LeaderBoardResultVm ToLeaderBoardResultVm(Result result)
        {
            return new LeaderBoardResultVm
            {
                ResultValue = result.ResultValue.Value,
                Name = result.Student.Name,
                DateTime = result.CreatedOn,
            };
        }
    }
}