using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Demo.Bll;
using Demo.Bll.Entities;
using Demo.Bll.Interfaces;
using Demo.Bll.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Tests.Bll
{
    [TestClass]
    public class TestStudentsController
    {
        //[TestMethod]
        //public void TestGetStudents()
        //{
        //    IStudentService studentService = new StudentService();
        //    IEnumerable<Student> students = studentService.GetStudents();
        //    Assert.IsTrue(students.Any());
        //}

        //[TestMethod]
        //public void TestInsertWithInvalidInputs()
        //{
        //    Student student = new Student();
        //    var controller = new StudentsController();
        //    controller.Configuration = new HttpConfiguration();
        //    controller.Validate(student);
        //    var actionResult = controller.Post(student);
        //    Assert.IsInstanceOfType(actionResult, BadRequestNego);
        //}

        //[TestMethod]
        //public void TestRemove()
        //{
        //    Student student = new Student
        //    {
        //        FirstName = string.Format("FirstName{0}", DateTime.Now.Millisecond),
        //        LastName = string.Format("LastName{0}", DateTime.Now.Millisecond)
        //    };
        //    IStudentService studentService = new StudentService();
        //    int id = studentService.Insert(student);
        //    Assert.IsTrue(id > 0);
        //    studentService.Delete(id);
        //    Student studentNeedToGet = studentService.GetById(id);
        //    Assert.IsTrue(studentNeedToGet == null);
        //}

        //[TestMethod]
        //public void TestUpdate()
        //{
        //    Student student = new Student
        //    {
        //        FirstName = string.Format("FirstName{0}", DateTime.Now.Millisecond),
        //        LastName = string.Format("LastName{0}", DateTime.Now.Millisecond)
        //    };
        //    IStudentService studentService = new StudentService();
        //    int id = studentService.Insert(student);
        //    var newFirstName = string.Format("{0}modified", student.FirstName);
        //    var newLastName = string.Format("{0}modified", student.LastName);
        //    student.Id = id;
        //    student.FirstName = newFirstName;
        //    student.LastName = newLastName;
        //    studentService.Update(student);
        //    var modifiedStudent = studentService.GetById(id);
        //    Assert.IsTrue(modifiedStudent.FirstName == newFirstName);
        //    Assert.IsTrue(modifiedStudent.LastName == newLastName);
        //}
    }
}
