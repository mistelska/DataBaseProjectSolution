using DataBaseProject.Entities;
using DataBaseProject.Repositories;
namespace DataBaseProject.Services;

internal class SubjectService
{
    private readonly SubjectRepository _subjectRepository;

    public SubjectService(SubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task<SubjectEntity> CreateSubject(string subjectName)
    {
        try
        {
            var subjectEntity = await _subjectRepository.Get(x => x.SubjectName == subjectName);
            if (subjectEntity == null)
            {
                subjectEntity = await _subjectRepository.Create(new SubjectEntity { SubjectName = subjectName });
            }
            return subjectEntity;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task<SubjectEntity> GetSubjectById(int id)
    {
        try
        {

            var subjectEntity = await _subjectRepository.Get(x => x.Id == id);
            return subjectEntity;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task<IEnumerable<SubjectEntity>> GetAllSubjects()
    {
        try
        {
            var subjects = await _subjectRepository.GetAllFromList();
            return subjects;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task<SubjectEntity> UpdateSubject(SubjectEntity subjectEntity)
    {
        try
        {
            var updatedSubject = await _subjectRepository.Update(x => x.Id == subjectEntity.Id, subjectEntity);
            return updatedSubject;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task DeleteSubject(int id)
    {
        try
        {
            await _subjectRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
