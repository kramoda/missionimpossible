namespace GasConsumptions
{
    public abstract class GasConsumption
    {
        public double ConsumptionAmount {get; set;}
        public abstract void DisplayGasConsumption();
    }
}