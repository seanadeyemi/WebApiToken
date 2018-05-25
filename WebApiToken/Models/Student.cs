using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiToken.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string MatricNo { get; set; }

        public virtual Department Department { get; set;}
    }
}