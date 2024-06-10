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
            string prevLine = "";
            string line;
            bool isFirst = true;
            Report report = new Report();

            while ((line = sr.ReadLine()) != null) {
                switch (prevLine.Trim()) {
                    case "Bug-Report:": {
                            if (reportDictionary.Count == 0 && isFirst) {
                                report = new Report();
                                isFirst = false;
                            } else {
                                reportDictionary.Add(DateTime.Now.Ticks.ToString() + report.Client.Name, report);
                                report = new Report();
                            }
                            prevLine = line; break;
                        }
                    case "Client ID:": {
                            report.Client.Id = line;
                            prevLine = line; break;
                        }
                    case "Client Name:": {
                            report.Client.Name = line;
                            prevLine = line; break;
                        }
                    case "IPv4:": {
                            report.Client.IPv4 = line;
                            prevLine = line; break;
                        }
                    case "App Name:": {
                            report.AppName = line;
                            prevLine = line; break;
                        }
                    case "App Version:": {
                            report.AppVersion = line;
                            prevLine = line; break;
                        }
                    case "Exception Class": {
                            report.ExceptionClass = line;
                            prevLine = line; break;
                        }
                    case "Exception Message:": {
                            report.ExceptionMessage = line;
                            prevLine = line; break;
                        }
                    case "Username:": {
                            report.User.Name = line;
                            prevLine = line; break;
                        }
                    case "UserMail:": {
                            report.User.Email = line;
                            prevLine = line; break;
                        }
                    case "Publisher:": {
                            report.Publisher = line;
                            prevLine = line; break;
                        }
                    case "Publisher E-Mail:": {
                            report.PublisherEmail = line;
                            prevLine = line; break;
                        }
                    case "Call Stack:": {
                            report.CallStack.Add(line);
                            prevLine = line; break;
                        }
                    default: prevLine = line; break;
                }
            }

            reportDictionary.Add(DateTime.Now.Ticks.ToString() + report.Client.Name, report);
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
