using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Study.Processor;
using System.Threading;


public class FirstClass
{
    public static void Main(string[] args)
    {
        string nullString = null;
        string emptyString = "";

        Console.WriteLine(nullString == null);    // true
        Console.WriteLine(emptyString == null);   // false
        Console.WriteLine(nullString == "");      // true
        Console.WriteLine(emptyString == "");
        StayHomeDelegate stayHome = new StayHomeDelegate(StayHome);
        GiveGift(stayHome);
        #region comment

        Student std = new Student();
        string str1 = std.GetName();
        string str = "hello2";
        Console.WriteLine(str.LastOrDefault());
        if ("sd2ld".Contains(str.LastOrDefault()))
            Console.WriteLine("true");
        List<int> ints = new List<int>();
        int _1 = ints.Where(x => x > 0).Count();
        int sum = ints.Sum();

        DemoThread("sd");
        Thread t = new Thread(() =>
        {
            DemoThread("thread1");
        });
        Thread t2 = new Thread(() =>
        {
            DemoThread("thread2");
        });
        Thread t3 = new Thread(() =>
        {
            DemoThread("thread3");
        });
        t.Start();
        t2.Start();
        t3.Start();
        Console.ReadLine();
        //test git fetch
        #region stack issue
        int[] arr = new int[7] { 2, 1, 3, 2, 8, 5, 7 };
        int[] res = new int[7];
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        res[0] = -1;
        int flag = -1;
        Console.Write(res[0] + ", ");
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i - 1] > arr[i])
            {
                stack.Push(i);
                res[i] = i - 1;
            }
            else
            {
                while (stack.Count > 0 && arr[stack.Peek()] < arr[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    res[i] = stack.Peek();
                }
                else
                {
                    stack.Push(i);
                    res[i] = -1;
                }
            }
            Console.Write(res[i] + ", ");
        }
        #endregion

        //int i = 3;
        //int j = 3;
        Student stu = new Student();
        string per1 = stu.GetName();
        string per2 = stu.GetName();
        if (per1 == per2)
        {
            Console.WriteLine("pass");
        }
        else
        {
            Console.WriteLine("failed");
        }

        foreach (int item in res)
        {
            Console.Write(item + ", ");
        }
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.WriteLine(arr[i]);
        //}
        //AmericanEngine ae = new AmericanEngine();
        //Car car = new Car("Mercedes", ae);
        //ArrayList arrList = new ArrayList(arr);
        //Hashtable hashtable = new Hashtable();
        //SortedList sortedList = new SortedList();
        //sortedList.Add("h", "hash");
        //sortedList["b"] = "bb";

        //sortedList.Add("t", "table");

        //sortedList["a"] = "aaaa";
        //Stack stack = new Stack(arrList);
        //stack.Push("education");
        //stack.Push("kteam");
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
        #endregion
    }
    public static void GiveGift(StayHomeDelegate stayHome)
    {
        StayHome("Done 1");
        stayHome("Done 2");
    }
    public static void StayHome(string wish)
    {
        Console.WriteLine("Give the gift with the wish: " + wish);
    }
    public delegate void StayHomeDelegate(string str);
    public static int Swap(int a, int b)
    {
        int i = a;
        a = b;
        b = i;
        return a;
    }

    public static void DemoThread(string str)
    {
        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine(str + " - " + i);
        }
    }
    
}




