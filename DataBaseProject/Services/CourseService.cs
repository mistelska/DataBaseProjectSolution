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
    public async Task<CourseEntity> CreateCourse(string courseName)
    {
        try
        {
            var courseEntity = await _courseRepository.Get(x => x.CourseName == courseName);
            if (courseEntity == null)
            {
                courseEntity = await _courseRepository.Create(new CourseEntity { CourseName = courseName });
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

    public async Task<CourseEntity> GetCourseById(int id)
    {
        try
        {
            var courseEntity = await _courseRepository.Get(x => x.Id == id);
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

    public async Task<IEnumerable<CourseEntity>> GetAllCourses()
    {
        try
        {
            var courses = await _courseRepository.GetAllFromList();
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

    public async Task<CourseEntity> UpdateCourse(CourseEntity courseEntity)
    {
        try
        {
            var updatedCours = await _courseRepository.Update(x => x.Id == courseEntity.Id, courseEntity);
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

    public async Task DeleteCourse(int id)
    {
        try
        {
            await _courseRepository.Delete(x => x.Id == id);
        }
        catch(Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
