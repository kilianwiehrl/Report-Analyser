using Report_Analyser.model;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Report Analyser Started >>>");
            ReportManager reportManager = new ReportManager();
            reportManager.printReports();
            Console.WriteLine(Environment.NewLine + "Press any key to exit");
            Console.ReadKey();
        }
    }
}