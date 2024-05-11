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
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using Microsoft.VisualBasic;

namespace SemesterProject2.ViewModels
{
    public class HeatDemandViewModel : ViewModelBase
    {
        public class HDemandDataWinter()
        {
            public double HDemandWi {get; set;}
            public string? TimeWi {get; set;}


        }

        public class HDemandDataSummer
        {
            public double HDemandSu {get; set;}
            public string? TimeSu {get; set;}
        }

        private List<double> _hDemandWi;
        public List<double> HDemandWi
        {
            get => _hDemandWi;
            set => this.RaiseAndSetIfChanged(ref _hDemandWi, value);
        }

        private List<string> _timeFromWi;
        public List<string> TimeFromWi
        {
            get => _timeFromWi;
            set => this.RaiseAndSetIfChanged(ref _timeFromWi, value);
        }

        private List<double> _hDemandSu;
        public List<double> HDemandSu
        {
            get => _hDemandSu;
            set => this.RaiseAndSetIfChanged(ref _hDemandSu, value);
        }

        private List<string> _timeFromSu;
        public List<string> TimeFromSu
        {
            get => _timeFromSu;
            set => this.RaiseAndSetIfChanged(ref _timeFromSu, value);
        }

        public LabelVisual HeatDemandWi { get; set; } =
        new LabelVisual
        {
            Text = "Winter",
            TextSize = 18,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };

        public LabelVisual HeatDemandSu { get; set; } =
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

        public HeatDemandViewModel()
        {
            _hDemandWi = new List<double>();
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
                        _hDemandWi.Add(record.HeatDemand);
                        _timeFromWi.Add(record.TimeFrom);
                    }
                }
            }
            HDemandWi = _hDemandWi;
            TimeFromWi = _timeFromWi;

            _hDemandSu = new List<double>();
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
                        _hDemandSu.Add(record.HeatDemand);
                        _timeFromSu.Add(record.TimeFrom);
                    } 
                }
            }
            HDemandSu = _hDemandSu;
            TimeFromSu = _timeFromSu;

            SeriesWi.Add(new LineSeries<double>
            {
                Values = HDemandWi,
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
                
            });

            SeriesSu.Add(new LineSeries<double>
            {
                Values = HDemandSu,
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
