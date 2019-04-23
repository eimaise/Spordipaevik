using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.ViewModels.Exercises
{
    public class LeaderboardListVm
    {

        public List<ExerciseVm> Exercises { get; set; } = new List<ExerciseVm>();
        public List<int> Classes { get; private set; } = new[] {1,2,3,4,5,6,7,8,9,10,11,11,12}.ToList();

        public int SelectedClassId { get; set; }
    }
}