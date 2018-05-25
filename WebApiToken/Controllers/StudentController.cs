using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiToken.Abstract;
using WebApiToken.Concrete;
using WebApiToken.Models;

namespace WebApiToken.Controllers
{
   [Authorize]
    public class StudentController : ApiController
    {
        private readonly IStudentRepository repository;
     

        public StudentController(IStudentRepository repo)
        {
            repository = repo;
        }
        // GET api/values
        public IEnumerable<Student> Get()
        {
            IEnumerable<Student> students = repository.GetStudents();
            return students;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
