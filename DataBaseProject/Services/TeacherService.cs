using DataBaseProject.Entities;
using DataBaseProject.Repositories;

namespace DataBaseProject.Services
{
    internal class TeacherService
    {
        private readonly TeacherRepository _teacherRepository;
        private readonly SubjectService _subjectService;

        public TeacherService(TeacherRepository teacherRepository, SubjectService subjectService)
        {
            _teacherRepository = teacherRepository;
            _subjectService = subjectService;
        }

        public TeacherEntity CreateTeacher(string firstName, string lastName, string subjectName)
        {
            try
            {
                var subjectEntity = _subjectService.CreateSubject(subjectName);
                var teacherEntity = new TeacherEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    SubjectId = subjectEntity.Id
                };
                teacherEntity = _teacherRepository.Create(teacherEntity);
                return teacherEntity;
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Something went wrong: {ex.Message}");
                Console.ReadKey();
                return null!;
            }
        }

        public TeacherEntity GetTeacherById(int id)
        {
            try
            {
                var teacherEntity = _teacherRepository.Get(x => x.Id == id);
                return teacherEntity;
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Something went wrong: {ex.Message}");
                Console.ReadKey();
                return null!;
            }
        }

        public IEnumerable<TeacherEntity> GetAllTeachers()
        {
            try
            {
                var teacherEntity = _teacherRepository.GetAllFromList();
                return teacherEntity;
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Something went wrong: {ex.Message}");
                Console.ReadKey();
                return null!;
            }
        }

        public TeacherEntity UpdateTeacher(TeacherEntity teacherEntity)
        {
            try
            {
                var updatedTeacher = _teacherRepository.Update(x => x.Id == teacherEntity.Id, teacherEntity);
                return updatedTeacher;
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Something went wrong: {ex.Message}");
                Console.ReadKey();
                return null!;
            }
        }

        public void DeleteTeacher(int id)
        {
            try
            {
                _teacherRepository.Delete(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Something went wrong: {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}
