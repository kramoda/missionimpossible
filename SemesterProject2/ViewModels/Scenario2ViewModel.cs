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
    public class Scenario2ViewModel : ViewModelBase
    {
        public class Sc2DataWinter()
        {
            public double Sc2GBWi {get; set;}
            public double Sc2OBWi {get; set;}
            public double Sc2EKWi {get; set;}
            public double Sc2GMWi {get; set;}
            public string? TimeWi {get; set;}

        }

        public class Sc2DataSummer
        {
            public double Sc2GBWi {get; set;}
            public double Sc2OBWi {get; set;}
            public double Sc2EKWi {get; set;}
            public double Sc2GMWi {get; set;}
            public string? TimeSu {get; set;}
        }

        private List<double> _sc2GBDataWi;
        public List<double> Sc2GBDataWi
        {
            get => _sc2GBDataWi;
            set => this.RaiseAndSetIfChanged(ref _sc2GBDataWi, value);
        }
        private List<double> _sc2OBDataWi;
        public List<double> Sc2OBDataWi
        {
            get => _sc2OBDataWi;
            set => this.RaiseAndSetIfChanged(ref _sc2OBDataWi, value);
        }
        private List<double> _sc2EKDataWi;
        public List<double> Sc2EKDataWi
        {
            get => _sc2EKDataWi;
            set => this.RaiseAndSetIfChanged(ref _sc2EKDataWi, value);
        }
        private List<double> _sc2GMDataWi;
        public List<double> Sc2GMDataWi
        {
            get => _sc2GMDataWi;
            set => this.RaiseAndSetIfChanged(ref _sc2GMDataWi, value);
        }

        private List<string> _timeFromWi;
        public List<string> TimeFromWi
        {
            get => _timeFromWi;
            set => this.RaiseAndSetIfChanged(ref _timeFromWi, value);
        }

        private List<double> _sc2GBDataSu;
        public List<double> Sc2GBDataSu
        {
            get => _sc2GBDataSu;
            set => this.RaiseAndSetIfChanged(ref _sc2GBDataSu, value);
        }

        private List<double> _sc2OBDataSu;
        public List<double> Sc2OBDataSu
        {
            get => _sc2OBDataSu;
            set => this.RaiseAndSetIfChanged(ref _sc2OBDataSu, value);
        }
        private List<double> _sc2EKDataSu;
        public List<double> Sc2EKDataSu
        {
            get => _sc2EKDataSu;
            set => this.RaiseAndSetIfChanged(ref _sc2EKDataSu, value);
        }
        private List<double> _sc2GMDataSu;
        public List<double> Sc2GMDataSu
        {
            get => _sc2GMDataSu;
            set => this.RaiseAndSetIfChanged(ref _sc2GMDataSu, value);
        }

        private List<string> _timeFromSu;
        public List<string> TimeFromSu
        {
            get => _timeFromSu;
            set => this.RaiseAndSetIfChanged(ref _timeFromSu, value);
        }

        public LabelVisual Scenario2Wi { get; set; } =
        new LabelVisual
        {
            Text = "Winter",
            TextSize = 18,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };

        public LabelVisual Scenario2Su { get; set; } =
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

        public Scenario2ViewModel()
        {

            _sc2GBDataWi = new List<double>();
            _sc2OBDataWi = new List<double>();
            _sc2EKDataWi = new List<double>();
            _sc2GMDataWi = new List<double>();
            _timeFromWi = new List<string>();
            
            string fileName = "S2winter.csv";
            string path = Path.Combine(Environment.CurrentDirectory, "CSV", fileName);

            using (var streamReader = new StreamReader(path))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };
                using (var csvReader = new CsvReader(streamReader, csvConfig))
                {
                    
                    var records = csvReader.GetRecords<Scenario2Data>();
                    
                    foreach (var record in records)
                    {
                        _sc2GBDataWi.Add(record.GB);
                        _sc2OBDataWi.Add(record.OB);
                        _sc2EKDataWi.Add(record.EK);
                        _sc2GMDataWi.Add(record.GM);
                        _timeFromWi.Add(record.TimeFrom);
                    }
                }
            }
            Sc2GBDataWi = _sc2GBDataWi;
            Sc2OBDataWi = _sc2OBDataWi;
            Sc2EKDataWi = _sc2EKDataWi;
            Sc2GMDataWi = _sc2GMDataWi;
            TimeFromWi = _timeFromWi;

            _sc2GBDataSu = new List<double>();
            _sc2OBDataSu = new List<double>();
            _sc2EKDataSu = new List<double>();
            _sc2GMDataSu = new List<double>();
            _timeFromSu = new List<string>();
            
            string fileName2 = "S2summer.csv";
            string path2 = Path.Combine(Environment.CurrentDirectory, "CSV", fileName2);

            using (var streamReader = new StreamReader(path2))
            {
                 var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };
                using (var csvReader = new CsvReader(streamReader, csvConfig))
                {
                    var records = csvReader.GetRecords<Scenario2Data>();
                    
                    foreach (var record in records)
                    {
                        _sc2GBDataSu.Add(record.GB);
                        _sc2OBDataSu.Add(record.OB);
                        _sc2EKDataSu.Add(record.EK);
                        _sc2GMDataSu.Add(record.GM);
                        _timeFromSu.Add(record.TimeFrom);
                    } 
                }
            }
            Sc2GBDataSu = _sc2GBDataSu;
            Sc2OBDataSu = _sc2OBDataSu;
            Sc2EKDataSu = _sc2EKDataSu;
            Sc2GMDataSu = _sc2GMDataSu;
            TimeFromSu = _timeFromSu;

            SeriesWi.Add(new LineSeries<double>
            {
                Values = Sc2GBDataWi,
                Name = "Gas Boiler",
                Stroke = new SolidColorPaint(SKColors.Orange) { StrokeThickness = 4 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
                
            });

            SeriesWi.Add(new LineSeries<double>
            {
                Values = Sc2OBDataWi,
                Name = "Oil Boiler",
                Stroke = new SolidColorPaint(SKColors.Brown) { StrokeThickness = 4 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
                
            });
            
            SeriesWi.Add(new LineSeries<double>
            {
                Values = Sc2EKDataWi,
                Name = "Electric Boiler",
                Stroke = new SolidColorPaint(SKColors.LightGreen) { StrokeThickness = 4 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
                
            });
            
            SeriesWi.Add(new LineSeries<double>
            {
                Values = Sc2GMDataWi,
                Name = "Gas Motor",
                Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
                
            });


            SeriesSu.Add(new LineSeries<double>
            {
                Values = Sc2GBDataSu,
                Name = "Gas Boiler",
                Stroke = new SolidColorPaint(SKColors.Orange) { StrokeThickness = 4 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
            });

            SeriesSu.Add(new LineSeries<double>
            {
                Values = Sc2OBDataSu,
                Name = "Oil Boiler",
                Stroke = new SolidColorPaint(SKColors.Brown) { StrokeThickness = 4 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
            });

            SeriesSu.Add(new LineSeries<double>
            {
                Values = Sc2EKDataSu,
                Name = "Electric Boiler",
                Stroke = new SolidColorPaint(SKColors.LightGreen) { StrokeThickness = 4 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
                
            });
            
            SeriesSu.Add(new LineSeries<double>
            {
                Values = Sc2GMDataSu,
                Name = "Gas Motor",
                Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 },
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
                    MinLimit = 0,
                }
            };

            YAxesSu = new List<Axis>
            {
                new Axis
                {
                    Name = "MWh",
                    NameTextSize = 12,
                    MinLimit = 0,
                }
            };

        }

        public class Scenario2Data
        {
            [Name("Time from")]
            public string TimeFrom { get; set; } = string.Empty;
            [Name("Time to")]
            public string? TimeTo { get; set; } 
            [Name("Heat Demand")]
            public double HeatDemand { get; set; }
            [Name("Electricity Price")]
            public double ElectricityPrice { get; set; }
            [Name("GB")]
            public double GB  { get; set; }
            [Name("OB")]
            public double OB  { get; set; }
            [Name("EK")]
            public double EK  { get; set; }
            [Name("GM")]
            public double GM  { get; set; }
        }

    }
}