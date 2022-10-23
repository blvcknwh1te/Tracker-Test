using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker_Test.Models
{
    public class Person
    {

        public string User { get; set; }
        public string Status { get; set; }
        public int Rank { get; set; }
        public int Steps { get; set; }
        public double AvgSteps { get; set; }
        public int BestResult { get; set; }
        public int WorstResult { get; set; }
        public int[] AllSteps { get; set; }
        public bool IsDifferent
        {
            get
            {
                return ((BestResult - AvgSteps) / BestResult) * 100 > 20 ||
                    ((AvgSteps - WorstResult) / WorstResult) * 100 > 20;
            }
            private set
            {
                IsDifferent = value;
            }
        }

        public Person()
        {

        }

        public Person(Person person)
        {
            User = person.User;
            Status = person.Status;
            Rank = person.Rank;
            Steps = person.Steps;
            AvgSteps = person.AvgSteps;
            BestResult = person.BestResult;
            WorstResult = person.WorstResult;
            AllSteps = person.AllSteps;
            IsDifferent = person.IsDifferent;
        }

    }

    //enum Status
    //{
    //    Finished,
    //    Active,
    //    Refused
    //}
}
