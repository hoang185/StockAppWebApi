using Microsoft.AspNetCore.Diagnostics;
//using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace demo_aspnet.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Nhap cai ten vao")]
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public bool IsGraduate {  get; set; }
    }
}
