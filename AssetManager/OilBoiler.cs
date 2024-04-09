using GasConsumptions;

namespace TheOilBoiler
{
    public class OilBoiler : GasConsumption
    {
        public double GasConsumption = 1.2;
        
        public override void DisplayGasConsumption()
        {
            Console.WriteLine($"Gas consumption: {GasConsumption} MWh(oil) / MWh(th)");
        }
    }
}