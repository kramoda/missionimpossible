using System;
using System.Globalization;
using System.IO;

class BoilerConsumptionCalculator
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to the CSV file as an argument.");
            return;
        }

        string csvFilePath = args[0];
        if (!File.Exists(csvFilePath))
        {
            Console.WriteLine("The CSV file does not exist.");
            return;
        }

        double gasBoilerCostPerHour = 500.0;
        double gasBoilerCO2PerHour = 215.0;
        double oilBoilerCostPerHour = 700.0;
        double oilBoilerCO2PerHour = 265.0;
        double electricBoilerCostPerHour = 50.0;

        double totalWinterHeat = 0.0;
        double totalSummerHeat = 0.0;
        double totalWinterCost = 0.0;
        double totalSummerCost = 0.0;
        double totalWinterCO2 = 0.0;
        double totalSummerCO2 = 0.0;

        using (var reader = new StreamReader(csvFilePath))
        {
            bool isFirstLine = true;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue; // Skip the header line.
                }

                var values = line.Split(',');
                if (values.Length < 9)
                {
                    Console.WriteLine("The CSV file format is incorrect.");
                    return;
                }

                if (double.TryParse(values[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double winterDemand) &&
                    double.TryParse(values[6], NumberStyles.Any, CultureInfo.InvariantCulture, out double summerDemand) &&
                    double.TryParse(values[3], NumberStyles.Any, CultureInfo.InvariantCulture, out double winterElectricityPrice) &&
                    double.TryParse(values[7], NumberStyles.Any, CultureInfo.InvariantCulture, out double summerElectricityPrice))
                {
                    // Calculations for winter
                    totalWinterHeat += winterDemand;
                    if (winterElectricityPrice < 600)
                    {
                        totalWinterCost += electricBoilerCostPerHour;
                    }
                    else if (winterDemand > 5)
                    {
                        totalWinterCost += gasBoilerCostPerHour + oilBoilerCostPerHour;
                        totalWinterCO2 += gasBoilerCO2PerHour + oilBoilerCO2PerHour;
                    }
                    else
                    {
                        totalWinterCost += gasBoilerCostPerHour;
                        totalWinterCO2 += gasBoilerCO2PerHour;
                    }

                    // Calculations for summer
                    totalSummerHeat += summerDemand;
                    if (summerElectricityPrice < 600)
                    {
                        totalSummerCost += electricBoilerCostPerHour;
                    }
                    else if (summerDemand > 5)
                    {
                        totalSummerCost += gasBoilerCostPerHour + oilBoilerCostPerHour;
                        totalSummerCO2 += gasBoilerCO2PerHour + oilBoilerCO2PerHour;
                    }
                    else
                    {
                        totalSummerCost += gasBoilerCostPerHour;
                        totalSummerCO2 += gasBoilerCO2PerHour;
                    }
                }
                else
                {
                    Console.WriteLine("Error reading values from the CSV.");
                    return;
                }
            }
        }

        Console.WriteLine("Results for winter:");
        Console.WriteLine($"Total Heat Produced: {totalWinterHeat} kWh");
        Console.WriteLine($"Total Cost: {totalWinterCost} DKK");
        Console.WriteLine($"Total CO2 Emissions: {totalWinterCO2} kg");

        Console.WriteLine("Results for summer:");
        Console.WriteLine($"Total Heat Produced: {totalSummerHeat} kWh");
        Console.WriteLine($"Total Cost: {totalSummerCost} DKK");
        Console.WriteLine($"Total CO2 Emissions: {totalSummerCO2} kg");
    }
}
