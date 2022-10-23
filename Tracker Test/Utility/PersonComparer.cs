using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker_Test.Models;

namespace Tracker_Test.Utility
{
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.User == y.User;
        }
        public int GetHashCode(Person obj)
        {
            return obj.User.GetHashCode();
        }
    }
}
