namespace ProducedHeat
{
    public abstract class ProducedHeat
    {
        public double ProducedHeat { get; set;}
        public abstract void DisplayHeatProduction();
    }
    public class OilBoiler : ProducedHeat
    {
        public OilBoiler(double heatProduction)
        {
            ProducedHeat = heatProduction;
        }
        public override void DisplayHeatProduction()
        {
            Console.Writeline("The oil boiler is producing " + ProducedHeat + "units of heat. ");
        }
    }
    public class GasMotor : ProducedHeat
    {
        public GasMotor(double heatProduction)
        {
            ProducedHeat = heatProduction;
        }
        public override void DisplayHeatProduction()
        {
            Console.Writeline("The gas motor is producing " + ProducedHeat + "units of heat. ");
        }
    }
    public class GasBoiler : ProducedHeat
    {
        public GasBoiler(double heatProduction)
        {
            ProducedHeat = heatProduction;
        }
        public override void DisplayHeatProduction()
        {
            Console.writeline("The gas boiler is producing " + ProducedHeat + "units of heat. ");
        }
    }
    public class ElectricBoiler : ProducedHeat
    {
        public ElectricBoiler(double heatProduction)
        {
            ProducedHeat = heatProduction;
        }
        public override void DisplayHeatProduction()
        {
            Console.Writeline("The electric boiler is producing " + ProducedHeat + "units of heat. ");
        }
    }
    OilBoiler oilBoiler = new OilBoiler(100.0);
    oilBoiler.DisplayHeatProduction();
    GasMotor gasMotor = new GasMotor(200.0);
    gasMotor.DisplayHeatProduction();
    GasBoiler gasBoiler = new GasBoiler(300.0);
    gasBoiler.DisplayHeatProduction();
    ElectricBoiler electricBoiler = new ElectricBoiler(400.0);
    electricBoiler.DisplayHeatProduction();
}