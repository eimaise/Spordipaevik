using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data.Entities;
using WebApplication2.ViewModels;
using WebApplication2.ViewModels.Results;

namespace WebApplication2.Mappers
{
    public interface ISchoolClassMapper
    {
        List<ClassVm> ToClassVm(List<SchoolClass> classes);
        ClassResultVm ToClassResultVm(int exerciseId, int classId, int gender, HashSet<DateTime> resultUniqueDates);
    }

    public class SchoolClassMapper : ISchoolClassMapper
    {
        public List<ClassVm> ToClassVm(List<SchoolClass> classes)
        {
            var classesvm = classes.Select(x => new ClassVm
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();
            return classesvm;
        }

        public ClassResultVm ToClassResultVm(int exerciseId, int classId, int gender,
            HashSet<DateTime> resultUniqueDates)
        {
            return new ClassResultVm
            {
                SelectedExerciseId = exerciseId,
                ClassId = classId,
                Dates = resultUniqueDates.ToList(),
                Gender = gender
            };
        }
    }
}