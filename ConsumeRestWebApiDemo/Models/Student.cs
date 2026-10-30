using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeRestWebApiDemo.Models
{
    public class Student
    {
        public int id { get; set; }
        public string studentName { get; set; }
        public string studentGender { get; set; }
        public int age { get; set; }
        public int standard { get; set; }
        public string fatherName { get; set; }
    }
}
