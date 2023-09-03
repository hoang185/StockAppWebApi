using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Processor
{
    public class Student : Person
    {
        public string GetName()
        {
            return " test";
        }

        public override string GetInfo()
        {
            return "t";
        }
    }

    public class Teacher : IPerson
    {
        public string GetName()
        {
            return "t";
        }
    }
}
