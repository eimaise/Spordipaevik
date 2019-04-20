using System.Collections.Generic;
using System.Linq;
using Core.Data.Entities;
using WebApplication2.Controllers;

namespace WebApplication2.Services
{
    public interface IChartDataService
    {
        ChartDataList CreateChartDatalist(List<Result> results);
    }

    public class ChartDataService : IChartDataService
    {
        private readonly IResultService _resultService;

        public ChartDataService(IResultService resultService)
        {
            _resultService = resultService;
        }

        public ChartDataList CreateChartDatalist(List<Result> results)
        {
            var cData = new ChartDataList();
            var uniqueDates = _resultService.GetUniqueDates(results);
            var students = results.Select(x => x.Student.Name).Distinct().ToList();
            //for getting biggest value
            results = results.OrderByDescending(x => x.ResultValue.Value).ToList();
            cData.Dates = uniqueDates.Select(x => x.Date.ToShortDateString()).ToList();
            foreach (var date in uniqueDates)
            {
                var resultsInDate = results.Where(x => x.CreatedOn.Date == date).ToList();
                foreach (var student in students)
                {
                    var studentResult = resultsInDate.FirstOrDefault(x => x.Student.Name == student);
                    if (studentResult == null)
                    {
                        var chartData = cData.ChartData.FirstOrDefault(x => x.Name == student);
                        if (chartData == null)
                        {
                            var chartDataloc = new ChartData
                            {
                                Name = student,
                            };
                            chartDataloc.Results.Add(null);
                            cData.ChartData.Add(chartDataloc);
                        }
                        else
                        {
                            chartData.Results.Add(null);
                        }
                    }
                    else
                    {
                        var chartData = cData.ChartData.FirstOrDefault(x => x.Name == student);
                        if (chartData == null)
                        {
                            var chartDataloc = new ChartData
                            {
                                Name = student,
                            };
                            chartDataloc.Results.Add(studentResult.ResultValue.Value);
                            cData.ChartData.Add(chartDataloc);
                        }
                        else
                        {
                            chartData.Results.Add(studentResult.ResultValue.Value);
                        }
                    }
                }
            }

            return cData;
        }
    }

    public class ChartDataList
    {
        public List<string> Dates { get; set; } = new List<string>();
        public List<ChartData> ChartData { get; set; } = new List<ChartData>();
    }

    public class ChartData
    {
        public string Name { get; set; }
        public List<decimal?> Results { get; set; } = new List<decimal?>();
    }
}