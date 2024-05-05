using System.Data;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using System;

namespace CSVConnection
{
    public class CSVConnect
    {
        //string filepath = @"SemesterProject2/CSV\2024HeatProductionOptimizationSummer.csv";
        //string filepath2 = @"SemesterProject2/CSV\2024HeatProductionOptimizationWinter.csv";

        /*
        public DataTable CSVDatatable(string filePath)
        {
            string[] rows = File.ReadAllLines(filePath);
            DataTable dTableData = new DataTable();
            string[] rowValues = null;
            DataRow dataRow = dTableData.NewRow();

            if (rows.Length > 0)
            {
                foreach (string columnName in rows[0].Split(','))
                    dTableData.Columns.Add(columnName);
            }

            for (int row = 2; row < rows.Length; row++)
            {
                rowValues = rows[row].Split(',');
                dataRow = dTableData.NewRow();
                dataRow.ItemArray = rowValues;
                dTableData.Rows.Add(dataRow);
            }

            return dTableData;
        }
        */
            
            
    }
}