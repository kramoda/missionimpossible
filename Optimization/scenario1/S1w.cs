using System;
using System.IO;
using System.Collections.Generic;

/*
public class Program
{
    static void Main(string[] args)
    {
        string filePath = @"Optimization\scenario1\S1W.csv";
        List<double> thirdColumnList = ReadThirdColumnToList(filePath);
        PerformOperations(thirdColumnList, filePath);
    }

    public static List<double> ReadThirdColumnToList(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return new List<double>();
        }

        List<double> thirdColumnList = new List<double>();

        using (StreamReader sr = new StreamReader(filePath))
        {   
            //sr.ReadLine();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] columns = line.Split(';');

                if (columns.Length >= 3)
                {
                    if (double.TryParse(columns[2], out double result))
                    {
                        thirdColumnList.Add(result);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to parse '{columns[2]}' as a double.");
                    }
                }
            }
        }

        return thirdColumnList;
    }

    public static void PerformOperations(List<double> list, string filePath)
    {
        double gasBoilerCostPerHour = 500.0;
        double gasBoilerCO2PerHour = 215.0;
        double oilBoilerCostPerHour = 700.0;
        double oilBoilerCO2PerHour = 265.0;

        double gasBoilerUsage;
        double oilBoilerUsage;

        double totalHeat = 0.00;
        double totalCost = 0.00;
        double totalCO2 = 0.00;

        List<double> GasBoilerUsage = new List<double>();
        List<double> OilBoilerUsage = new List<double>();

        for (int i = 0; i < list.Count; i++)
        {
            double value = list[i];
            totalHeat += value;
            if (value > 5)
            {
                totalCost += gasBoilerCostPerHour + oilBoilerCostPerHour;
                totalCO2 += gasBoilerCO2PerHour + oilBoilerCO2PerHour;
                gasBoilerUsage = 5.00;
                oilBoilerUsage = value - gasBoilerUsage;
                GasBoilerUsage.Add(gasBoilerUsage);
                OilBoilerUsage.Add(oilBoilerUsage);
            }
            else
            {
                totalCost += gasBoilerCostPerHour;
                totalCO2 += gasBoilerCO2PerHour;
                gasBoilerUsage = value;
                oilBoilerUsage = 0.00;
                GasBoilerUsage.Add(gasBoilerUsage);
                OilBoilerUsage.Add(oilBoilerUsage);
            }
        }

        var lines = new List<string>(File.ReadAllLines(filePath));

        for (int i = 0; i < lines.Count; i++)
        {
            string gasBoilerUsageColumn = i < GasBoilerUsage.Count ? GasBoilerUsage[i].ToString() : string.Empty;
            string oilBoilerUsageColumn = i < OilBoilerUsage.Count ? OilBoilerUsage[i].ToString() : string.Empty;

            lines[i] += ";" + gasBoilerUsageColumn + ";" + oilBoilerUsageColumn + ";";
        }
        
        
        File.WriteAllLines(filePath, lines);

        string filePathResults = @"Optimization\scenario1\S1winterResults.csv";
        using (StreamWriter writer = new StreamWriter(filePathResults))
        {
            writer.WriteLine("Results for the winter:");
            writer.WriteLine($"Total Heat Produced: {totalHeat} kWh");
            writer.WriteLine($"Total Cost: {totalCost} DKK");
            writer.WriteLine($"Total CO2 Emissions: {totalCO2} kg");
        }

        Console.WriteLine("CSV file has been written successfully.");
 
    }   
       
}
*/