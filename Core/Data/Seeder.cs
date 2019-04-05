using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Data.Entities;

namespace Core.Data
{
    public class Seeder
    {
        private readonly PeSportsTrackingContext _ctx;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        
        public Seeder(PeSportsTrackingContext ctx,IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _ctx = ctx;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureDeleted();

            _ctx.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("admin@admin.ee");
            if (user == null)
            {
                bool adminRoleExits = await _roleManager.RoleExistsAsync("Admin");
                if (!adminRoleExits)
                {
                    var role = new ApplicationRole();
                    role.Name = "Admin";
                    await _roleManager.CreateAsync(role);
                }
                bool teacherRoleExits = await _roleManager.RoleExistsAsync("Teacher");
                if (!teacherRoleExits)
                {
                    var role = new ApplicationRole();
                    role.Name = "Teacher";
                    await _roleManager.CreateAsync(role);
                }
                bool studentRoleExists = await _roleManager.RoleExistsAsync("Student");
                if (!studentRoleExists)
                {
                    var role = new ApplicationRole();
                    role.Name = "Student";
                    await _roleManager.CreateAsync(role);
                }
                
                user = new ApplicationUser()
                {
                    Email = "admin@admin.com",
                    UserName = "admin",
                    Name = "Admin Pihlakas"
                };
                var teacher = new ApplicationUser()
                {
                    Email = "teacher@teacher.com",
                    UserName = "teacher",
                    Name = "Õpetaja Kask"
                };
                var appUser =  await _userManager.CreateAsync(user,"Admin");
                if (appUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                var appTeacher =  await _userManager.CreateAsync(teacher,"Admin");
                if (appTeacher.Succeeded)
                {
                    await _userManager.AddToRoleAsync(teacher, "Teacher");
                }
            }

           
            if (!_ctx.Units.Any())
            {
                AddUnits();
                _ctx.SaveChanges();
            }
            if (!_ctx.Exercises.Any())
            {
                AddExercise();
                _ctx.SaveChanges();
            }
            if (!_ctx.Classes.Any())
            {
                AddClasses();
                _ctx.SaveChanges();
            }
            if (!_ctx.Students.Any())
            {
                AddStudents();
                _ctx.SaveChanges();
            }
            if (!_ctx.Results.Any())
            {
                AddResults();
                _ctx.SaveChanges();
            }
            
            
            if (!_ctx.Persons.Any())
            {
                // create sample data
//                var filepath = Path.Combine(_hostingEnvironment.ContentRootPath, "Data/smt.json");
//                var json = File.ReadAllText(filepath);
//                var persons = JsonConvert.DeserializeObject<IEnumerable<ApplicationUser>>(json);
//                _ctx.Persons.AddRange(persons);
                _ctx.SaveChanges();
            }
        }

        private void AddResults()
        {
           var marti =  _ctx.Students.FirstOrDefault(x => x.Name == "Marti Mets 4A");
           var tiit = _ctx.Students.FirstOrDefault(x => x.Name == "Tiit Susi 4A");
           var mari = _ctx.Students.FirstOrDefault(x => x.Name == "Mari Maasikas 4A");
           var tiina = _ctx.Students.FirstOrDefault(x => x.Name == "Tiina Paju 4A");
           var longJump = _ctx.Exercises.FirstOrDefault(x => x.Name == "Kaugushüpe");

           AddResultToStudent(marti,longJump);
           AddResultToStudent(tiit,longJump);
           AddResultToStudent(mari,longJump);
           AddResultToStudent(tiina,longJump);
        }

        private void AddResultToStudent(Student student,Exercise exercise)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var value = new decimal(rnd.NextDouble() +i);
                var result = new Result
                {
                    Value = value,
                    StudentId = student.Id,
                    ExerciseId = exercise.Id,
                    CreatedOn = DateTime.Today.AddMonths(-i),
                    ClassName = "4A",
                };
                _ctx.Results.Add(result);
            }
            
        }

        private void AddUnits()
        {
            _ctx.Add(Unit.CreateValueUnit("Meeter"));
            _ctx.Add(Unit.CreateValueUnit("Kilomeeter"));
            _ctx.Add(Unit.CreateValueUnit("Cm"));
            _ctx.Add(Unit.CreateValueUnit("Kordus"));
            _ctx.Add(Unit.CreateTimeUnit("Sekund"));
            _ctx.Add(Unit.CreateTimeUnit("Minut"));
            _ctx.Add(Unit.CreateTimeUnit("Tund"));

        }
        private void AddClasses()
        {
            var class4B = new SchoolClass
            {
                Name = "4B"
            };
            var class5C = new SchoolClass
            {
                Name = "5C"
            };
            var class4A = new SchoolClass
            {
                Name = "4A"
            };
            var class6A = new SchoolClass
            {
                Name = "6A"
            };
            _ctx.Classes.AddRange(class4B,class4A,class5C,class6A);
        }

        private void AddExercise()
        {
            var longJump = new Exercise(_ctx.Units.FirstOrDefault(x=>x.Name=="Meeter").Id)
            {
                Name = "Kaugushüpe",
            };
            var highJump = new Exercise(_ctx.Units.FirstOrDefault(x=>x.Name=="Meeter").Id)
            {
                Name = "Kõrgushüpe",
            };
            var run100m = new Exercise(_ctx.Units.FirstOrDefault(x=>x.Name=="Sekund").Id)
            {
                Name = "100m jooks",
            };
            var pushUps = new Exercise(_ctx.Units.FirstOrDefault(x=>x.Name=="Kordus").Id)
            {
                Name = "Kätekõverdused",
            };

            _ctx.Exercises.AddRange(longJump,highJump,run100m,pushUps);
        }

        private void AddStudents()
        {
            var class4A = _ctx.Classes.FirstOrDefault(x=>x.Name == "4A");
            var class4B = _ctx.Classes.FirstOrDefault(x=>x.Name == "4B");
            var class5C = _ctx.Classes.FirstOrDefault(x=>x.Name == "5C");
            var class6A = _ctx.Classes.FirstOrDefault(x=>x.Name == "6A");

            
            IEnumerable<Student> CreateClassStudents(string className, int classId)
            {
                var studentMariMets = new Student
                {
                    Name = $"Marti Mets {className}",
                    StudentCardNumber = $"st number Marti Mets {className}",
                    SchoolClassId = classId,
                    Gender = Gender.Man
                };

                var studentTiitSusi = new Student
                {
                    Name = $"Tiit Susi {className}",
                    StudentCardNumber = $"st number Tiit Susi {className}",
                    SchoolClassId = classId,
                    Gender = Gender.Man
                };
                var studentMariMaasikas = new Student
                {
                    Name = $"Mari Maasikas {className}",
                    StudentCardNumber = $"st number Mari Maasikas {className}",
                    SchoolClassId = classId,
                    Gender = Gender.Woman
                };
                var studentTiinaPaju3 = new Student
                {
                    Name = $"Tiina Paju {className}",
                    StudentCardNumber = $"st number Tiina Paju {className} ",
                    SchoolClassId = classId,
                    Gender = Gender.Woman
                };
                return new[] {studentMariMets, studentTiitSusi, studentMariMaasikas, studentTiinaPaju3};
            }

            var students4A = CreateClassStudents("4A", class4A.Id);
            var students4B = CreateClassStudents("4B", class4B.Id);
            var students5C = CreateClassStudents("5C", class5C.Id);
            var students6A = CreateClassStudents("6A", class6A.Id);

            _ctx.Students.AddRange(students4A);
            _ctx.Students.AddRange(students4B);
            _ctx.Students.AddRange(students5C);
            _ctx.Students.AddRange(students6A);

        }
    }
}