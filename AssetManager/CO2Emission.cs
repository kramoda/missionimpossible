using System;

public class HeatingUnit
{
    public double CO2Emissions { get; protected set; }
}
public class GasBoiler : HeatingUnitDescribtion 
{
    public GasBoiler()
    {
        CO2Emissions = 215; // kg / MWh(th)
    }
}


public class OilBoiler : HeatingUnitDescribtion
{
    public OilBoiler()
    {
        CO2Emissions = 265; // kg / MWh(th)
    }
}

public class GasMotor : HeatingUnitDescribtion
{
    public GasMotor()
    {
        CO2Emissions = 640; // kg / MWh(th)
    }
}

public class CO2Emissions
{
    public double ViewCO2()
    {
        GasBoiler gb = new GasBoiler();
        OilBoiler ob = new OilBoiler();
        GasMotor gm = new GasMotor();

        double totalCO2 = gb.CO2Emissions + ob.CO2Emissions + gm.CO2Emissions;
        return totalCO2;
    }
}