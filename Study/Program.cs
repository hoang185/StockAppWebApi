using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Study.Processor;

public class FirstClass
{
    public static void Main(string[] args)
    {
        //test git fetch
        int[] arr = new int[7] {7, 6, 5, 3, 1, 4, 7};
        int i = 3;
        int j = 3;
       
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.WriteLine(arr[i]);
        //}
        AmericanEngine ae = new AmericanEngine();
        Car car = new Car("Mercedes", ae);
        ArrayList arrList = new ArrayList(arr);
        Hashtable hashtable = new Hashtable();
        SortedList sortedList = new SortedList();
        sortedList.Add("h", "hash");
        sortedList["b"] = "bb";
        
        sortedList.Add("t", "table");

        sortedList["a"] = "aaaa";
        Stack stack = new Stack(arrList);
        stack.Push("education");
        stack.Push("kteam");
        //int length = stack.Count;
        //for (int i = 0; i < stack.Count; i++)
        //{
        //    //Console.WriteLine(sortedList.GetByIndex(i).ToString());
        //    Console.WriteLine(@"Count : {0} - {1}",stack.Count, stack.Pop());
        //}
        //Console.WriteLine(@"Count after : {0}", stack.Count);

        //foreach (DictionaryEntry key in sortedList)
        //{
        //    Console.WriteLine(key.Key + " - " +key.Value);
        //}
        int first = 2;
        int second = 4;
        //first = Swap(first, second);
        //Console.WriteLine("first : " + first);
    }
    public static int Swap(int a, int b)
    {
        int i = a;
        a = b;
        b = i;
        return a;
    }
    public class Student : Person
    {
        private string _name;
        public Student(string name)
        {
            _name = name;
        }
        public void Study()
        {
            Console.WriteLine("the student is studying");
        }
        public void Speak()
        {
            Console.WriteLine("Student is doing...");
        }
    }
    public class Teacher : Person
    {
        public void Speak()
        {
            Console.WriteLine("Teacher is doing...");
        }
    }
}
