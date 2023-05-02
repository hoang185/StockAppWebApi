using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Processor
{
    public class Student
    {
        private static string _name;
        public Student()
        {
        }
        public string getName()
        {
            if (_name == null)
                _name = "test";

            return _name;
        }
    }
}
