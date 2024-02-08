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

    public async Task<StudentEntity> CreateStudent(string firstName, string lastName, string email, string phoneNumber, string courseName, string grade)
    {
        try
        {
            var courseEntity = await _courseService.CreateCourse(courseName);
            var gradeEntity = await _gradeService.CreateGrade(grade);

            var studentEntity = new StudentEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                CourseId = courseEntity.Id,
                GradeId = gradeEntity.Id
            };
            studentEntity = await _studentRepository.Create(studentEntity);
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
    public async Task<StudentEntity> GetStudentById(int id)
    {
        try
        {
            var studentEntity = await _studentRepository.Get(x => x.Id == id);
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
    public async Task<IEnumerable<StudentEntity>> GetAllStudents()
    {
        try
        {
            var students = await _studentRepository.GetAllFromList();
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
    public async Task<StudentEntity> UpdateStudent (StudentEntity studentEntity)
    {
        try
        {
            var updatedStudent = await _studentRepository.Update(x => x.Id == studentEntity.Id, studentEntity);
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
    public async Task DeleteStudent(int id)
    {
        try
        {
            await _studentRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
