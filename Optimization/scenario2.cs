using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

class Program
{
    static void Main(string[] args)
    {
        string csvFileName = "optimizationinfo.csv";
        string csvFilePath = Path.Combine(Enviroment.CurrentDirectory, csvFileName);
        var optimizationInfos = ReadOptimizationInfoFromCsv(csvFilePath);

        Console.WriteLine("Winter Period:");
        DisplayResults(optimizationInfos, "winter");

        Console.WriteLine("\nSummer Period:");
        DisplayResults(optimizationInfos, "summer");
    }

    static List<OptimizationInfo> ReadOptimizationInfoFromCsv(string csvFilePath)
    {
        var optimizationInfos = new List<OptimizationInfo>();

        using (var reader = new StreamReader(csvFilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            while (csv.Read())
            {
                var optimizationInfo = new OptimizationInfo
                {
                    HeatDemand = csv.GetField<double>("heat_demand"),
                    Period = csv.GetField<string>("period"),
                    ElectricityPrice = csv.GetField<double>("electricity_price")
                };
                optimizationInfos.Add(optimizationInfo);
            }
        }

        return optimizationInfos;
    }

    static void DisplayResults(List<OptimizationInfo> optimizationInfos, string period)
    {
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine("| Heat Demand (MWh) | Production Cost (DKK) | CO2 Emissions (tons) |");
        Console.WriteLine("--------------------------------------------------------------------");

        foreach (var optimizationInfo in optimizationInfos)
        {
            if (optimizationInfo.Period == period)
            {
                var result = CalculateProductionCostAndEmissions(optimizationInfo);
                Console.WriteLine($"| {optimizationInfo.HeatDemand,-18} | {result.ProductionCost,-22} | {result.Co2Emissions,-20} |");
            }
        }

        Console.WriteLine("--------------------------------------------------------------------");
    }

    static (double ProductionCost, double Co2Emissions) CalculateProductionCostAndEmissions(OptimizationInfo optimizationInfo)
    {
        const double gasBoilerCost = 500; // DKK per hour
        const double oilBoilerCost = 700; // DKK per hour
        const double electricBoilerCost = 50; // DKK per hour
        const double gasBoilerCo2Emission = 0.2; // tons per MWh
        const double oilBoilerCo2Emission = 0.3; // tons per MWh
        const double electricBoilerCo2Emission = 0.1; // tons per MWh

        double totalCost = 0;
        double totalCo2Emissions = 0;

        if (optimizationInfo.Period == "summer")
        {
            if (optimizationInfo.ElectricityPrice < 600)
            {
                totalCost = optimizationInfo.HeatDemand * electricBoilerCost;
                totalCo2Emissions = optimizationInfo.HeatDemand * electricBoilerCo2Emission;
            }
            else if (optimizationInfo.HeatDemand <= 5)
            {
                totalCost = optimizationInfo.HeatDemand * gasBoilerCost;
                totalCo2Emissions = optimizationInfo.HeatDemand * gasBoilerCo2Emission;
            }
            else
            {
                double gasBoilerHeat = 5;
                double oilBoilerHeat = Math.Min(optimizationInfo.HeatDemand - gasBoilerHeat, optimizationInfo.HeatDemand - 5);

                totalCost = (gasBoilerHeat * gasBoilerCost) + (oilBoilerHeat * oilBoilerCost);
                totalCo2Emissions = (gasBoilerHeat * gasBoilerCo2Emission) + (oilBoilerHeat * oilBoilerCo2Emission);
            }
        }
        else // Winter period
        {
            if (optimizationInfo.HeatDemand <= 5)
            {
                totalCost = optimizationInfo.HeatDemand * gasBoilerCost;
                totalCo2Emissions = optimizationInfo.HeatDemand * gasBoilerCo2Emission;
            }
            else
            {
                double gasBoilerHeat = 5;
                double oilBoilerHeat = optimizationInfo.HeatDemand - gasBoilerHeat;

                totalCost = (gasBoilerHeat * gasBoilerCost) + (oilBoilerHeat * oilBoilerCost);
                totalCo2Emissions = (gasBoilerHeat * gasBoilerCo2Emission) + (oilBoilerHeat * oilBoilerCo2Emission);
            }
        }

        return (totalCost, totalCo2Emissions);
    }
}

public class OptimizationInfo
{
    public double HeatDemand { get; set; }
    public string Period { get; set; }
    public double ElectricityPrice { get; set; }
}
