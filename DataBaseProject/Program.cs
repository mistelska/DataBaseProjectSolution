using DataBaseProject.Contexts;
using DataBaseProject.Repositories;
using DataBaseProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\all-courses-ec\data-storage-course\DataBaseProjectSolution\DataBaseProject\Data\localdatabase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

    services.AddScoped<CourseRepository>();
    services.AddScoped<GradeRepository>();
    services.AddScoped<StudentRepository>();
    services.AddScoped<SubjectRepository>();
    services.AddScoped<TeacherRepository>();

    services.AddScoped<CourseService>();
    services.AddScoped<GradeService>();
    services.AddScoped<StudentService>();
    services.AddScoped<SubjectService>();
    services.AddScoped<TeacherService>();

}).Build();


