using System;

namespace ModuleHW
{
    public class Starter
    {
        public void Run()
        {
            var intList = new ArrayList<int>();
            ListInfo(intList);

            var intArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            intList.Add(0);
            intList.Add(9);
            intList.Add(8);
            intList.Add(7);
            intList.Add(6);
            ListInfo(intList);

            intList.Add(5);
            intList.Add(4);
            intList.Add(3);
            intList.Add(2);
            intList.Add(1);
            intList.Add(0);
            ListInfo(intList);

            intList.AddRange(intArray);
            ListInfo(intList);

            intList.RemoveAt(5);
            ListInfo(intList);

            intList.RemoveAtRange(5, 6, 8, 9, 14, 15, 16, 22);
            ListInfo(intList);

            intList.Remove(0);
            ListInfo(intList);

            intList.RemoveRange(0, 6, 16, 26);
            ListInfo(intList);

            intList.Sort(new IntComparer());
            ListInfo(intList);

            intList.Sort();
            ListInfo(intList);

            var stringList = new ArrayList<string>(6);
            ListInfo(stringList);

            var stringArray = new string[] { "uno", "due", "tre", "quattro", "cinque", "sei", "sette", "otto", "nove", "dieci" };

            stringList.Add("zero");
            stringList.Add("one");
            stringList.Add("two");
            stringList.Add("three");
            stringList.Add("four");
            ListInfo(stringList);

            stringList.Add("five");
            stringList.Add("six");
            stringList.Add("seven");
            stringList.Add("eight");
            stringList.Add("nine");
            stringList.Add("zero");
            ListInfo(stringList);

            stringList.AddRange(stringArray);
            ListInfo(stringList);

            stringList.Sort(new StringComparer());
            ListInfo(stringList);

            stringList.Sort();
            ListInfo(stringList);

            stringList.RemoveAtRange(5);
            ListInfo(stringList);

            stringList.RemoveAtRange(5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 20, 22);
            ListInfo(stringList);

            stringList.RemoveRange("five", "cinque", "dieci");
            ListInfo(stringList);

            stringList.AddItems("five", "cinque", "dieci");
            ListInfo(stringList);

            stringList.Insert(4, "INSERTATION1");
            stringList.Insert(4, "INSERTATION2");
            stringList.Insert(4, "INSERTATION3");
            ListInfo(stringList);

            Console.ReadKey();
        }

        private void ListInfo<T>(ArrayList<T> arrayList)
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine("==============================");
            Console.WriteLine($" Number of items:         {arrayList.Count}");
            Console.WriteLine($" Capacity of the array:   {arrayList.Capacity}");

            if (arrayList.Count > 0)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(" Items:");

                foreach (var item in arrayList)
                {
                    Console.Write($" {item}");
                }

                Console.WriteLine(string.Empty);
            }

            Console.WriteLine("==============================");
        }
    }
}
