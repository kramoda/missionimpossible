namespace ProductionCost
{
    private double _heatProduction;
    private double _costPerUnit;

    public ProductionCost(double heatProduction, double costPerUnit)
    {
        _heatProduction = heatProduction;
        _costPerUnit = costPerUnit;
    }
    public double CalculateTotalCost()
    {
        return _heatProduction * _costPerUnits;
    }

    public class OilBoiler : ProducedHeat
    {
        private ProductionCost _productionCost;
        public OilBoiler(double heatProduction, double costPerUnit)
        {
            ProducedHeat = heatProduction 
            _productionCost = ProductionCost;
        }
        public override void DisplayHeatProduction()
        {
            Console.Writeline("The oil boiler is producing " + ProducedHeat + " units of heat. ");
            Console.Writeline("The total production cost is: " + _productionCost.CalculateTotalCost());

        }
    }
    public class GasMotor : ProducedHeat
    {
        private ProductionCost _productionCost;
        public GasMotor(double heatProduction, double costPerUnit)
        {
            ProducedHeat = heatProduction
            _productionCost = ProductionCost;
        }
        public override void DisplayHeatProduction()
        {
            Console.Writeline("The gas motor is producing " + ProducedHeat + " units of heat. ");
            Console.Writeline("The total production cost is: " + _productionCost.CalculateTotalCost());
        }
    }
    public class GasBoiler : ProducedHeat
    {
        private ProductionCost _productionCost;
        public GasMotor(double heatProduction, double costPerUnit)
        {
            ProducedHeat = heatProduction
            _productionCost = ProductionCost;
        }
        public override void DisplayHeatProduction()
        {
            Console.Writeline("The gas boiler is producing " + ProducedHeat + " units of heat. ");
            Console.Writeline("The total production cost is: " + _productionCost.CalculateTotalCost());

        }
    }
    public class ElectricBoiler : ProducedHeat
    {
        private ProductionCost _productionCost;
        public ElectricBoiler(double heatProduction, double costPerUnit)
        {
            ProducedHeat = heatProduction
            _productionCost = ProductionCost;
        }
        public override void DisplayHeatProduction()
        {
            Console.Writeline("The electric boiler is producing " + ProducedHeat + " units of heat. ");
            Console.Writeline("The total production cost is: " + _productionCost.CalculateTotalCost());
        }
    }

    ProductionCost productionCost = new ProductionCost(0.1, 10.0;) //$0.1 per unit of heat, $10 total cost

    OilBoiler oilBoiler = new OilBoiler(100.0, ProductionCost);
    oilBoiler.DisplayHeatProduction();

    GasMotor gasMotor = new GasMotor(200.0, ProductionCost);
    gasMotor.DisplayHeatProduction();

    GasBoiler gasBoiler = new GasBoiler(300.0, ProductionCost);
    gasBoiler.DisplayHeatProduction();

    ElectricBoiler electricBoiler = new ElectricBoiler(400.0, ProductionCost);
    electricBoiler.DisplayHeatProduction();
}