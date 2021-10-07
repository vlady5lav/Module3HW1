using System;

namespace ModuleHW
{
    public class Starter
    {
        public void Run()
        {
            var intList = new ArrayList<int>();
            ListInfo(intList);

            var intArray = new int[] { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            for (int i = 0; i < 10; i++)
            {
                intList.Add(i);
            }

            ListInfo(intList);

            intList.AddRange(intArray);
            ListInfo(intList);

            intList.RemoveAt(5);
            ListInfo(intList);

            intList.RemoveAtRange(6, 8, 9, 10, 14, 16, 20, 22);
            ListInfo(intList);

            intList.InsertRange(14, 2, 22, 222, 2222, 44, 45);
            ListInfo(intList);

            intList.Remove(10);
            ListInfo(intList);

            intList.RemoveRange(0, 6, 16, 30, 50, 70, 90, 101);
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

            stringList.RemoveAtRange(5, 6, 7, 11, 12, 14, 16, 20, 21, 22);
            ListInfo(stringList);

            stringList.RemoveRange("five", "cinque", "dieci", "extra");
            ListInfo(stringList);

            stringList.AddItems("five", "cinque", "dieci", "undici");
            ListInfo(stringList);

            stringList.Insert(4, "INSERTATION1");
            stringList.Insert(4, "INSERTATION2");
            stringList.Insert(4, "INSERTATION3");
            ListInfo(stringList);

            stringList.InsertRange(4, "INSERTATION4", "INSERTATION5", "INSERTATION6", "INSERTATION7", "INSERTATION8");
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
