using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//using AspNetCore;

namespace demo_aspnet.Models
{
    public static class Repository
    {
        private static List<Student> _students = new List<Student>();
        public static List<Student> GetStudents()
        {
            return _students;
        }
        public static void AddStudent(Student student)
        {
            _students.Add(student);
        }
    }
}
