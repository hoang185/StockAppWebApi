using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Interface;

namespace Study.Processor
{
    public class AmericanEngine : IEngine
    {
        public void Excute()
        {
            Console.WriteLine("America");
        }
    }
}
