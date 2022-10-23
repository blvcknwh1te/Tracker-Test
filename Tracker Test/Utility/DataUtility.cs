using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker_Test.Models;

namespace Tracker_Test.Utility
{
    public static class DataUtility
    {

        public static void AnalysePersonSteps(List<Day> days, Person person)
        {
            int daysAmount = days.Count;
            Person requiredPerson = new Person();


            int personStepsSum = 0;
            List<int> personStepsList = new List<int>();

            double avgSteps = 0;
            

            if (daysAmount > 0)
            {
                int personIndex = days[0].Persons.IndexOf(person);
                foreach (Day day in days)
                {
                    requiredPerson = day.Persons.Where(p => p.User == person.User).
                        Cast<Person>().SingleOrDefault();

                    if (requiredPerson!=null)
                    {
                        personStepsSum += requiredPerson.Steps;
                        personStepsList.Add(requiredPerson.Steps);
                    }
                    else
                    {
                        personStepsList.Add(0);
                    }
                }
                avgSteps = personStepsSum / daysAmount;
            }
            person.AvgSteps = Math.Round(avgSteps, 2);
            person.AllSteps = personStepsList.ToArray();

            if (personStepsList.Count > 0)
            {
                person.BestResult = personStepsList.Max();
                person.WorstResult = personStepsList.Min();
            }
            
        }


    }
}
