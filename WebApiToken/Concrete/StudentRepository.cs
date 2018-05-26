using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiToken.Abstract;
using WebApiToken.Data;
using WebApiToken.Models;

namespace WebApiToken.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private MyDbContext context;
     

      

        public StudentRepository()
        {
            this.context = new MyDbContext();
        }


        public IEnumerable<Student> GetStudents()
        {

            //Department d1 = new Department { Id = 1, Name = "Cyberacademy" };
            //Department d2 = new Department { Id = 2, Name = "Security" };

            //return new List<Student>
            //{
            //     new Student{ Name = "Chuks", MatricNo = "01", Id = 1, Department = d1 },
            //     new Student{ Name = "Gabyslaw", MatricNo = "02", Id = 2, Department = d2 },
            //     new Student{ Name = "Muna", MatricNo = "03", Id = 3, Department = d1 },
            //     new Student{ Name = "Winnie", MatricNo = "04", Id = 4, Department = d2 },
            //     new Student{ Name = "Lola", MatricNo = "05", Id = 5, Department = d1 }

            //};

            return context.Students.ToList();
        }
    }
}