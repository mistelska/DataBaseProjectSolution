using DataBaseProject.Entities;
using DataBaseProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public TeacherEntity GetTeacherByName(string lastName)
        {
            var teacherEntity = _teacherRepository.Get(x => x.LastName == lastName);
            return teacherEntity;
        }

        public IEnumerable<TeacherEntity> GetAllTeachers()
        {
            var teacherEntity = _teacherRepository.GetAllFromList();
            return teacherEntity;
        }

        public TeacherEntity UpdateTeacher(TeacherEntity teacherEntity)
        {
            var updatedTeacher = _teacherRepository.Update(x => x.Id == teacherEntity.Id, teacherEntity);
            return updatedTeacher;
        }

        public void DeleteTeacher(int id)
        {
            _teacherRepository.Delete(x => x.Id == id);
        }
    }

}
