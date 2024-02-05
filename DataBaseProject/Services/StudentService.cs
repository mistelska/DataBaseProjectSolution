using DataBaseProject.Entities;
using DataBaseProject.Repositories;

namespace DataBaseProject.Services;

internal class StudentService
{
    private readonly StudentRepository _studentRepository;
    private readonly CourseService _courseService;
    private readonly GradeService _gradeService;

    public StudentService(StudentRepository studentRepository, CourseService courseService, GradeService gradeService)
    {
        _studentRepository = studentRepository;
        _courseService = courseService;
        _gradeService = gradeService;
    }

    public StudentEntity CreateStudent(string firstName, string lastName, string email, string phoneNumber, string courseName, string grade)
    {
        var courseEntity = _courseService.CreateCourse(courseName);
        var gradeEntity = _gradeService.CreateGrade(grade);

        var studentEntity = new StudentEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            CourseId = courseEntity.Id,
            GradeId = gradeEntity.Id
        };
        studentEntity = _studentRepository.Create(studentEntity);
        return studentEntity;
    }

    public StudentEntity GetStudentById(int id)
    {
        var studentEntity = _studentRepository.Get(x => x.Id == id);
        return studentEntity;
    }

    public IEnumerable<StudentEntity> GetAllStudents()
    {
        var students = _studentRepository.GetAllFromList();
        return students;
    }

    public StudentEntity UpdateStudent (StudentEntity studentEntity)
    {
        var updatedStudent = _studentRepository.Update(x => x.Id == studentEntity.Id, studentEntity);
        return updatedStudent;
    }

    public void DeleteStudent(int id)
    {
        _studentRepository.Delete(x => x.Id == id);
    }
}
