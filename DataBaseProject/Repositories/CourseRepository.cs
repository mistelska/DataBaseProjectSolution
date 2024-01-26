using DataBaseProject.Contexts;
using DataBaseProject.Entities;

namespace DataBaseProject.Repositories;

internal class CourseRepository : Repo<CourseEntity>
{
    public CourseRepository(ApplicationDbContext context) : base(context)
    {
    }
}
