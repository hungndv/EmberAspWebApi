﻿using System;
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
            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Dal.Entities.Student, Student>();
            //    cfg.CreateMap<Student, Dal.Entities.Student>();
            //});
        }

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetStudents().Select(AutoMapper.Mapper.Map<Student>);
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

        public IEnumerable<Student> FindByFirstName(string firstName)
        {
            return _studentRepository.GetStudents()
                .Where(s => s.FirstName.Trim().ToUpper().Contains(firstName.Trim().ToUpper()))
                .Select(AutoMapper.Mapper.Map<Student>);
        }

        public IEnumerable<Student> FindByLastName(string lastName)
        {
            return _studentRepository.GetStudents()
                .Where(s => s.LastName.Trim().ToUpper().Contains(lastName.Trim().ToUpper()))
                .Select(AutoMapper.Mapper.Map<Student>);
        }
    }
}