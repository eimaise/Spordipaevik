using System.Collections.Generic;

namespace WebApplication2.ViewModels.Results
{
    public class LeaderBoardResultListVm
    {
        public int Year { get; set; }
        public int ExerciseId { get; set; }
        public int ClassNumber { get; set; }
        public int Gender { get; set; }
        public List<LeaderBoardResultVm> LeaderBoardResult = new List<LeaderBoardResultVm>();
    }
}