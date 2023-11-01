using System;
using System.Collections.Generic;

namespace Application.Other
{
    public class PredicateExample
    {
        // Metoda przyjmująca predykat jako argument i zwracająca listę elementów spełniających predykat
        public static List<T> FilterWithPredicate<T>(List<T> list, Predicate<T> predicate)
        {
            List<T> filteredList = new List<T>();

            foreach (T item in list)
            {
                if (predicate(item))
                {
                    filteredList.Add(item);
                }
            }

            return filteredList;
        }
    }

    public class FuncExample
    {
        public static List<T> TransformWithFunc<T>(List<T> list, Func<T, bool> func)
        {
            List<T> transformedList = new List<T>();

            foreach (T item in list)
            {
                if (func(item))
                    transformedList.Add(item);
            }

            return transformedList;
        }
    }

    public class ExampleUsage
    {
        public static void FuncExampleMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var oddNumbers = FuncExample.TransformWithFunc(numbers, x => x % 2 == 1);
        }

        public static void PredicateTExampleMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> evenNumbers = PredicateExample.FilterWithPredicate(numbers, x => x % 2 == 0);
        }
    }
}
