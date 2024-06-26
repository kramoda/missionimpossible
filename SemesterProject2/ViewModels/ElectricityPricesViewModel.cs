using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;

namespace SemesterProject2.ViewModels
{
    public class ElectricityPricesViewModel : ViewModelBase
    { 
        private List<double> _ePricesWi;
        public List<double> EPricesWi
        {
            get => _ePricesWi;
            set => this.RaiseAndSetIfChanged(ref _ePricesWi, value);
        }
        

        private List<string> _timeFromWi;
        public List<string> TimeFromWi
        {
            get => _timeFromWi;
            set => this.RaiseAndSetIfChanged(ref _timeFromWi, value);
        }

        private List<double> _ePricesSu;
        public List<double> EPricesSu
        {
            get => _ePricesSu;
            set => this.RaiseAndSetIfChanged(ref _ePricesSu, value);
        }

        private List<string> _timeFromSu;
        public List<string> TimeFromSu
        {
            get => _timeFromSu;
            set => this.RaiseAndSetIfChanged(ref _timeFromSu, value);
        }


        public LabelVisual ElectricityPricesWi { get; set; } =
        new LabelVisual
        {
            Text = "Winter",
            TextSize = 18,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };

        public LabelVisual ElectricityPricesSu { get; set; } =
        new LabelVisual
        {
            Text = "Summer",
            TextSize = 18,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };

        public List<ISeries> SeriesWi { get; set; } = new();
        public List<ISeries> SeriesSu { get; set; } = new();  
        public List<Axis> XAxesWi { get; set; } = new();
        public List<Axis> XAxesSu { get; set; } = new();
        public List<Axis> YAxesWi { get; set; } = new();
        public List<Axis> YAxesSu { get; set; } = new();
        
      
        public ElectricityPricesViewModel()
        {
            _ePricesWi = new List<double>();
            _timeFromWi = new List<string>();
            
            string fileName = "2024HeatProductionOptimizationWinter.csv";
            string path = Path.Combine(Environment.CurrentDirectory, "CSV", fileName);

            using (var streamReader = new StreamReader(path))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<HeatProductionData>();
                    
                    foreach (var record in records)
                    {
                        _ePricesWi.Add(record.ElectricityPrice);
                        _timeFromWi.Add(record.TimeFrom);
                    }
                }
            }
            EPricesWi = _ePricesWi;
            TimeFromWi = _timeFromWi;


            _ePricesSu = new List<double>();
            _timeFromSu = new List<string>();
            
            string fileName2 = "2024HeatProductionOptimizationSummer.csv";
            string path2 = Path.Combine(Environment.CurrentDirectory, "CSV", fileName2);

            using (var streamReader = new StreamReader(path2))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<HeatProductionData>();
                    
                    foreach (var record in records)
                    {
                        _ePricesSu.Add(record.ElectricityPrice);
                        _timeFromSu.Add(record.TimeFrom);
                    } 
                }
            }
            EPricesSu = _ePricesSu;
            TimeFromSu = _timeFromSu;

            SeriesWi.Add(new LineSeries<double>
            {
                Values = EPricesWi,
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
                
            });

            SeriesSu.Add(new LineSeries<double>
            {
                Values = EPricesSu,
                Stroke = new SolidColorPaint(SKColors.LightCoral) { StrokeThickness = 4 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
            });

            XAxesWi = new List<Axis>
            {
                new Axis
                {
                    Name = "DKK local time",
                    NameTextSize = 12,
                    Labels = TimeFromWi 
                }
            };

            XAxesSu = new List<Axis>
            {
                new Axis
                {
                    Name = "DKK local time",
                    NameTextSize = 12,
                    Labels = TimeFromSu 
                }
            };

            YAxesWi = new List<Axis>
            {
                new Axis
                {
                    Name = "DKK / Mwh(el)",
                    NameTextSize = 12,
                }
            };

            YAxesSu = new List<Axis>
            {
                new Axis
                {
                    Name = "DKK / Mwh(el)",
                    NameTextSize = 12,
                }
            };
        }

        public class HeatProductionData
        {
            [Name("Time from")]
            public string TimeFrom { get; set; } = string.Empty;
            [Name("Time to")]
            public string? TimeTo { get; set; }
            [Name("Heat Demand")]
            public double HeatDemand { get; set; }
            [Name("Electricity Price")]
            public double ElectricityPrice  { get; set; }
        }
    }

}