using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Processor
{
    public abstract class Person
    {
        private static string _name;
        public Person()
        {
        }
        public abstract string GetInfo();
        public string GetName()
        {
            if (_name == null)
                _name = "test";

            return _name;
        }
    }

    public interface IPerson 
    {
        public string GetName();
    }
}
