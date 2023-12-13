using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
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
                [thenBy] = 2
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
                if (property1 != null && _sortParameter[orderBy] == 1 && 
                    property2 != null && _sortParameter[thenBy] == 2)
                {
                    return list.OrderBy(x => property1.GetValue(x, null)).ThenByDescending(x => property2.GetValue(x, null)).ToList();
                }
                else
                {
                    Console.WriteLine($"Свойство {orderBy}  или {thenBy} не найдено");
                    return list;
                }
            }

            foreach (Person person in sortedPersons)
            {
                Console.WriteLine($"{person.LastName}\t {person.FirstName}\t\t {person.Age}");
            }
            Console.WriteLine();



            Console.WriteLine();




            Console.ReadKey();
        }
    }
}
