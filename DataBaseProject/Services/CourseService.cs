using DataBaseProject.Entities;
using DataBaseProject.Repositories;

namespace DataBaseProject.Services;

internal class CourseService
{
    private readonly CourseRepository _courseRepository;

    public CourseService(CourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    public CourseEntity CreateCourse(string courseName)
    {
        try
        {
            var courseEntity = _courseRepository.Get(x => x.CourseName == courseName);
            if (courseEntity == null)
            {
                courseEntity = _courseRepository.Create(new CourseEntity { CourseName = courseName });
            }
            return courseEntity;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public CourseEntity GetCourseById(int id)
    {
        try
        {
            var courseEntity = _courseRepository.Get(x => x.Id == id);
            return courseEntity;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public IEnumerable<CourseEntity> GetAllCourses()
    {
        try
        {
            var courses = _courseRepository.GetAllFromList();
            return courses;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public CourseEntity UpdateCourse(CourseEntity courseEntity)
    {
        try
        {
            var updatedCours = _courseRepository.Update(x => x.Id == courseEntity.Id, courseEntity);
            return updatedCours;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public void DeleteCourse(int id)
    {
        try
        {
            _courseRepository.Delete(x => x.Id == id);
        }
        catch(Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
