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
        try
        {
            var gradeEntity = _gradeRepository.Get(x => x.Grade == grade);
            if (gradeEntity == null)
            {
                gradeEntity = _gradeRepository.Create(new GradeEntity { Grade = grade });
            }
            return gradeEntity;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public GradeEntity GetGradeById (int id)
    {
        try
        {
            var gradeEntity = _gradeRepository.Get(x => x.Id == id);
            return gradeEntity;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public IEnumerable<GradeEntity> GetAllGrades()
    {
        try
        {
            var grades = _gradeRepository.GetAllFromList();
            return grades;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public GradeEntity UpdateGrade (GradeEntity gradeEntity)
    {
        try
        {
            var updatedGrade = _gradeRepository.Update(x => x.Id == gradeEntity.Id, gradeEntity);
            return updatedGrade;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public void DeleteGrade(int id)
    {
        try
        {
            _gradeRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
