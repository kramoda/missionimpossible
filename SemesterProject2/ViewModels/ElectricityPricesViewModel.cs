using ReactiveUI;
using SemesterProject2.ViewModels;
using System.Reactive;
using CSVConnection;
using System.Data;

namespace SemesterProject2.ViewModels
{
    public class ElectricityPricesViewModel : ViewModelBase
    {

        static void WinterDataTable(string[] args)
        {
        CSVConnect obj = new CSVConnect();
        DataTable WinterData = obj.CSVDatatable(@"SemesterProject2\CSV\2024HeatProductionOptimizationWinter.csv");
        }

        static void SummerDataTable(string[] args)
        {
        CSVConnect obj = new CSVConnect();
        DataTable SummerData = obj.CSVDatatable(@"SemesterProject2\CSV\2024HeatProductionOptimizationSummer.csv");
        }

    }

}