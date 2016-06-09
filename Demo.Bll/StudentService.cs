using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Bll.Entities;
using Demo.Bll.Interfaces;
using Demo.Dal;
using Demo.Dal.Implements;

namespace Demo.Bll
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        static StudentService()
        {
            AutoMapper.Mapper.CreateMap<Dal.Entities.Student, Student>();
            AutoMapper.Mapper.CreateMap<Student, Dal.Entities.Student>();
        }

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetStudents().ToList().Select(AutoMapper.Mapper.Map<Student>).ToList();
        }

        public Student GetById(int studentId)
        {
            return AutoMapper.Mapper.Map<Student>(_studentRepository.GetStudentById(studentId));
        }

        public int Insert(Student student)
        {
            Dal.Entities.Student dalStudent = AutoMapper.Mapper.Map<Dal.Entities.Student>(student);
            return _studentRepository.InsertStudent(dalStudent);
        }

        public void Delete(int studentId)
        {
            _studentRepository.DeleteStudent(studentId);
        }

        public void Update(Student student)
        {
            Dal.Entities.Student dalStudent = AutoMapper.Mapper.Map<Dal.Entities.Student>(student);
            _studentRepository.UpdateStudent(dalStudent);
        }
    }
}