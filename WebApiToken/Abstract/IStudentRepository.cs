using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiToken.Models;

namespace WebApiToken.Abstract
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
    }
}
