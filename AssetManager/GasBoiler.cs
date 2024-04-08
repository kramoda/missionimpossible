using UnitDescription;

namespace TheGasBoiler
{
    public class GasBoiler : UnitDescription
    {
        public string Name = "GB"; 
        public double MaxHeat = 5.0; 
        public int ProductionCost = 500; 
        public int Emission = 215; 
        public double GasConsumption = 1.1; 

       
        
        public override void DisplayName()
        {
            Console.WriteLine($"Unit Name: {Name}");
        }

         public override void DisplayMaxHeat()
        {
            Console.WriteLine($"Maximum heat: {MaxHeat} MW");
        }

         public override void DisplayProductionCost()
        {
            Console.WriteLine($"Production Cost: {ProductionCost} DKK / MWh(th)");
        }

         public override void DisplayEmission()
        {
            Console.WriteLine($"CO2 Emission: {Emission} kg / MWh(th)");
        }

         public override void DisplayGasConsumption()
        {
            Console.WriteLine($"Gas consumption: {GasConsumption} MWh / MWh(th)");
        }
    }
}