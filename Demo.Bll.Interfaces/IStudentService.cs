using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Bll.Entities;

namespace Demo.Bll.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        Student GetById(int studentId);
        int Insert(Student student);
        void Delete(int studentId);
        void Update(Student student);
    }
}
