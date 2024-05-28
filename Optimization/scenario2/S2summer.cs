using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
/*
class Program
{
    static void Main(string[] args)
    {
        string filePath = @"S2S.csv";
        List<string> column3List = new List<string>();
        List<string> column4List = new List<string>();
        
         using (var reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                column3List.Add(values[2]);
                column4List.Add(values[3]);
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
                    // Handle the error (e.g., assign a default value or throw an exception)
                    doubleArray[i] = double.NaN; // Assigning NaN as a placeholder for invalid values
                }
            }
            return doubleArray;
        }

        PerformOperations(column3Doubles, column4Doubles);
            

           static void PerformOperations(double[] array1, double[] array2)
        {       double gasBoilerCostPerHour = 500.0;
                double gasBoilerCO2PerHour = 215.0;
                double oilBoilerCostPerHour = 700.0;
                double oilBoilerCO2PerHour = 265.0;
                double electricBoilerCostPerHour = 50.0;
                
                double gasBoilerUsage;
                double oilBoilerUsage;
                double gasMotorUsage;
                double electricBoilerUsage;

                double totalSummerHeat = 0.00;
                double totalSummerCost = 0.00;
                double totalSummerCO2 = 0.00;

            List<double> GasBoilerUsage = new List<double>();
            List<double> OilBoilerUsage = new List<double>();
            List<double> GasMotorUsage = new List<double>();
            List<double> ElectricBoilerUsage = new List<double>();
            string filePath = @"S2S.csv";
            
            
            
            if (array1.Length != array2.Length)
            {
                throw new ArgumentException("Arrays must have the same length.");
            }
            
            for (int i = 0; i < array1.Length; i++)
            {
                double heatDemand = array1[i];
                double electricityPrice = array2[i];
                totalSummerHeat += heatDemand;
                
                if ((heatDemand > 5 && heatDemand < 8 && electricityPrice <=700) || (heatDemand < 5 && electricityPrice <= 500))
                {
                    totalSummerCost += electricBoilerCostPerHour + electricityPrice;
                    totalSummerCO2 += 0.00;
                    gasBoilerUsage = 0.00;
                    oilBoilerUsage = 0.00;
                    electricBoilerUsage = heatDemand;
                    gasMotorUsage = 0.00;
                    GasBoilerUsage.Add(gasBoilerUsage);
                    OilBoilerUsage.Add(oilBoilerUsage);
                    ElectricBoilerUsage.Add(electricBoilerUsage);
                    GasMotorUsage.Add(gasMotorUsage);
                }
                else if (heatDemand > 8 && electricityPrice <= 700)
                {
                    totalSummerCost += electricBoilerCostPerHour + electricityPrice + gasBoilerCostPerHour;
                    totalSummerCO2 += gasBoilerCO2PerHour;
                    electricBoilerUsage = 8.00;
                    gasBoilerUsage = heatDemand - electricBoilerUsage;
                    oilBoilerUsage = 0.00;
                    gasMotorUsage = 0.00;
                    GasBoilerUsage.Add(gasBoilerUsage);
                    OilBoilerUsage.Add(oilBoilerUsage);
                    ElectricBoilerUsage.Add(electricBoilerUsage);
                    GasMotorUsage.Add(gasMotorUsage);
                }
                else if (heatDemand > 5 && heatDemand < 8 && electricityPrice >700)
                {   
                    totalSummerCost = gasBoilerCostPerHour + oilBoilerCostPerHour;
                    totalSummerCO2 = gasBoilerCO2PerHour + oilBoilerCO2PerHour;
                    gasBoilerUsage = 5.00;
                    oilBoilerUsage = heatDemand - gasBoilerUsage;
                    electricBoilerUsage = 0.00;
                    gasMotorUsage = 0.00;
                     GasBoilerUsage.Add(gasBoilerUsage);
                    OilBoilerUsage.Add(oilBoilerUsage);
                    ElectricBoilerUsage.Add(electricBoilerUsage);
                    GasMotorUsage.Add(gasMotorUsage);
                }
                else 
                {
                    totalSummerCost += gasBoilerCostPerHour;
                    totalSummerCO2 += gasBoilerCO2PerHour;
                    gasBoilerUsage = heatDemand;
                    oilBoilerUsage = 0.00;
                    electricBoilerUsage = 0.00;
                    gasMotorUsage = 0.00;
                    GasBoilerUsage.Add(gasBoilerUsage);
                    OilBoilerUsage.Add(oilBoilerUsage);
                    ElectricBoilerUsage.Add(electricBoilerUsage);
                    GasMotorUsage.Add(gasMotorUsage);
                }    
               
            }
            var lines = new List<string>(File.ReadAllLines(filePath));    
                
                
            
                
                for (int i = 1; i < lines.Count; i++)
                {
                    string gasBoilerUsageColumn = i < GasBoilerUsage.Count ? GasBoilerUsage[i].ToString() : string.Empty;
                    string oilBoilerUsageColumn = i < OilBoilerUsage.Count ? OilBoilerUsage[i].ToString() : string.Empty;
                    string electricBoilerUsageColumn = i < ElectricBoilerUsage.Count ? ElectricBoilerUsage[i].ToString() : string.Empty;
                    string gasMotorUsageColumn = i < GasMotorUsage.Count ? GasMotorUsage[i].ToString() : string.Empty;

                    lines[i] += ";" + gasBoilerUsageColumn + ";" + oilBoilerUsageColumn + ";"+ electricBoilerUsageColumn + ";"+ gasMotorUsageColumn + ";";
                }

                File.WriteAllLines(filePath, lines);
                
                    
                    
                string filePathResults = @"S2summerResults.csv";
                using (StreamWriter writer = new StreamWriter(filePathResults))
                {
                    writer.WriteLine("Results for the summer:");
                    writer.WriteLine($"Total Heat Produced: {totalSummerHeat} kWh");
                    writer.WriteLine($"Total Cost: {totalSummerCost} DKK");
                    writer.WriteLine($"Total CO2 Emissions: {totalSummerCO2} kg");
                }

                Console.WriteLine("CSV file has been written successfully.");
            }
        
    }
}

*/