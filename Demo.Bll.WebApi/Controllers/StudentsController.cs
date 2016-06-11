using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using Demo.Bll.Entities;
using Demo.Bll.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.Practices.Unity;

namespace Demo.Bll.WebApi.Controllers
{
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class StudentsController : ApiController
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            return Ok(_studentService.GetStudents());
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            Student student = _studentService.GetById(id);
            return Ok(student);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]Student student)
        {
            if (ModelState.IsValid)
            {
                int id = _studentService.Insert(student);
                return Ok(new {id});
            }
            return BadRequest(ModelState);
        }

        // PATCH api/values
        public IHttpActionResult Patch([FromBody]Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.Update(student);
                return Ok(new { student.Id });
            }
            return BadRequest(ModelState);
        }

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            //return BadRequest();
            _studentService.Delete(id);
            return Ok(new { id });
        }
    }
}
