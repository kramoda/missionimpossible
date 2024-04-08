using System;

public class HeatingUnitDescription
{
    public string NameOfUnit { get; set; }
    public string Description { get; set; }

    public HeatingUnitDescription(string name, string description)
    {
        NameOfUnit = name;
        Description = description;
    }

    public void DisplayDescription()
    {
        Console.WriteLine($"Name: {NameOfUnit}");
        Console.WriteLine($"Description: {Description}");
    }
}

public class GasBoiler : HeatingUnitDescription
{
    public GasBoiler() : base("GB", "Max heat: 5.0 MW\nGas consumption: 1.1 MWh(gas) / MWh(th)")
    {
    }
}

public class OilBoiler : HeatingUnitDescription
{
    public OilBoiler() : base("OB", "Max heat: 4.0 MW\nGas consumption: 1.2 MWh(oil) / MWh(th)")
    {
    }
}

public class GasMotor : HeatingUnitDescription
{
    public GasMotor() : base("GM", "Max heat: 3.6 MW\nGas consumption: 1.9 MWh(gas) / MWh(th)")
    {
    }
}

public class ElectricBoiler : HeatingUnitDescription
{
    public ElectricBoiler() : base("EK", "Max heat: 8.0 MW")
    {
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        GasBoiler gb = new GasBoiler();
        OilBoiler ob = new OilBoiler();
        GasMotor gm = new GasMotor();
        ElectricBoiler ek = new ElectricBoiler();

        gb.DisplayDescription();
        Console.WriteLine();
        ob.DisplayDescription();
        Console.WriteLine();
        gm.DisplayDescription();
        Console.WriteLine();
        ek.DisplayDescription();
    }
}
