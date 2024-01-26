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
        var courseEntity = _courseRepository.Get(x => x.CourseName == courseName);
        if (courseEntity == null)
        {
            courseEntity = _courseRepository.Create(new CourseEntity { CourseName = courseName});
        }
        return courseEntity;
    }
    
    public CourseEntity GetCourseByName(string courseName)
    {
        var courseEntity = _courseRepository.Get(x => x.CourseName == courseName);
        return courseEntity;
    }

    public IEnumerable<CourseEntity> GetAllCourses()
    {
        var courses = _courseRepository.GetAllFromList();
        return courses;
    }

    public CourseEntity UpdateCourse(CourseEntity courseEntity)
    {
        var updatedCours = _courseRepository.Update(x => x.Id == courseEntity.Id, courseEntity);
        return updatedCours;
    }

    public void DeleteCourse(int id)
    {
        _courseRepository.Delete(x => x.Id == id);
    }
}
