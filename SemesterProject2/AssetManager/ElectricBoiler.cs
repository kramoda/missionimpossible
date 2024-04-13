using UnitDescription;


namespace TheElectricBoiler
{
     public class ElectricBoiler : UnitDescriptions
    {
        public string Name = "EK"; 
        public double MaxHeat = 8.0; 
        public int ProductionCost = 50;  
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

         public override void DisplayMaximumElectricity()
        {
            Console.WriteLine($"Maximum electricity: {MaximumElectricity} MW");
        }
        */
    }
}