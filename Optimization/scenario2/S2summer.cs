using System;
using System.Collections.Generic;
using System.IO;

/*
class Program
{
    static void Main(string[] args)
    {
        string filePath = @"Optimization\scenario2\S2S.csv";
        List<string> column3List = new List<string>();
        List<string> column4List = new List<string>();

        try
        {
            using (var reader = new StreamReader(filePath))
            {
                
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if (values.Length >= 4)  
                    {
                        column3List.Add(values[2]);
                        column4List.Add(values[3]);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid line: {line}");
                    }
                }
            }

            string[] column3Array = column3List.ToArray();
            string[] column4Array = column4List.ToArray();

            double[] column3Doubles = ConvertStringArrayToDoubleArray(column3Array);
            double[] column4Doubles = ConvertStringArrayToDoubleArray(column4Array);

            if (column3Doubles.Length != column4Doubles.Length)
            {
                Console.WriteLine("Columns must have the same length.");
                return;
            }

            PerformOperations(column3Doubles, column4Doubles);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static double[] ConvertStringArrayToDoubleArray(string[] stringArray)
    {
        double[] doubleArray = new double[stringArray.Length];
        for (int i = 0; i < stringArray.Length; i++)
        {
            if (double.TryParse(stringArray[i], out double result))
            {
                doubleArray[i] = result;
            }
            else
            {
                Console.WriteLine($"Conversion failed for '{stringArray[i]}' at index {i}");
                doubleArray[i] = double.NaN;
            }
        }
        return doubleArray;
    }

    static void PerformOperations(double[] array1, double[] array2)
    {
        double gasBoilerCostPerHour = 500.0;
        double gasBoilerCO2PerHour = 215.0;
        double oilBoilerCostPerHour = 700.0;
        double oilBoilerCO2PerHour = 265.0;
        double electricBoilerCostPerHour = 50.0;

        double gasBoilerUsage;
        double oilBoilerUsage;
        double gasMotorUsage;
        double electricBoilerUsage;

        double totalHeat = 0.00;
        double totalCost = 0.00;
        double totalCO2 = 0.00;

        List<double> GasBoilerUsage = new List<double>();
        List<double> OilBoilerUsage = new List<double>();
        List<double> GasMotorUsage = new List<double>();
        List<double> ElectricBoilerUsage = new List<double>();
        string filePath = @"Optimization\scenario2\S2S.csv";

        if (array1.Length != array2.Length)
        {
            throw new ArgumentException("Arrays must have the same length.");
        }

        for (int i = 0; i < array1.Length; i++)
        {
            double heatDemand = array1[i];
            double electricityPrice = array2[i];
            totalHeat += heatDemand;

            if ((heatDemand > 5 && heatDemand < 8 && electricityPrice <= 1150) || (heatDemand < 5 && electricityPrice <= 500)) ///700
            {
                totalCost += electricBoilerCostPerHour + electricityPrice;
                totalCO2 += 0.00;
                gasBoilerUsage = 0.00;
                oilBoilerUsage = 0.00;
                electricBoilerUsage = heatDemand;
                gasMotorUsage = 0.00;
            }
            else if (heatDemand > 8 && electricityPrice <= 650)//700
            {
                totalCost += electricBoilerCostPerHour + electricityPrice + gasBoilerCostPerHour;
                totalCO2 += gasBoilerCO2PerHour;
                electricBoilerUsage = 8.00;
                gasBoilerUsage = heatDemand - electricBoilerUsage;
                oilBoilerUsage = 0.00;
                gasMotorUsage = 0.00;
            }
            else if (heatDemand > 5 && electricityPrice > 650)
            {
                totalCost += gasBoilerCostPerHour + oilBoilerCostPerHour;
                totalCO2 += gasBoilerCO2PerHour + oilBoilerCO2PerHour;
                gasBoilerUsage = 5.00;
                oilBoilerUsage = heatDemand - gasBoilerUsage;
                electricBoilerUsage = 0.00;
                gasMotorUsage = 0.00;
            }
            else
            {
                totalCost += gasBoilerCostPerHour;
                totalCO2 += gasBoilerCO2PerHour;
                gasBoilerUsage = heatDemand;
                oilBoilerUsage = 0.00;
                electricBoilerUsage = 0.00;
                gasMotorUsage = 0.00;
            }

            GasBoilerUsage.Add(gasBoilerUsage);
            OilBoilerUsage.Add(oilBoilerUsage);
            ElectricBoilerUsage.Add(electricBoilerUsage);
            GasMotorUsage.Add(gasMotorUsage);
        }

        var lines = new List<string>(File.ReadAllLines(filePath));
        for (int i = 0; i < lines.Count; i++)
        {
            string gasBoilerUsageColumn = i < GasBoilerUsage.Count ? GasBoilerUsage[i].ToString() : string.Empty;
            string oilBoilerUsageColumn = i < OilBoilerUsage.Count ? OilBoilerUsage[i].ToString() : string.Empty;
            string electricBoilerUsageColumn = i < ElectricBoilerUsage.Count ? ElectricBoilerUsage[i].ToString() : string.Empty;
            string gasMotorUsageColumn = i < GasMotorUsage.Count ? GasMotorUsage[i].ToString() : string.Empty;

            lines[i] += ";" + gasBoilerUsageColumn + ";" + oilBoilerUsageColumn + ";" + electricBoilerUsageColumn + ";" + gasMotorUsageColumn + ";";
        }

        File.WriteAllLines(filePath, lines);

        string filePathResults = @"Optimization\scenario2\S2summerResults.csv";
        using (StreamWriter writer = new StreamWriter(filePathResults))
        {
            writer.WriteLine("Results for the summer:");
            writer.WriteLine($"Total Heat Produced: {totalHeat} kWh");
            writer.WriteLine($"Total Cost: {totalCost} DKK");
            writer.WriteLine($"Total CO2 Emissions: {totalCO2} kg");
        }

        Console.WriteLine("CSV file has been written successfully.");
    }
}
*/