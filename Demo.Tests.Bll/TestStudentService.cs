using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demo.Bll;
using Demo.Bll.Entities;
using Demo.Bll.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Dal;
using Demo.Dal.EntityFramework;
using Demo.Dal.Implements;
using Moq;

namespace Demo.Tests.Bll
{
    [TestClass]
    public class TestStudentService
    {
        [TestMethod]
        public void TestInsert()
        {
            Demo.Bll.Entities.Student student = new Demo.Bll.Entities.Student
            {
                FirstName = string.Format("FirstName{0}", DateTime.Now.Millisecond),
                LastName = string.Format("LastName{0}", DateTime.Now.Millisecond)
            };
            DemoEntities context = new DemoEntities();
            IStudentRepository repo = new StudentRepository(context);
            IStudentService studentService = new StudentService(repo);
            int id = studentService.Insert(student);
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void TestGetAllWithMock()
        {
            var repo = new Mock<IStudentRepository>();
            var students = new List<Dal.Entities.Student>();
            repo.Setup(x => x.GetStudents()).Returns(students);

            IStudentService studentService = new StudentService(repo.Object);
            var gotStudents = studentService.GetStudents();
            Assert.IsFalse(gotStudents.Any());
        }

        [TestMethod]
        public void TestGetStudents()
        {
            DemoEntities context = new DemoEntities();
            IStudentRepository repo = new StudentRepository(context);
            IStudentService studentService = new StudentService(repo);
            IEnumerable<Demo.Bll.Entities.Student> students = studentService.GetStudents();
            Assert.IsTrue(students.Any());
        }

        [TestMethod]
        public void TestRemove()
        {
            Demo.Bll.Entities.Student student = new Demo.Bll.Entities.Student
            {
                FirstName = string.Format("FirstName{0}", DateTime.Now.Millisecond),
                LastName = string.Format("LastName{0}", DateTime.Now.Millisecond)
            };
            DemoEntities context = new DemoEntities();
            IStudentRepository repo = new StudentRepository(context);
            IStudentService studentService = new StudentService(repo);
            int id = studentService.Insert(student);
            Assert.IsTrue(id > 0);
            studentService.Delete(id);
            Demo.Bll.Entities.Student studentNeedToGet = studentService.GetById(id);
            Assert.IsTrue(studentNeedToGet == null);
        }

        [TestMethod]
        public void TestUpdate()
        {
            Demo.Bll.Entities.Student student = new Demo.Bll.Entities.Student
            {
                FirstName = string.Format("FirstName{0}", DateTime.Now.Millisecond),
                LastName = string.Format("LastName{0}", DateTime.Now.Millisecond)
            };
            DemoEntities context = new DemoEntities();
            IStudentRepository repo = new StudentRepository(context);
            IStudentService studentService = new StudentService(repo);
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
