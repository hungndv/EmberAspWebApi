using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demo.Bll;
using Demo.Bll.Entities;
using Demo.Bll.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Tests.Bll
{
    [TestClass]
    public class TestStudentService
    {
        [TestMethod]
        public void TestGetStudents()
        {
            IStudentService studentService = new StudentService();
            IEnumerable<Student> students = studentService.GetStudents();
            Assert.IsTrue(students.Any());
        }

        [TestMethod]
        public void TestInsert()
        {
            Student student = new Student
            {
                FirstName = string.Format("FirstName{0}", DateTime.Now.Millisecond),
                LastName = string.Format("LastName{0}", DateTime.Now.Millisecond)
            };
            IStudentService studentService = new StudentService();
            int id = studentService.Insert(student);
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void TestRemove()
        {
            Student student = new Student
            {
                FirstName = string.Format("FirstName{0}", DateTime.Now.Millisecond),
                LastName = string.Format("LastName{0}", DateTime.Now.Millisecond)
            };
            IStudentService studentService = new StudentService();
            int id = studentService.Insert(student);
            Assert.IsTrue(id > 0);
            studentService.Delete(id);
            Student studentNeedToGet = studentService.GetById(id);
            Assert.IsTrue(studentNeedToGet == null);
        }

        [TestMethod]
        public void TestUpdate()
        {
            Student student = new Student
            {
                FirstName = string.Format("FirstName{0}", DateTime.Now.Millisecond),
                LastName = string.Format("LastName{0}", DateTime.Now.Millisecond)
            };
            IStudentService studentService = new StudentService();
            int id = studentService.Insert(student);
            var newFirstName = string.Format("{0}modified", student.FirstName);
            var newLastName = string.Format("{0}modified", student.LastName);
            student.Id = id;
            student.FirstName = newFirstName;
            student.LastName = newLastName;
            studentService.Update(student);
            var modifiedStudent = studentService.GetById(id);
            Assert.IsTrue(modifiedStudent.FirstName == newFirstName);
            Assert.IsTrue(modifiedStudent.LastName == newLastName);
        }
    }
}
