using System;
using System.Collections;
using System.Collections.Specialized;

namespace Week5Day5Demo.CollectionDemos
{
    // Linear/Sequential Search
    // Binary Search

    internal class IDictionary
    {
        public static void Demo()
        {
            SortedList sortedList = new SortedList();

            sortedList.Add("hello", "A greeting between two people");
            sortedList.Add("mango", "A yellow Fruit");
            sortedList.Add(10, 500.50f);

            Console.WriteLine(sortedList["mango"]);

            StringDictionary stringDictionary = new StringDictionary();
            stringDictionary.Add("hello", "A greeting between two people");
            stringDictionary.Add("mango", "A yellow Fruit");
            //stringDictionary.Add(10, 500.50f);

            Console.WriteLine(stringDictionary["mango"]);
        }
    }
}
