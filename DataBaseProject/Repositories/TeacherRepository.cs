using DataBaseProject.Contexts;
using DataBaseProject.Entities;

namespace DataBaseProject.Repositories;

internal class TeacherRepository : Repo<TeacherEntity>
{
    public TeacherRepository(ApplicationDbContext context) : base(context)
    {
    }
}
