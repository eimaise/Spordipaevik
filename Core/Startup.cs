//using System.Collections.Generic;
//using Castle.Core.Configuration;
//using Core.AppServices;
//using Microsoft.Extensions.DependencyInjection;
//using WebApplication2.Data.Entities;
//
//namespace Core
//{
//    public class Startup
//    {
//        public IConfiguration Configuration { get; }
//
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//
//        }
//
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services
//                .AddTransient<IQueryHandler<GetStudentListQuery, List<Student>>,
//                    GetStudentListQuery.GetStudentListQueryHandler>();
//            services.AddSingleton<Messages>();
//
//        }
//    }
//}
