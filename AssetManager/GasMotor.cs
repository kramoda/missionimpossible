using GasConsumptions;

namespace TheGasMotor
{
    public class GasMotor : GasConsumption
    {
        public double GasConsumption = 1.9; 
        
        public override void DisplayGasConsumption()
        {
            Console.WriteLine($"Gas consumption: {GasConsumption} MWh(gas) / MWh(th)");
        }
    }
}