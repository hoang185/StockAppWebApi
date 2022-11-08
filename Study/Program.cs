using System;
using System.Collections;
using Study.Processor;

public class FirstClass
{
    public static void Main(string[] args)
    {
        //Student student = new Student("hello");
        ////student.Study();
        ////Person person = new Person();
        ////person.name = "test";
        //student.Speak();
        //Teacher teacher = new Teacher();
        //teacher.Speak();
        //Person person = new Teacher();
        //person.Speak();
        //Person person1 = new Student("hello");
        //person1.Speak();
        int[] arr = new int[5] {1, 2, 3, 4, 5};
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.WriteLine(arr[i]);
        //}
        ArrayList arrList = new ArrayList(arr);
        arrList.Add(6);
        
        if (arr.Contains(6))
        {
            Console.WriteLine("arr");
        }
        if (arrList.Contains(6))
        {
            Console.WriteLine("arrlist");
        }
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