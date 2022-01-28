using System;
using System.Collections;
using System.Collections.Specialized;

namespace Week5Day5Demo.CollectionDemos
{
    internal class IListDemo
    {
        public static void Demo()
        {
            // Basic Arrays
            string[] lines1 = new string[100];
            lines1[0] = "Hello1";

            for (int i = 0; i < lines1.Length; i++)
            {
                if (lines1[i] == "Go")
                {
                    Console.WriteLine("Found it");
                    break;
                }
            }

            // Alternate way of using Arrays
            Array lines2 = new string[100];
            lines2.SetValue("Hello2", 0);

            // Array List
            ArrayList arrayList = new ArrayList();

            arrayList.Add("Hello");
            arrayList.Add("World");
            arrayList.Add(10);
            arrayList.Add(100.50f);

            Console.WriteLine("-- Array Collection Demo ---");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // String Collection
            StringCollection stringCollection = new StringCollection();
            stringCollection.Add("Hello");
            stringCollection.Add("World");
            //stringCollection.Add(10);

            Console.WriteLine("-- String Collection Demo --");
            foreach (var item in stringCollection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------");
        }
    }
}
