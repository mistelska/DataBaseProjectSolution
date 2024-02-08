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
        public async Task<TeacherEntity> CreateTeacher(string firstName, string lastName, string subjectName)
        {
            try
            {
                var subjectEntity = await _subjectService.CreateSubject(subjectName);
                var teacherEntity = new TeacherEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    SubjectId = subjectEntity.Id
                };
                teacherEntity = await _teacherRepository.Create(teacherEntity);
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
        public async Task<TeacherEntity> GetTeacherById(int id)
        {
            try
            {
                var teacherEntity = await _teacherRepository.Get(x => x.Id == id);
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
        public async Task<IEnumerable<TeacherEntity>> GetAllTeachers()
        {
            try
            {
                var teacherEntity = await _teacherRepository.GetAllFromList();
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
        public async Task<TeacherEntity> UpdateTeacher(TeacherEntity teacherEntity)
        {
            try
            {
                var updatedTeacher = await _teacherRepository.Update(x => x.Id == teacherEntity.Id, teacherEntity);
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
        public async Task DeleteTeacher(int id)
        {
            try
            {
                await _teacherRepository.Delete(x => x.Id == id);
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
