using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.AppServices;
using Core.Data;
using Core.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApplication2.Controllers;
using WebApplication2.Data;
using WebApplication2.Data.Entities;
using WebApplication2.Data.Repositories;
using WebApplication2.Services;

namespace WebApplication2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

//            var connectionString = "server=(LocalDB)\\MSSQLLocalDB;Database=PeSportsTracker;Trusted_Connection=true;";
            services.AddTransient<Seeder>();
            services.AddScoped<IPersonRepository,PersonRepository>();
            services.AddScoped<IExerciseRepository,ExerciseRepository>();
            services.AddScoped<IClassRepository,ClassRepository>();
            services.AddScoped<ISecureTokenGenerator,SecureTokenGenerator>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();
            services.AddTransient<IChartDataFactory, ChartDataFactory>();
            services.AddTransient<IResultService, ResultService>();

            //core serviced peaks tõstma ümber
            CoreCommandAndQueryServicesShouldBeMoved();


            services.AddIdentity<ApplicationUser, ApplicationRole>(
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

            services.AddDbContext<PeSportsTrackingContext>(o=>o.UseSqlServer(
                Configuration.GetConnectionString("SportTracerConnectionString")).UseLazyLoadingProxies()
            );
            
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
                    .AddTransient<ICommandHandler<InviteUsedCommand>,
                        InviteUsedCommand.InviteUsedCommandHandler>();
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