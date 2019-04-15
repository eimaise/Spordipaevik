using System.Collections.Generic;
using Core.Data.Entities;
using WebApplication2.ViewModels.Results;

namespace WebApplication2.ViewModels.Students
{
    public class StudentVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<ResultVm> Results { get; set; } = new List<ResultVm>();
        public string BestResult { get; set; }

        public class ResultVm
        {
            public int Id { get; set; }
            public string ResultValue { get; set; }
        }
    }
}