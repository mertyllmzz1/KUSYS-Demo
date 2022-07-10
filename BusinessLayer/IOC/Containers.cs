using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.IOC
{
    public static class Containers
    {
        public static IServiceCollection MyService(this IServiceCollection services)
        {
            services.AddDbContext<StudentContext>();
            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<ICoursesAndStudentsMatchesService, CoursesAndStudentMatchesManager>();
            return services;
        }
    }
}
