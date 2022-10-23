using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker_Test.Models;
using System.Text.RegularExpressions;

namespace Tracker_Test.Utility
{
    public static class JsonParser
    {
        private static string dataPath;
        static Regex daysRegEx;

        static JsonParser()
        {
            DataPath = Path.Combine(Environment.CurrentDirectory, "Data\\");
            daysRegEx = new Regex(@"^day\d{1,2}\.json$");

        }
        public static string DataPath
        {
            get => dataPath;
            private set => dataPath = value;
        }

        public static List<Day> ParseDaysFromJson()
        {
            List<Day> allDays = new List<Day>();

            var allFiles = new DirectoryInfo(DataPath).GetFiles();

            var correctFiles = (allFiles.
                Select(o => o.Name).
                ToList()).
                Where(f => daysRegEx.IsMatch(f)).ToList();

            if (correctFiles.Count > 0 && correctFiles.Count < 32)
            {
                foreach (var file in correctFiles)
                {
                    Day newDay = new Day();
                    newDay.Persons = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(DataPath + file)).OrderBy(o => o.User).ToList();
                    allDays.Add(newDay);
                }
            }

            return allDays;
        }

        public static void ParsePersonToJson(Person person, string fileName)
        {
            if (person != null)
            {
                var jsonOut = Newtonsoft.Json.JsonConvert.SerializeObject(person);
                var pathOut = Path.Combine(Environment.CurrentDirectory, fileName);
                File.WriteAllText(pathOut, jsonOut);
            }

        }
    }
}
