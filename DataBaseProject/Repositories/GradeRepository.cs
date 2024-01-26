using DataBaseProject.Contexts;
using DataBaseProject.Entities;

namespace DataBaseProject.Repositories;

internal class GradeRepository : Repo<GradeEntity>
{
    public GradeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
