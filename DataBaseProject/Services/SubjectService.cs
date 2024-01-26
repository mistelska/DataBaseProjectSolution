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
        var subjectEntity = _subjectRepository.Get(x => x.SubjectName == subjectName);
        if(subjectEntity == null)
        {
            subjectEntity = _subjectRepository.Create(new SubjectEntity { SubjectName = subjectName });
        }
        return subjectEntity;
    }

    public SubjectEntity GetSubjectByName(string subjectName)
    {
        var subjectEntity = _subjectRepository.Get(x => x.SubjectName == subjectName);
        return subjectEntity;
    }

    public IEnumerable<SubjectEntity> GetAllSubjects()
    {
        var subjects = _subjectRepository.GetAllFromList();
        return subjects;
    }

    public SubjectEntity UpdateSubject(SubjectEntity subjectEntity)
    {
        var updatedSubject = _subjectRepository.Update(x => x.Id == subjectEntity.Id, subjectEntity);
        return updatedSubject;
    }

    public void DeleteSubject(int id)
    {
        _subjectRepository.Delete(x => x.Id == id);
    }
}
