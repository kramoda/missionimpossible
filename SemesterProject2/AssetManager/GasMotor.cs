using UnitDescription;

namespace TheGasMotor
{
    public class GasMotor : UnitDescriptions
    {
        public string Name = "GM"; 
        public double MaxHeat = 3.6; 
        public int ProductionCost = 1100; 
        public int Emission = 640; 
        public double GasConsumption = 1.9; 
        public double MaximumElectricity = 2.7;
        

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

        public override void DisplayMaximumElectricity()
        {
            Console.WriteLine($"Maximum Electricity: {MaximumElectricity} MW");
        }
        */

    }
}