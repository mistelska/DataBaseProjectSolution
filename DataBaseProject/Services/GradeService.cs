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

    public async Task<GradeEntity> CreateGrade(string grade)
    {
        try
        {
            var gradeEntity = await _gradeRepository.Get(x => x.Grade == grade);
            if (gradeEntity == null)
            {
                gradeEntity = await _gradeRepository.Create(new GradeEntity { Grade = grade });
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

    public async Task<GradeEntity> GetGradeById (int id)
    {
        try
        {
            var gradeEntity = await _gradeRepository.Get(x => x.Id == id);
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
    public async Task<IEnumerable<GradeEntity>> GetAllGrades()
    {
        try
        {
            var grades = await _gradeRepository.GetAllFromList();
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
    public async Task<GradeEntity> UpdateGrade (GradeEntity gradeEntity)
    {
        try
        {
            var updatedGrade = await _gradeRepository.Update(x => x.Id == gradeEntity.Id, gradeEntity);
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
    public async Task DeleteGrade(int id)
    {
        try
        {
            await _gradeRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
