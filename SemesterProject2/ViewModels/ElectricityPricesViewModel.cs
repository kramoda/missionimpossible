using ReactiveUI;
using SemesterProject2.ViewModels;
using System.Reactive;
using CSVConnection;
using System.Data;
using System;
using System.Collections.ObjectModel;
using Avalonia.Markup.Xaml.Templates;
using System.Collections.Generic;
using System.Linq.Expressions;
using Avalonia.Controls;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using DynamicData.Binding;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Reactive.Linq;
using System.ComponentModel;

namespace SemesterProject2.ViewModels
{
    public class ElectricityPricesViewModel : ViewModelBase
    {
        
        //public ObservableCollection<EPriceDataWinter> WiGridData {get;} = new();
        
        public class EPriceDataWinter()
        {
            public double EPricesWi {get; set;}
            public string? TimeWi {get; set;}


        }

        public class EPriceDataSummer
        {
            public double EPricesSu {get; set;}
            public string? TimeSu {get; set;}
        }

        /*
        public List<object> _WiGridData;
        List<object> WiGridData
        {
            get => _WiGridData;
            set => this.RaiseAndSetIfChanged(ref _WiGridData, value);
        }
        */

        //DKK local time,DKK local time,MWh,DKK / Mwh(el)

        private List<double> _ePrices;

        public List<double> EPrices
        {
            get => _ePrices;
            set => this.RaiseAndSetIfChanged(ref _ePrices, value);
        }
      
        public ElectricityPricesViewModel()
        {
            _ePrices = new List<double>();
            
            string fileName = "2024HeatProductionOptimizationWinter.csv";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            using (var streamReader = new StreamReader(path))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<WinterData>();
                    
                    foreach (var record in records)
                    {
                        _ePrices.Add(record.ElectricityPrice);
                    }
                    
                    
                }
              
            }
            EPrices = _ePrices;
            


            /*
           _WiGridData = new List<object>();
           _WiGridData.Add("1");
            */
            /*
            CSVConnect obj = new CSVConnect();
            DataTable WinterData = obj.CSVDatatable(@"SemesterProject2\CSV\2024HeatProductionOptimizationWinter.csv");
            
            var tempList = new List<object>();

            foreach (DataRow row in WinterData.Rows)
            {
                var temp = new EPriceDataWinter();
                temp.TimeWi = row["Time from"].ToString();
                temp.EPricesWi = double.Parse(row["Electricity Price"].ToString()!);
                WiGridData.Add(temp);
            }
            */

            //WiGridData = tempList;
            /*
            CSVConnect obj2 = new CSVConnect();
            DataTable SummerData = obj.CSVDatatable(@"SemesterProject2\CSV\2024HeatProductionOptimizationSummer.csv");
        
            var tempList2 = new List<object>();

            foreach (DataRow row in SummerData.Rows)
            {
                var temp = new EPriceDataSummer();
                temp.TimeSu = row["Time from"].ToString();
                temp.EPricesSu = double.Parse(row["Electricity Price"].ToString()!);
                tempList2.Add(temp);

            }

            SuGridData = tempList2;
            */

        }
        public class WinterData
        {
            [Name("Time from")]
            public string? TimeFrom { get; set; }
            [Name("Time to")]
            public string? TimeTo { get; set; }
            [Name("Heat Demand")]
            public double HeatDemand { get; set; }
            [Name("Electricity Price")]
            public double ElectricityPrice  { get; set; }
        }
        
        
        /*
        public List<object> _SuGridData;
        List<object> SuGridData
        {
            get => _SuGridData;
            set => this.RaiseAndSetIfChanged(ref _SuGridData, value);
        }
        */

     /*
        static void WinterDataTable(string[] args, List<object> WiGridData)
        {
        
            CSVConnect obj = new CSVConnect();
            DataTable WinterData = obj.CSVDatatable(@"SemesterProject2\CSV\2024HeatProductionOptimizationWinter.csv");
            
            var tempList = new List<object>();

            foreach (DataRow row in WinterData.Rows)
            {
                var temp = new EPriceDataWinter();
                temp.TimeWi = row["DKK local time"].ToString();
                temp.EPricesWi = double.Parse(row["DKK / Mwh(el)"].ToString()!);
                tempList.Add(temp);
            }

            WiGridData = tempList;
        }
     */
        

     /*
        static void SummerDataTable(string[] args, List<object> SuGridData)
        {
        CSVConnect obj = new CSVConnect();
        DataTable SummerData = obj.CSVDatatable(@"SemesterProject2\CSV\2024HeatProductionOptimizationSummer.csv");
        
        var tempList = new List<object>();

            foreach (DataRow row in SummerData.Rows)
            {
                var temp = new EPriceDataSummer();
                temp.TimeSu = row["DKK local time"].ToString();
                temp.EPricesSu = double.Parse(row["DKK / Mwh(el)"].ToString()!);
                tempList.Add(temp);

            }

            SuGridData = tempList;
        
        }
     */
    }

}