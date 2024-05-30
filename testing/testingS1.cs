using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using FluentAssertions;
//interchangable for scenario 1 and 2
/*
public class ProgramTests
{
    [Fact]
    public void ReadThirdColumnToList_FileNotFound_ShouldReturnEmptyList()
    {    // Arrange
        string filePath = "nonexistentfile.csv";
        //Act
        var result = Program.ReadThirdColumnToList(filePath);
        //Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void ReadThirdColumnToList_ValidFile_ShouldReturnCorrectList()
    {   // Arrange
        string filePath = "testfileS1.csv";
        File.WriteAllText(filePath, "col1;col2;col3\n1;2;3.1\n4;5;6.2");
        //Act
        var result = Program.ReadThirdColumnToList(filePath);
        //Assert
        result.Should().Equal(new List<double> { 3.1, 6.2 });
        //CleanUp
        File.Delete(filePath);
    }

    [Fact]
    public void PerformOperations_ValidData_ShouldWriteResultsToFile()
    {   // Arrange
        string inputFilePath = "testfileS1.csv";
        string resultFilePath = "S1summerResult.csv";
        File.WriteAllText(inputFilePath, "col1;col2;col3\n1;2;3.1\n4;5;6.2");
        var list = Program.ReadThirdColumnToList(inputFilePath);
        //Act
        Program.PerformOperations(list, inputFilePath);
        //Assert
        File.Exists(resultFilePath).Should().BeTrue();
        var resultContent = File.ReadAllText(resultFilePath);
        resultContent.Should().Contain("Total Heat Produced: 273.3 kWh");
        resultContent.Should().Contain("Total Cost: 84000 DKK");
        resultContent.Should().Contain("Total CO2 Emissions: 36120 kg");
        //CleanUp
        File.Delete(inputFilePath);
        File.Delete(resultFilePath);
    }
}
*/