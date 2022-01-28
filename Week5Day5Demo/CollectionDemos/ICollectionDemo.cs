using System;
using System.Collections;
using System.Collections.Specialized;

namespace Week5Day5Demo.CollectionDemos
{
    internal class ICollectionDemo
    {
        public static void Demo()
        {
            var stack = new Stack();

            //LIFO
            stack.Push(100);
            stack.Push(200);
            stack.Push(300);

            Console.WriteLine("-- Stack --------------");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine("-----------------------");

            // FIFO
            var queue = new Queue();
            queue.Enqueue(100);
            queue.Enqueue(200);
            queue.Enqueue(300);

            Console.WriteLine("-- Queue --------------");
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine("-----------------------");

            var nameValueCollection = new NameValueCollection();

            nameValueCollection.Add("BackgroundColor", "red");
            nameValueCollection.Add("Title", "Hello World");
            nameValueCollection.Add("Width", "100px");

            Console.WriteLine("-- NameValueCollection -");
            Console.WriteLine(nameValueCollection["BackgroundColor"]);
            Console.WriteLine(nameValueCollection["Title"]);
            Console.WriteLine(nameValueCollection["Width"]);
            Console.WriteLine(nameValueCollection["SomeOtherName"]);
            Console.WriteLine("-----------------------");
        }
    }
}
