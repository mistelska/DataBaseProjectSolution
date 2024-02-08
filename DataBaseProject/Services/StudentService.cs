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
        try
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
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public StudentEntity GetStudentById(int id)
    {
        try
        {
            var studentEntity = _studentRepository.Get(x => x.Id == id);
            return studentEntity;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public IEnumerable<StudentEntity> GetAllStudents()
    {
        try
        {
            var students = _studentRepository.GetAllFromList();
            return students;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public StudentEntity UpdateStudent (StudentEntity studentEntity)
    {
        try
        {
            var updatedStudent = _studentRepository.Update(x => x.Id == studentEntity.Id, studentEntity);
            return updatedStudent;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public void DeleteStudent(int id)
    {
        try
        {
            _studentRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
