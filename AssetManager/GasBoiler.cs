using GasConsumptions;

namespace TheGasBoiler
{
    public class GasBoiler : GasConsumption
    {
        public double GasConsumption = 1.1; 
        
        public override void DisplayGasConsumption()
        {
            Console.WriteLine($"Gas consumption: {GasConsumption} MWh(gas) / MWh(th)");
        }
    }
}