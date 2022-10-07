using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using School.Repositories.Contracts;
using School.Repositories.Implementation;
using School.Repositories.Repositories.Contracts;
using School.Repositories.Repositories.Implementation;
using School.Repositories.UnitOfWork;
using School.Services.AuthManager;
using School.Services.Services.Contracts;
using School.Services.Services.Implementation;

namespace SchoolAPI.Extensions
{
    public static class ServicesExtension
    {
        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>(); 
            services.AddScoped<IStudentClassRepository, StudentClassRepository>();

            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGradeService, GradeService>();            
            services.AddScoped<IExportGradeServices, ExportGradeServices>();            

            services.AddScoped<IAuthManager, AuthManager>();

        }
    }
}
