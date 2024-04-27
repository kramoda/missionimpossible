using ReactiveUI;
using SemesterProject2.ViewModels;
using System.Reactive;
using TheOilBoiler;

namespace SemesterProject2.ViewModels
{
    public class OilBoilerViewModel : ViewModelBase
    {
       public OilBoiler oilBoiler = new();

        private string _oBoilerMaxHeat = "Test...";

        public string OBoilerMaxHeat 
            { 
                get => _oBoilerMaxHeat; 
                set => this.RaiseAndSetIfChanged(ref _oBoilerMaxHeat, value); 
            }
        
        private string _oBoilerPCost = "Test...";

        public string OBoilerPCost 
            { 
                get => _oBoilerPCost; 
                set => this.RaiseAndSetIfChanged(ref _oBoilerPCost, value); 
            }

        private string _oBoilerEmission = "Test...";

        public string OBoilerEmission 
            { 
                get => _oBoilerEmission; 
                set => this.RaiseAndSetIfChanged(ref _oBoilerEmission, value); 
            }
        
        private string _oBoilerGConsumption = "Test...";

        public string OBoilerGConsumption 
            { 
                get => _oBoilerGConsumption; 
                set => this.RaiseAndSetIfChanged(ref _oBoilerGConsumption, value); 
            }
        
       
        public OilBoilerViewModel()
        {
            _oBoilerMaxHeat = $"Maximum heat: {oilBoiler.MaxHeat} MW";
            OBoilerMaxHeat = _oBoilerMaxHeat;

            _oBoilerPCost = $"Production Cost: {oilBoiler.ProductionCost} DKK / MWh(th)";
            OBoilerPCost = _oBoilerPCost;

            _oBoilerEmission = $"CO2 Emission: {oilBoiler.Emission} kg / MWh(th)";
            OBoilerEmission = _oBoilerEmission;

            _oBoilerGConsumption = $"Gas consumption: {oilBoiler.GasConsumption} MWh / MWh(th)";
            OBoilerGConsumption = _oBoilerGConsumption;

        }
    }
}