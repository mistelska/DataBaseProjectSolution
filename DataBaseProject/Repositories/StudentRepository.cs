using DataBaseProject.Contexts;
using DataBaseProject.Entities;

namespace DataBaseProject.Repositories;

internal class StudentRepository : Repo<StudentEntity>
{
    public StudentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
