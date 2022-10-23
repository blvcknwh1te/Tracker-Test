using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker_Test.Models;
using Tracker_Test.Utility;

namespace Tracker_Test.Data
{
    public static class DataHandler
    {
        private static List<Day> allDays = new List<Day>();
        private static List<Person> allPersons = new List<Person>();

        public static List<Person> GetAllPersons()
        {
            if (allDays.Count > 0)
            {
                allPersons = (allDays[0].Persons);

                foreach(Day day in allDays)
                {
                    if (allPersons.Select(a=>a.User).Except(day.Persons.Select(p=>p.User)).Any())
                    {
                        PersonComparer personComparer = new PersonComparer();
                        allPersons = allPersons.Union(day.Persons,personComparer).ToList();
                    }
                }

                return allPersons.OrderBy(o => o.User).ToList();
            }
            else
                return new List<Person>();
        }

        public static void AnalyseAllSteps()
        {
            foreach (Person person in allPersons)
            {
                DataUtility.AnalysePersonSteps(allDays, person);
            }
        }

        public static List<Day> GetAllDays()
        {
            return allDays;
        }

        public static void AddDays(List<Day> newDays)
        {
            allDays.AddRange(newDays);
        }

        public static void AddPersons(List<Person> newPersons)
        {
            allPersons.AddRange(newPersons);
        }

    }
}
