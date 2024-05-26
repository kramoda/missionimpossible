using System;
using System.Globalization;
using System.IO;

class BoilerConsumptionCalculator
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Por favor, proporciona la ruta del archivo CSV como argumento.");
            return;
        }

        string csvFilePath = args[0];
        if (!File.Exists(csvFilePath))
        {
            Console.WriteLine("El archivo CSV no existe.");
            return;
        }

        double gasBoilerCostPerHour = 500.0;
        double gasBoilerCO2PerHour = 215.0;
        double oilBoilerCostPerHour = 700.0;
        double oilBoilerCO2PerHour = 265.0;

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
                if (values.Length < 7)
                {
                    Console.WriteLine("El formato del archivo CSV no es correcto.");
                    return;
                }

                if (double.TryParse(values[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double winterDemand) &&
                    double.TryParse(values[6], NumberStyles.Any, CultureInfo.InvariantCulture, out double summerDemand))
                {
                    // Cálculos para invierno
                    totalWinterHeat += winterDemand;
                    totalWinterCost += gasBoilerCostPerHour + oilBoilerCostPerHour;
                    totalWinterCO2 += gasBoilerCO2PerHour + oilBoilerCO2PerHour;

                    // Cálculos para verano
                    totalSummerHeat += summerDemand;
                    totalSummerCost += gasBoilerCostPerHour + oilBoilerCostPerHour;
                    totalSummerCO2 += gasBoilerCO2PerHour + oilBoilerCO2PerHour;
                }
                else
                {
                    Console.WriteLine("Error al leer los valores de demanda.");
                    return;
                }
            }
        }

        Console.WriteLine("Resultados para invierno:");
        Console.WriteLine($"Total Heat Produced: {totalWinterHeat} kWh");
        Console.WriteLine($"Total Cost: {totalWinterCost} DKK");
        Console.WriteLine($"Total CO2 Emissions: {totalWinterCO2} kg");

        Console.WriteLine("Resultados para verano:");
        Console.WriteLine($"Total Heat Produced: {totalSummerHeat} kWh");
        Console.WriteLine($"Total Cost: {totalSummerCost} DKK");
        Console.WriteLine($"Total CO2 Emissions: {totalSummerCO2} kg");
    }
}
