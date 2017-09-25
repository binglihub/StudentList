using StudentList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentList.Controllers
{
    public class StudentController : ApiController
    {
        static readonly DataBase dataBase = new DataBase();

        public IEnumerable<Student> GetAll()
        {
            return dataBase.GetAll();
        }
        public bool PostStudent(Student student)
        {
            return dataBase.Add(student);
        }
    }
}
