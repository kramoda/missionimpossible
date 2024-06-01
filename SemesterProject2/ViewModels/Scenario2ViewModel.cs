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
using CsvHelper.Configuration;

namespace SemesterProject2.ViewModels
{
    public class Scenario2ViewModel : ViewModelBase
    {
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
        private List<double> _sc2EBDataWi;
        public List<double> Sc2EBDataWi
        {
            get => _sc2EBDataWi;
            set => this.RaiseAndSetIfChanged(ref _sc2EBDataWi, value);
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
        private List<double> _sc2EBDataSu;
        public List<double> Sc2EBDataSu
        {
            get => _sc2EBDataSu;
            set => this.RaiseAndSetIfChanged(ref _sc2EBDataSu, value);
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

        //Attempt at displaying the results from optimizer
        /*
        private List<string> _sc2SuResults;
        public List<string> Sc2SuResults
        {
            get => _sc2SuResults;
            set => this.RaiseAndSetIfChanged(ref _sc2SuResults, value);
        }
        private List<string> _sc2WiResults;
        public List<string> Sc2WiResults
        {
            get => _sc2WiResults;
            set => this.RaiseAndSetIfChanged(ref _sc2WiResults, value);
        }
        */

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
            _sc2EBDataWi = new List<double>();
            _sc2GMDataWi = new List<double>();
            _timeFromWi = new List<string>();
            
            string fileName = "S2Witer.csv";
            string path = Path.Combine(Environment.CurrentDirectory, "Scenario2", fileName);
    
            bool fileExists = CheckIfFileExists(path);
            static bool CheckIfFileExists(string path)
            {
                return File.Exists(path);
            }    
            
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
                        _sc2EBDataWi.Add(record.EB);
                        _sc2GMDataWi.Add(record.GM);
                        _timeFromWi.Add(record.TimeFrom);
                    }
                }
            }
            Sc2GBDataWi = _sc2GBDataWi;
            Sc2OBDataWi = _sc2OBDataWi;
            Sc2EBDataWi = _sc2EBDataWi;
            Sc2GMDataWi = _sc2GMDataWi;
            TimeFromWi = _timeFromWi;

            _sc2GBDataSu = new List<double>();
            _sc2OBDataSu = new List<double>();
            _sc2EBDataSu = new List<double>();
            _sc2GMDataSu = new List<double>();
            _timeFromSu = new List<string>();
            
            string fileName2 = "S2Sumer.csv";
            string path2 = Path.Combine(Environment.CurrentDirectory, "Scenario2", fileName2);
            
            bool fileExists1 = CheckIfFileExists1(path2);
            static bool CheckIfFileExists1(string path2)
            {
                return File.Exists(path2);
            }    

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
                        _sc2EBDataSu.Add(record.EB);
                        _sc2GMDataSu.Add(record.GM);
                        _timeFromSu.Add(record.TimeFrom);
                    } 
                }
            }
            Sc2GBDataSu = _sc2GBDataSu;
            Sc2OBDataSu = _sc2OBDataSu;
            Sc2EBDataSu = _sc2EBDataSu;
            Sc2GMDataSu = _sc2GMDataSu;
            TimeFromSu = _timeFromSu;

            //Attempt at displaying the results from optimizer
            /*
            string fileName3 = "S2summerResults.csv";
            string path3 = Path.Combine(Environment.CurrentDirectory, "Scenario2", fileName3);
             
            bool fileExists4 = CheckIfFileExists4(path3);
            static bool CheckIfFileExists4(string path3)
            {
                return File.Exists(path3);
            }    
        
            _sc2SuResults = new List<string>();

            using (var streamReader = new StreamReader(path3))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<S2SuResults>();
                    
                    foreach (var record in records)
                    {
                        _sc2SuResults.Add(record.S2suResults);
                    } 
                }
            }
            Sc2SuResults = _sc2SuResults;

            string fileName4 = "S2winterResults.csv";
            string path4 = Path.Combine(Environment.CurrentDirectory, "Scenario2", fileName4);
            
            bool fileExists5 = CheckIfFileExists5(path4);
            static bool CheckIfFileExists5(string path4)
            {
                return File.Exists(path4);
            }  

            _sc2WiResults = new List<string>();

            using (var streamReader = new StreamReader(path4))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<S2WiResults>();
                    
                    foreach (var record in records)
                    {
                        _sc2WiResults.Add(record.S2wiResults);
                    } 
                }
            }
            Sc2WiResults = _sc2WiResults;
            */

            SeriesWi.Add(new StackedAreaSeries<double>
            {
                Values = Sc2GBDataWi,
                Name = "Gas Boiler",
                Stroke = new SolidColorPaint(SKColors.OrangeRed) { StrokeThickness = 4 },
                Fill = new SolidColorPaint(SKColors.Orange),
                GeometryFill = null,
                GeometryStroke = null
                
            });

            SeriesWi.Add(new StackedAreaSeries<double>
            {
                Values = Sc2OBDataWi,
                Name = "Oil Boiler",
                Stroke = new SolidColorPaint(SKColors.Brown) { StrokeThickness = 4 },
                Fill = new SolidColorPaint(SKColors.SandyBrown),
                GeometryFill = null,
                GeometryStroke = null
                
            });
            
            SeriesWi.Add(new StackedAreaSeries<double>
            {
                Values = Sc2EBDataWi,
                Name = "Electric Boiler",
                Stroke = new SolidColorPaint(SKColors.Green) { StrokeThickness = 4 },
                Fill = new SolidColorPaint(SKColors.LightGreen),
                GeometryFill = null,
                GeometryStroke = null
                
            });
            
            SeriesWi.Add(new StackedAreaSeries<double>
            {
                Values = Sc2GMDataWi,
                Name = "Gas Motor",
                Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 },
                Fill = new SolidColorPaint(SKColors.LightBlue),
                GeometryFill = null,
                GeometryStroke = null
                
            });


            SeriesSu.Add(new StackedAreaSeries<double>
            {
                Values = Sc2GBDataSu,
                Name = "Gas Boiler",
                Stroke = new SolidColorPaint(SKColors.OrangeRed) { StrokeThickness = 4 },
                Fill = new SolidColorPaint(SKColors.Orange),
                GeometryFill = null,
                GeometryStroke = null
            });

            SeriesSu.Add(new StackedAreaSeries<double>
            {
                Values = Sc2OBDataSu,
                Name = "Oil Boiler",
                Stroke = new SolidColorPaint(SKColors.Brown) { StrokeThickness = 4 },
                Fill = new SolidColorPaint(SKColors.SandyBrown),
                GeometryFill = null,
                GeometryStroke = null
            });

            SeriesSu.Add(new StackedAreaSeries<double>
            {
                Values = Sc2EBDataSu,
                Name = "Electric Boiler",
                Stroke = new SolidColorPaint(SKColors.Green) { StrokeThickness = 4 },
                Fill = new SolidColorPaint(SKColors.LightGreen),
                GeometryFill = null,
                GeometryStroke = null
                
            });
            
            SeriesSu.Add(new StackedAreaSeries<double>
            {
                Values = Sc2GMDataSu,
                Name = "Gas Motor",
                Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 },
                Fill = new SolidColorPaint(SKColors.LightBlue),
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
            [Name("EB")]
            public double EB  { get; set; }
            [Name("GM")]
            public double GM  { get; set; }
        }
        
        public class S2SuResults
        {
            [Name("Results for the summer:")]
            public string S2suResults { get; set; } = string.Empty;
        }
         public class S2WiResults
        {
            [Name("Results for the winter:")]
             public string S2wiResults { get; set; } = string.Empty;
        }
    }
}