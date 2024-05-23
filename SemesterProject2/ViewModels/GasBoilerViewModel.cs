using ReactiveUI;
using TheGasBoiler;

namespace SemesterProject2.ViewModels
{
    public class GasBoilerViewModel : ViewModelBase
    {
        public GasBoiler gasBoiler = new();

        private string _gBoilerMaxHeat = "Test...";

        public string GBoilerMaxHeat 
            { 
                get => _gBoilerMaxHeat; 
                set => this.RaiseAndSetIfChanged(ref _gBoilerMaxHeat, value); 
            }
        
        private string _gBoilerPCost = "Test...";

        public string GBoilerPCost 
            { 
                get => _gBoilerPCost; 
                set => this.RaiseAndSetIfChanged(ref _gBoilerPCost, value); 
            }

        private string _gBoilerEmission = "Test...";

        public string GBoilerEmission 
            { 
                get => _gBoilerEmission; 
                set => this.RaiseAndSetIfChanged(ref _gBoilerEmission, value); 
            }
        
        private string _gBoilerGConsumption = "Test...";

        public string GBoilerGConsumption 
            { 
                get => _gBoilerGConsumption; 
                set => this.RaiseAndSetIfChanged(ref _gBoilerGConsumption, value); 
            }

        public GasBoilerViewModel()
        {
            _gBoilerMaxHeat = $"Maximum heat: {gasBoiler.MaxHeat} MW";
            GBoilerMaxHeat = _gBoilerMaxHeat;

            _gBoilerPCost = $"Production Cost: {gasBoiler.ProductionCost} DKK / MWh(th)";
            GBoilerPCost = _gBoilerPCost;

            _gBoilerEmission = $"CO2 Emission: {gasBoiler.Emission} kg / MWh(th)";
            GBoilerEmission = _gBoilerEmission;

            _gBoilerGConsumption = $"Gas consumption: {gasBoiler.GasConsumption} MWh / MWh(th)";
            GBoilerGConsumption = _gBoilerGConsumption;

        }

    }
}