using DataBaseProject.Entities;
using DataBaseProject.Repositories;

namespace DataBaseProject.Services;

internal class GradeService
{
    private readonly GradeRepository _gradeRepository;

    public GradeService(GradeRepository gradeRepository)
    {
        _gradeRepository = gradeRepository;
    }

    public GradeEntity CreateGrade(string grade)
    {
        var gradeEntity = _gradeRepository.Get(x => x.Grade == grade);
        if (gradeEntity == null)
        {
            gradeEntity = _gradeRepository.Create(new GradeEntity { Grade = grade });
        }
        return gradeEntity;
    }

    public GradeEntity GetGradeById (int id)
    {
        var gradeEntity = _gradeRepository.Get(x => x.Id == id);
        return gradeEntity;
    }
    public IEnumerable<GradeEntity> GetAllGrades()
    {
        var grades = _gradeRepository.GetAllFromList();
        return grades;
    }
    public GradeEntity UpdateGrade (GradeEntity gradeEntity)
    {
        var updatedGrade = _gradeRepository.Update(x => x.Id == gradeEntity.Id, gradeEntity);
        return updatedGrade;
    }
    public void DeleteGrade(int id)
    {
        _gradeRepository.Delete(x => x.Id == id);
    }
}
