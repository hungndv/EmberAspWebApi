using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Demo.Dal.EntityFramework;
using Student = Demo.Dal.Entities.Student;

namespace Demo.Dal.Implements
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DemoEntities _context;

        static StudentRepository()
        {
            AutoMapper.Mapper.CreateMap<EntityFramework.Student, Student>();
            AutoMapper.Mapper.CreateMap<Student, EntityFramework.Student>();
        }

        public StudentRepository()
        {
            this._context = new DemoEntities();
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList().Select(AutoMapper.Mapper.Map<Student>).ToList();
        }

        public Student GetStudentById(int id)
        {
            EntityFramework.Student efStudent = _context.Students.Find(id);
            return AutoMapper.Mapper.Map<Student>(efStudent);
        }

        public int InsertStudent(Student student)
        {
            EntityFramework.Student efStudent = AutoMapper.Mapper.Map<EntityFramework.Student>(student);
            _context.Students.Add(efStudent);
            Save();
            return efStudent.Id;
        }

        public void DeleteStudent(int studentId)
        {
            EntityFramework.Student efStudent = _context.Students.FirstOrDefault(s => s.Id == studentId);
            if (efStudent != null)
            {
                _context.Students.Remove(efStudent);
                Save();
            }
        }

        public void UpdateStudent(Student student)
        {
            EntityFramework.Student efStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            if (efStudent != null)
            {
                efStudent.FirstName = student.FirstName;
                efStudent.LastName = student.LastName;
                _context.Entry(efStudent).State = EntityState.Modified;
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}