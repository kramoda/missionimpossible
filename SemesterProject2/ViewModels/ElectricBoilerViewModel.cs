using ReactiveUI;
using TheElectricBoiler;

namespace SemesterProject2.ViewModels
{
    public class ElectricBoilerViewModel : ViewModelBase
    {
       public ElectricBoiler electricBoiler = new();

        private string _eBoilerMaxHeat = "Test...";

        public string EBoilerMaxHeat 
            { 
                get => _eBoilerMaxHeat; 
                set => this.RaiseAndSetIfChanged(ref _eBoilerMaxHeat, value); 
            }
        
        private string _eBoilerPCost = "Test...";

        public string EBoilerPCost 
            { 
                get => _eBoilerPCost; 
                set => this.RaiseAndSetIfChanged(ref _eBoilerPCost, value); 
            }

        private string _eBoilerMaxElec = "Test...";

        public string EBoilerMaxElec 
            { 
                get => _eBoilerMaxElec; 
                set => this.RaiseAndSetIfChanged(ref _eBoilerMaxElec, value); 
            }

        public ElectricBoilerViewModel()
        {
            _eBoilerMaxHeat = $"Maximum heat: {electricBoiler.MaxHeat} MW";
            EBoilerMaxHeat = _eBoilerMaxHeat;

            _eBoilerPCost = $"Production Cost: {electricBoiler.ProductionCost} DKK / MWh(th)";
            EBoilerPCost = _eBoilerPCost;

            _eBoilerMaxElec = $"Maximum electricity: {electricBoiler.MaximumElectricity} MW";
            EBoilerMaxElec = _eBoilerMaxElec;
        }


    }
}