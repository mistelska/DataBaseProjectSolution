using DataBaseProject.Contexts;
using DataBaseProject.Entities;

namespace DataBaseProject.Repositories;

internal class SubjectRepository : Repo<SubjectEntity>
{
    public SubjectRepository(ApplicationDbContext context) : base(context)
    {
    }
}
