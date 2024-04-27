using UnitDescription;

namespace TheOilBoiler
{
    public class OilBoiler : UnitDescriptions
    {
        public string Name = "OB"; 
        public double MaxHeat = 4.0; 
        public int ProductionCost = 700; 
        public int Emission = 265; 
        public double GasConsumption = 1.2; 

        /*
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
        */
    }
}