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
using System.Dynamic;
using CsvHelper.Configuration;

namespace SemesterProject2.ViewModels
{
    public class Scenario1ViewModel : ViewModelBase
    {
        public class Sc1DataWinter()
        {
            public double Sc1GBWi {get; set;}
            public double Sc1OBWi {get; set;}
            public string? TimeWi {get; set;}

        }

        public class Sc1DataSummer
        {
            public double Sc1GBWi {get; set;}
            public double Sc1OBWi {get; set;}
            public string? TimeSu {get; set;}
        }

        private List<double> _sc1GBDataWi;
        public List<double> Sc1GBDataWi
        {
            get => _sc1GBDataWi;
            set => this.RaiseAndSetIfChanged(ref _sc1GBDataWi, value);
        }
        private List<double> _sc1OBDataWi;
        public List<double> Sc1OBDataWi
        {
            get => _sc1OBDataWi;
            set => this.RaiseAndSetIfChanged(ref _sc1OBDataWi, value);
        }

        private List<string> _timeFromWi;
        public List<string> TimeFromWi
        {
            get => _timeFromWi;
            set => this.RaiseAndSetIfChanged(ref _timeFromWi, value);
        }

        private List<double> _sc1GBDataSu;
        public List<double> Sc1GBDataSu
        {
            get => _sc1GBDataSu;
            set => this.RaiseAndSetIfChanged(ref _sc1GBDataSu, value);
        }

        private List<double> _sc1OBDataSu;
        public List<double> Sc1OBDataSu
        {
            get => _sc1OBDataSu;
            set => this.RaiseAndSetIfChanged(ref _sc1OBDataSu, value);
        }

        private List<string> _timeFromSu;
        public List<string> TimeFromSu
        {
            get => _timeFromSu;
            set => this.RaiseAndSetIfChanged(ref _timeFromSu, value);
        }

        public LabelVisual Scenario1Wi { get; set; } =
        new LabelVisual
        {
            Text = "Winter",
            TextSize = 18,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };

        public LabelVisual Scenario1Su { get; set; } =
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

        public Scenario1ViewModel()
        {

            _sc1GBDataWi = new List<double>();
            _sc1OBDataWi = new List<double>();
            _timeFromWi = new List<string>();
            
            string fileName = "S1winter.csv";
            string path = Path.Combine(Environment.CurrentDirectory, "CSV", fileName);

            using (var streamReader = new StreamReader(path))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };
                using (var csvReader = new CsvReader(streamReader, csvConfig))
                {
                    
                    var records = csvReader.GetRecords<Scenario1Data>();
                    
                    foreach (var record in records)
                    {
                        _sc1GBDataWi.Add(record.GB);
                        _sc1OBDataWi.Add(record.OB);
                        _timeFromWi.Add(record.TimeFrom);
                    }
                }
            }
            Sc1GBDataWi = _sc1GBDataWi;
            Sc1OBDataWi = _sc1OBDataWi;
            TimeFromWi = _timeFromWi;

            _sc1GBDataSu = new List<double>();
            _sc1OBDataSu = new List<double>();
            _timeFromSu = new List<string>();
            
            string fileName2 = "S1summer.csv";
            string path2 = Path.Combine(Environment.CurrentDirectory, "CSV", fileName2);

            using (var streamReader = new StreamReader(path2))
            {
                 var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };
                using (var csvReader = new CsvReader(streamReader, csvConfig))
                {
                    var records = csvReader.GetRecords<Scenario1Data>();
                    
                    foreach (var record in records)
                    {
                        _sc1GBDataSu.Add(record.GB);
                        _sc1OBDataSu.Add(record.OB);
                        _timeFromSu.Add(record.TimeFrom);
                    } 
                }
            }
            Sc1GBDataSu = _sc1GBDataSu;
            Sc1OBDataSu = _sc1OBDataSu;
            TimeFromSu = _timeFromSu;

            SeriesWi.Add(new LineSeries<double>
            {
                Values = Sc1GBDataWi,
                Name = "Gas Boiler",
                Stroke = new SolidColorPaint(SKColors.Orange) { StrokeThickness = 4 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
                
            });

            SeriesWi.Add(new LineSeries<double>
            {
                Values = Sc1OBDataWi,
                Name = "Oil Boiler",
                Stroke = new SolidColorPaint(SKColors.Brown) { StrokeThickness = 4 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
                
            });

            SeriesSu.Add(new LineSeries<double>
            {
                Values = Sc1GBDataSu,
                Name = "Gas Boiler",
                Stroke = new SolidColorPaint(SKColors.Orange) { StrokeThickness = 4 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
            });

            SeriesSu.Add(new LineSeries<double>
            {
                Values = Sc1OBDataSu,
                Name = "Oil Boiler",
                Stroke = new SolidColorPaint(SKColors.Brown) { StrokeThickness = 4 },
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
                    Name = "MWh",
                    NameTextSize = 12,
                }
            };

            YAxesSu = new List<Axis>
            {
                new Axis
                {
                    Name = "MWh",
                    NameTextSize = 12,
                }
            };

        }

        public class Scenario1Data
        {
            [Name("Time from")]
            public string TimeFrom { get; set; } = string.Empty;
            [Name("Time to")]
            public string? TimeTo { get; set; } 
            [Name("Heat Demand")]
            public double HeatDemand { get; set; }
            [Name("GB")]
            public double GB  { get; set; }
            [Name("OB")]
            public double OB  { get; set; }
        }

    }
}