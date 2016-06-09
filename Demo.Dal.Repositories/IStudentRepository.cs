
using System;
using System.Collections.Generic;
using Demo.Dal.Entities;

namespace Demo.Dal
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int studentId);
        int InsertStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);
        void Save();
    }
}
