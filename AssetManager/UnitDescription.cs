namespace UnitDescription
{
    public abstract class UnitDescription
    {
        public string NameOfUnit {get; set;} // name of each unit
        public abstract void DisplayName();

        public double HeatMaximum {get; set;} // maximum heat for each unit
        public abstract void DisplayMaxHeat();
        
        public int CostOfProduction {get; set;} // production cost for each unit
        public abstract void DisplayProductionCost();

        public int CO2Emission {get; set;} // CO2 emissions for each unit
        public abstract void DisplayEmission(); 
        
        public double ConsumptionAmount {get; set;} // gas consumption for each unit
        public abstract void DisplayGasConsumption(); 

        public double ElectricityMaximum {get; set;} // maximum electricity for each unit
        public abstract void DisplayMaxElectricity();

    }
}