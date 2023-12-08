﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static MyCustomSortProject.Repository;

namespace MyCustomSortProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string orderBy = "LastName";
            string thenBy = "FirstName";

            Dictionary<string, int> sortParameter = new Dictionary<string, int>()
            {
                [orderBy] = 1,
                [thenBy] = 1
            };

            foreach (Person person in Persons)
            {
                Console.WriteLine($"{person.LastName}\t {person.FirstName}\t\t {person.Age}");
            }
            Console.WriteLine();

            List<Person> sortedPersons = CustomSort(Persons, sortParameter);

            List<Person> CustomSort(List<Person> list, Dictionary<string, int> _sortParameter)
            {
                PropertyInfo property1 = typeof(Person).GetProperty(orderBy);
                PropertyInfo property2 = typeof(Person).GetProperty(thenBy);
                if (property1 != null && property2 != null)
                {
                    return list.OrderBy(x => property1.GetValue(x, null)).ThenBy(x => property2.GetValue(x, null)).ToList();
                }
                else
                {
                    Console.WriteLine($"Свойство {orderBy}  или {thenBy} не найдено");
                    return list;
                }
            }






            Console.WriteLine();




            Console.ReadKey();
        }
    }
}
