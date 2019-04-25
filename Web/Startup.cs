using System.Collections.Generic;
using Core;
using Core.AppServices;
using Core.Data;
using Core.Data.Entities;
using Core.Data.Seeder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Areas.Identity.Services;
using WebApplication2.Controllers;
using WebApplication2.Mappers;
using WebApplication2.Services;

namespace WebApplication2
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            Currentevironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        private IHostingEnvironment Currentevironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //            var connectionString = "server=(LocalDB)\\MSSQLLocalDB;Database=PeSportsTracker;Trusted_Connection=true;";
            services.AddTransient<Seeder>();
            services.AddScoped<ISecureTokenGenerator, SecureTokenGenerator>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();
            services.AddTransient<IChartDataService, ChartDataService>();
            services.AddTransient<IResultService, ResultService>();
            services.AddTransient<IStudentMapper, StudentMapper>();
            services.AddTransient<ITeacherMapper, TeacherMapper>();
            services.AddTransient<IEmailSender, EmailSender>();


            //core serviced peaks tõstma ümber
            CoreCommandAndQueryServicesShouldBeMoved();


            services.AddIdentity<ApplicationUser, IdentityRole>(
                    options =>
                    {
                        options.Stores.MaxLengthForKeys = 128;
                        options.Password = new PasswordOptions
                        {
                            RequiredLength = 0,
                            RequireNonAlphanumeric = false,
                            RequireDigit = false,
                            RequireLowercase = false,
                            RequireUppercase = false
                        };
                    })
                .AddEntityFrameworkStores<PeSportsTrackingContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<PeSportsTrackingContext>(o => o.UseNpgsql(
                Configuration.GetConnectionString("SportTracerConnectionString")).UseLazyLoadingProxies());

            //MS SQL SERVERI OMA 
            //services.AddDbContext<PeSportsTrackingContext>(o => o.UseSqlServer(
            //        Configuration.GetConnectionString("SportTracerConnectionString")).UseLazyLoadingProxies()
            //);

            void CoreCommandAndQueryServicesShouldBeMoved()
            {
                services.AddScoped<Messages>();
                services
                    .AddTransient<ICommandHandler<TeacherRegistrationCommand>,
                        TeacherRegistrationCommand.TeacherRegistrationCommandHandler>();
                services
                    .AddTransient<ICommandHandler<StudentInviteCommand>,
                        StudentInviteCommand.StudentInviteCommandHandler>();
                services
                    .AddTransient<ICommandHandler<UserRegisteredCommand>,
                        UserRegisteredCommand.InviteUsedCommandHandler>();
                services
                    .AddTransient<IQueryHandler<GetUnitQuery, Unit>,
                        GetUnitQuery.GetUnitQueryHandler>();
                services
                    .AddTransient<IQueryHandler<GetUnitListQuery, List<Unit>>,
                        GetUnitListQuery.GetUnitListQueryHandler>();
                services
                    .AddTransient<IQueryHandler<GetStudentsResultsInExerciseQuery, List<Result>>,
                        GetStudentsResultsInExerciseQuery.GetStudentsResultsInExerciseQueryHandler>();
                services
                    .AddTransient<IQueryHandler<GetStudentListQuery, List<Student>>,
                        GetStudentListQuery.GetStudentListQueryHandler>();
                services
                    .AddTransient<IQueryHandler<GetStudentQuery, Student>,
                        GetStudentQuery.GetStudentQueryHandler>();
                services
                    .AddTransient<IQueryHandler<GetInviteByTokenQuery, Invite>,
                        GetInviteByTokenQuery.GetInviteByTokenQueryHandler>();
                services
                    .AddTransient<IQueryHandler<GetExerciseQuery, Exercise>,
                        GetExerciseQuery.GetExerciseQueryHandler>();

                services
                    .AddTransient<ICommandHandler<TeacherRegistrationCommand>,
                        TeacherRegistrationCommand.TeacherRegistrationCommandHandler>();

                services
                    .AddTransient<IQueryHandler<GetExerciseListQuery, List<Exercise>>,
                        GetExerciseListQuery.GetExerciseListQueryHandler>();
                services
                    .AddTransient<IQueryHandler<GetClassQuery, SchoolClass>,
                        GetClassQuery.GetClassQueryHandler>();
                services
                    .AddTransient<IQueryHandler<GetClassListQuery, List<SchoolClass>>,
                        GetClassListQuery.GetClassListQueryHandler>();
                services
                    .AddTransient<IQueryHandler<GetAppUserListQuery, List<ApplicationUser>>,
                        GetAppUserListQuery.GetListQueryHandler>();
                services
                    .AddTransient<ICommandHandler<AddUnitCommand>,
                        AddUnitCommand.AddUnitCommandHandler>();
                services
                    .AddTransient<ICommandHandler<AddExerciseCommand>,
                        AddExerciseCommand.AddExerciseCommandHandler>();
                services
                    .AddTransient<ICommandHandler<EditAddStudentCommand>,
                        EditAddStudentCommand.EditAddStudentCommandHandler>();
                services
                    .AddTransient<IQueryHandler<GetResultQuery, Result>,
                        GetResultQuery.GetResultQueryHandler>();
                services
                    .AddTransient<ICommandHandler<EditResultCommand>,
                        EditResultCommand.EditResultCommandHandler>();
                services
                    .AddTransient<IQueryHandler<GetClassNumberResultsQuery, List<Result>>,
                        GetClassNumberResultsQuery.GetClassNumberResultsQueryHandler>();
                services
                    .AddTransient<IQueryHandler<GetStudentWithStudentCardNoQuery, Student>,
                        GetStudentWithStudentCardNoQuery.GetStudentWithStudentCardNoQueryHandler>();
                services
                    .AddTransient<ICommandHandler<ChangeClassNumberCommand>,
                        ChangeClassNumberCommand.ChangeClassNumberCommandHandler>();
                services.AddTransient<ICommandHandler<EditAppUserCommand>,
                    EditAppUserCommand.AddUnitCommandHandler>();
                services
                    .AddTransient<IQueryHandler<GetStudentByStudentCardNrQuery, Student>,
                        GetStudentByStudentCardNrQuery.GetStudentByStudentCardNrQueryHandler>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}