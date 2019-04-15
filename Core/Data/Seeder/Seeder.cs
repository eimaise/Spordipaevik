using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace Core.Data.Seeder
{
    public class Seeder
    {
        private readonly PeSportsTrackingContext _ctx;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public Seeder(PeSportsTrackingContext ctx, IHostingEnvironment hostingEnvironment,
            UserManager<ApplicationUser> userManager,
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

            await SeedApplicationUsers();


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

        private async Task SeedApplicationUsers()
        {
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
                var student = new ApplicationUser()
                {
                    Email = "student@student.com",
                    UserName = "student",
                    Name = "Student Kask"
                };
                var appUser = await _userManager.CreateAsync(user, "Admin");
                if (appUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }

                var appTeacher = await _userManager.CreateAsync(teacher, "Admin");
                if (appTeacher.Succeeded)
                {
                    await _userManager.AddToRoleAsync(teacher, "Teacher");
                }
                var appStudent = await _userManager.CreateAsync(student, "Admin");
                if (appStudent.Succeeded)
                {
                    await _userManager.AddToRoleAsync(student, "Student");
                }
            }
        }

        private void AddResults()
        {
            var classes = _ctx.Classes;
            var longJump = _ctx.Exercises.FirstOrDefault(x => x.Name == "Kaugushüpe");
            var ballThrow = _ctx.Exercises.FirstOrDefault(x => x.Name == "Pallivise");

            foreach (var schoolClass in classes)
            {
                foreach (var student in schoolClass.Students)
                {
                    AddResultToStudent(student, longJump, Helpers.GetClassNumberFromClassName(schoolClass.Name));
                }
            }
        }

        private void AddResultToStudent(Student student, Exercise exercise, int years)
        {
            Random random = new Random();
            var exractTime = 6;
            for (int i = years * 2; i > 0; i--)
            {
                var value = new decimal(i / 3 + random.Next(2, 3) + random.NextDouble());
                value = Math.Round(value, 2);
                var result = new Result(student, exercise.Id, new ResultValue(exercise.Unit.Name, value),
                    DateTime.Now.AddMonths(-exractTime));
                exractTime = exractTime + 4;
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
            for (int i = 1; i < 13; i++)
            {
                var schoolClassA = new SchoolClass
                {
                    Name = i + ("A")
                };
                var schoolClassB = new SchoolClass
                {
                    Name = i + ("B")
                };
                var schoolClassC = new SchoolClass
                {
                    Name = i + ("C")
                };
                _ctx.Classes.AddAsync(schoolClassA);
                _ctx.Classes.AddAsync(schoolClassB);
                _ctx.Classes.AddAsync(schoolClassC);
            }
        }

        private void AddExercise()
        {
            var longJump = new Exercise("Kaugushüpe", _ctx.Units.FirstOrDefault(x => x.Name == "Meeter").Id);
            var highJump = new Exercise("Kõrgushüpe", _ctx.Units.FirstOrDefault(x => x.Name == "Meeter").Id);
            var runOneHundred = new Exercise("100m jooks", _ctx.Units.FirstOrDefault(x => x.Name == "Sekund").Id);
            var pushUps = new Exercise("Kätekõverdused", _ctx.Units.FirstOrDefault(x => x.Name == "Kordus").Id);
            var freeThrows = new Exercise("Vabavisked", _ctx.Units.FirstOrDefault(x => x.Name == "Kordus").Id,
                "Vabavisked 1 minuti jooksul");
            var ballThrow = new Exercise("Pallivise", _ctx.Units.FirstOrDefault(x => x.Name == "Meeter").Id);
            var jumps = new Exercise("Hüppenööriga hüpped", _ctx.Units.FirstOrDefault(x => x.Name == "Kordus").Id,
                "Hüppenööriga hüpped ühe minuti jooksul");

            _ctx.Exercises.AddRange(longJump, highJump, runOneHundred, pushUps, freeThrows, ballThrow, jumps);
        }

        private void AddStudents()
        {
            IEnumerable<Student> CreateClassStudents(string className, int classId)
            {
                var random = new Random();

                var studentMariMets = new Student
                {
                    Name = $"Marti Mets-{className}",
                    StudentCardNumber = GenerateRandomStudentCardNumber(random),
                    SchoolClassId = classId,
                    Gender = Gender.Man
                };
                var studentSiimSepp = new Student
                {
                    Name = $"Siim Sepp-{className}",
                    StudentCardNumber = GenerateRandomStudentCardNumber(random),
                    SchoolClassId = classId,
                    Gender = Gender.Man
                };
                var studentKalleAade = new Student
                {
                    Name = $"Kalle Aadu-{className}",
                    StudentCardNumber = GenerateRandomStudentCardNumber(random),
                    SchoolClassId = classId,
                    Gender = Gender.Man
                };
                var studentMartin = new Student
                {
                    Name = $"Martin Mees-{className}",
                    StudentCardNumber = GenerateRandomStudentCardNumber(random),
                    SchoolClassId = classId,
                    Gender = Gender.Man
                };
                var studentRauno = new Student
                {
                    Name = $"Rauno Toomingas-{className}",
                    StudentCardNumber = GenerateRandomStudentCardNumber(random),
                    SchoolClassId = classId,
                    Gender = Gender.Man
                };
                var studentSven = new Student
                {
                    Name = $"Sven Artusoo-{className}",
                    StudentCardNumber = GenerateRandomStudentCardNumber(random),
                    SchoolClassId = classId,
                    Gender = Gender.Man
                };
                var studentKardo = new Student
                {
                    Name = $"Kardo Valk-{className}",
                    StudentCardNumber = GenerateRandomStudentCardNumber(random),
                    SchoolClassId = classId,
                    Gender = Gender.Man
                };
                var studentKaspar = new Student
                {
                    Name = $"Kaspar Vägilane-{className}",
                    StudentCardNumber = GenerateRandomStudentCardNumber(random),
                    SchoolClassId = classId,
                    Gender = Gender.Man
                };
                var studentMeelis = new Student
                {
                    Name = $"Meelis Veis -{className}",
                    StudentCardNumber = GenerateRandomStudentCardNumber(random),
                    SchoolClassId = classId,
                    Gender = Gender.Man
                };
                var studentTiitSusi = new Student
                {
                    Name = $"Tiit Susi {className}",
                    StudentCardNumber = GenerateRandomStudentCardNumber(random),
                    SchoolClassId = classId,
                    Gender = Gender.Man
                };
                var studentMariMaasikas = new Student
                {
                    Name = $"Mari Maasikas {className}",
                    StudentCardNumber = GenerateRandomStudentCardNumber(random),
                    SchoolClassId = classId,
                    Gender = Gender.Woman
                };
                var studentTiinaPaju3 = new Student
                {
                    Name = $"Tiina Paju {className}",
                    StudentCardNumber = GenerateRandomStudentCardNumber(random),
                    SchoolClassId = classId,
                    Gender = Gender.Woman
                };
                return new[]
                {
                    studentMariMets, studentTiitSusi, studentMariMaasikas, studentTiinaPaju3, studentSiimSepp,
                    studentKalleAade,
                    studentMartin, studentRauno, studentSven, studentKaspar, studentKardo, studentMeelis
                };
            }

            var classes = _ctx.Classes;
            var students = new List<Student>();
            foreach (var schoolClass in classes)
            {
                students.AddRange(CreateClassStudents(schoolClass.Name, schoolClass.Id));
            }

            _ctx.Students.AddRange(students);

            string GenerateRandomStudentCardNumber(Random random)
            {
                return random.Next(100000, 999999).ToString();
            }
        }
    }
}