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

    public SubjectEntity CreateSubject(string subjectName)
    {
        try
        {
            var subjectEntity = _subjectRepository.Get(x => x.SubjectName == subjectName);
            if (subjectEntity == null)
            {
                subjectEntity = _subjectRepository.Create(new SubjectEntity { SubjectName = subjectName });
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

    public SubjectEntity GetSubjectById(int id)
    {
        try
        {

            var subjectEntity = _subjectRepository.Get(x => x.Id == id);
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

    public IEnumerable<SubjectEntity> GetAllSubjects()
    {
        try
        {
            var subjects = _subjectRepository.GetAllFromList();
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

    public SubjectEntity UpdateSubject(SubjectEntity subjectEntity)
    {
        try
        {
            var updatedSubject = _subjectRepository.Update(x => x.Id == subjectEntity.Id, subjectEntity);
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

    public void DeleteSubject(int id)
    {
        try
        {
            _subjectRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
