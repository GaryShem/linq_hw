using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_hw
{
    class Program
    {
        static void Main(string[] args)
        {
            f1();
            f2();
            f3();
            f4();
            f5();
        }

        private static void f5()
        {
//z5
            //есть три коллекции arr1, arr2, arr3
            //надо создать коллекцию из всех возможных троек элементов
            var arr1 = new[] {1, 2, 3};
            var arr2 = new[] {4, 5, 6};
            var arr3 = new[] {7, 8, 9};
            var n5 =
                from a1 in arr1
                from a2 in arr2
                from a3 in arr3
                select new {a1, a2, a3};

            var n5_string = string.Join(", ",
                from a in n5 select string.Format("({0}, {1}, {2})", a.a1, a.a2, a.a3));

            Console.WriteLine(n5_string);
        }

        private static void f4()
        {
//z4
            //дана коллекция повторяющихся элементов
            //составить новую коллекцию, в которую попадут в одном экземпляре те эл-ты, которые встречаются в исходной коллекции ровно 3 раза
            int[] a = new[] {3, 2, 8, 4, 2, 5, 3, 9, 1, 4, 2, 6, 7, 4, 7};

            var n4 = a.Where(i => a.Count(i1 => i1 == i) == 3).GroupBy(x_ => x_).Select(ints => ints.Key);
            foreach (var i in n4)
            {
                Console.WriteLine(i);
            }
        }

        private static void f3()
        {
//z3
            //дана коллекция пар - фамилия и сумма
            //необходимо составить итоговую коллекцию - фамилия и сумма всех сумм для данной фамилии
            KeyValuePair<string, int>[] kvp = new[]
            {
                new KeyValuePair<string, int>("Иванов", 2),
                new KeyValuePair<string, int>("Петров", 3),
                new KeyValuePair<string, int>("Иванов", 10),
                new KeyValuePair<string, int>("Петров", 6),
                new KeyValuePair<string, int>("Федоров", 1),
            };
            KeyValuePair<String, int> k = new KeyValuePair<string, int>("aa", 3);
            var n3 = kvp.GroupBy(x_ => x_.Key).Select(pairs => new {name = pairs.Key, sum = pairs.Sum(pair => pair.Value)});
            foreach (var el in n3)
            {
                Console.WriteLine(el);
            }
        }

        private static void f2()
        {
//z2
            //сгруппировать по чётности, для каждой группы посчитать сумму
            //итоговая коллекция должна содержать поле суммы и группу
            int[] a = new[] {3, 2, 8, 4, 2, 5, 3, 9, 1, 4, 2, 6, 7, 4, 7};
            var n = a.GroupBy(x_ => x_%2 == 0).Select(ints => new {s = ints.Sum(), col = ints.ToArray()});
            foreach (var el in n)
            {
                Console.WriteLine(el.s);
                el.col.ToList().ForEach(x_ => Console.Write("{0} ", x_));
                Console.WriteLine();
            }
        }

        private static void f1()
        {
//z1
            int[] a = new[] {3, 2, 8, 4, 2, 5, 3, 9, 1, 4, 2, 6, 7, 4, 7};
            var b = a.OrderBy(x_ => x_).GroupBy(x_ => x_%2 == 0);
            int i = 0;
            foreach (var col in b)
            {
                Console.WriteLine(i++);
                foreach (var i1 in col)
                {
                    Console.Write("{0}, ", i1);
                }
                Console.WriteLine();
            }
        }
    }
}
