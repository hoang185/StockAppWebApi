using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Interface;

namespace Study.Processor
{
    public class Car
    {
        private readonly IEngine _eng;
        private readonly string _name;
        public Car(string name, IEngine eng)
        {
            _eng = eng;
            _name = name;
        }
    }
}
