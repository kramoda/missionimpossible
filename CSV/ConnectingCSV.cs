using System;
using System.IO;

class ConnectingCSV
{
    static void Main()
    {
        // Specify the path to your CSV file
        string filePath = @"CSV\connecting(Sheet1).csv";

        // Read the CSV file
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                // Split the line into fields
                string[] fields = line.Split(',');

                // Process each field as needed
                foreach (string field in fields)
                {
                    Console.Write(field + "\t"); // Display field
                }
                Console.WriteLine(); // Move to the next line
            }
        }
    }
}