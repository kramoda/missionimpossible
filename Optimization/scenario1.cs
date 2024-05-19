using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

class Program
{
    static void Main(string[] args)
    {
        string csvFileName = "optimizationinfo.csv";
        string csvFilePath = Path.Combine(Environment.CurrentDirectory, csvFileName);
        var demands = ReadHeatDemandFromCsv(csvFilePath);

        var winterDemands = new List<HeatDemandRecord>();
        var summerDemands = new List<HeatDemandRecord>();

        foreach (var demand in demands)
        {
            if (demand.Period == "winter")
                winterDemands.Add(demand);
            else if (demand.Period == "summer")
                summerDemands.Add(demand);
        }

        Console.WriteLine("Winter Period:");
        Console.WriteLine("Heat Demand (MWh)\tProduction Cost (DKK)\tCO2 Emissions (tons)");
        foreach (var demand in winterDemands)
        {
            var result = CalculateProductionCostAndEmissions(demand.HeatDemand);
            Console.WriteLine($"{result.HeatDemand}\t\t{result.ProductionCost}\t\t\t{result.Co2Emissions}");
        }

        Console.WriteLine("\nSummer Period:");
        Console.WriteLine("Heat Demand (MWh)\tProduction Cost (DKK)\tCO2 Emissions (tons)");
        foreach (var demand in summerDemands)
        {
            var result = CalculateProductionCostAndEmissions(demand.HeatDemand);
            Console.WriteLine($"{result.HeatDemand}\t\t{result.ProductionCost}\t\t\t{result.Co2Emissions}");
        }
    }

    static List<HeatDemandRecord> ReadHeatDemandFromCsv(string csvFilePath)
    {
        var demands = new List<HeatDemandRecord>();

        using (var reader = new StreamReader(csvFilePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower()
        }))
        {
            while (csv.Read())
            {
                var record = new HeatDemandRecord
                {
                    HeatDemand = csv.GetField<double>("heat_demand"),
                    Period = csv.GetField<string>("period")
                };
                demands.Add(record);
            }
        }

        return demands;
    }

    static (double HeatDemand, double ProductionCost, double Co2Emissions) CalculateProductionCostAndEmissions(double heatDemand)
    {
        const double gasBoilerCost = 500; // DKK per hour
        const double oilBoilerCost = 700; // DKK per hour
        const double gasBoilerCapacity = 5; // MWh
        const double gasBoilerCo2Emission = 0.2; // tons per MWh
        const double oilBoilerCo2Emission = 0.3; // tons per MWh

        double totalCost = 0;
        double totalCo2Emissions = 0;

        if (heatDemand <= gasBoilerCapacity)
        {
            totalCost = heatDemand * gasBoilerCost;
            totalCo2Emissions = heatDemand * gasBoilerCo2Emission;
        }
        else
        {
            double gasBoilerHeat = gasBoilerCapacity;
            double oilBoilerHeat = heatDemand - gasBoilerCapacity;

            totalCost = (gasBoilerHeat * gasBoilerCost) + (oilBoilerHeat * oilBoilerCost);
            totalCo2Emissions = (gasBoilerHeat * gasBoilerCo2Emission) + (oilBoilerHeat * oilBoilerCo2Emission);
        }

        return (heatDemand, totalCost, totalCo2Emissions);
    }
}

public class HeatDemandRecord
{
    public double HeatDemand { get; set; }
    public string Period { get; set; }
}