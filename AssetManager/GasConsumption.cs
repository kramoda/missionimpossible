namespace GasConsumption
{
    public abstract class GasConsumption
    {
        public double ConsumptionAmount { get; set;}
        public abstract void DisplayGasConsumption();
    }
    public class GasBoiler : GasConsumption
    {
        public double BoilerConsumption { get; set;}
        
        public GasBoiler(double BoilerConsumption)
        {
            BoilerConusmption = boilerConsumption;
            ConsumptionAmount = BoilerConsumption;
        }
        public override void DisplayGasConsumption()
        {
            Console.Writeline("Gas Boiler Consumption: " + ConsumptionAmount);
        }
    }
    public class GasMotor : GasConsumption
    {
        public double MotorConsumption { get; set;}
        public GasMotor(double MotorConsumption)
        {
            MotorConsumption = motorConsumption;
            ConsumptionAmount = motorConsumption;
        }
        public override void DisplayGasConsumption()
        {
            Console.Writeline("Gas Motor Consumption: " + ConsumptionAmount);
        }
    }
    public class TotalGasConsumption : GasConsumption
    {
        private GasBoiler gasBoiler;
        private GasMotor gasMotor;
        public TotalGasConsumption(GasBoiler gasBoiler, GasMotor gasMotor)
        {
            this.gasBoiler = gasBoiler;
            this.gasMotor = gasMotor;
            ConsumptionAmount = gasBoiler.ConsumptionAmount + gasMotor.ConsumptionAmount;
        }
        public override void DisplayGasConsumption()
        {
            Console.Writeline("Total Gas Consumption: " + ConsumptionAmount);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GasBoiler gasBoiler = new GasBoiler(10.5);
            GasMotor gasMotor = new GasMotor(5.2);
            TotalGasConsumption totalgasConsumption = new
            TotalGasConsumption(gasBoiler, gasMotor);
            gasBoiler.DisplayGasConsumption();
            gasMotor.DisplayGasConsumption();
            totalgasConsumption.DisplayGasConsumption();
            Console.ReadKey();
        }
    }
}
/*namespace GasConsumptions
{
    public abstract class GasConsumption
    {
        public double ConsumptionAmount {get; set;}
        public abstract void DisplayGasConsumption();
    }
}*/