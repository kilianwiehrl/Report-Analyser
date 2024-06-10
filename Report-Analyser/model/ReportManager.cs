using System.Reflection;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace Report_Analyser.model {
    internal class ReportManager {

        private const string filepath = "/res/bugreport_1.txt";
        private StreamReader sr;
        private Dictionary<string, Report> reportDictionary = new Dictionary<string, Report>();

        public ReportManager() {
            sr = new StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + filepath);
        }

        public void readReports() {
            /*
             * Your Code starts here:
             * 
             * Good luck!
             */
        }


        public void printReports() {
            foreach (Report report in reportDictionary.Values) {
                Console.WriteLine("------------------------------------------------------------------------");
                JObject parsed = JObject.Parse(JsonSerializer.Serialize<Report>(report));

                foreach (var pair in parsed) {
                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                }
            }

            Console.WriteLine("------------------------------------------------------------------------");
        }
    }
}
