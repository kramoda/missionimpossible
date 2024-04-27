using ReactiveUI;
using SemesterProject2.ViewModels;
using System.Reactive;
using TheGasMotor;

namespace SemesterProject2.ViewModels
{
    public class GasMotorViewModel : ViewModelBase
    {
       public GasMotor gasMotor = new();

        private string _gMotorMaxHeat = "Test...";

        public string GMotorMaxHeat 
            { 
                get => _gMotorMaxHeat; 
                set => this.RaiseAndSetIfChanged(ref _gMotorMaxHeat, value); 
            }
        
        private string _gMotorPCost = "Test...";

        public string GMotorPCost 
            { 
                get => _gMotorPCost; 
                set => this.RaiseAndSetIfChanged(ref _gMotorPCost, value); 
            }

        private string _gMotorEmission = "Test...";

        public string GMotorEmission 
            { 
                get => _gMotorEmission; 
                set => this.RaiseAndSetIfChanged(ref _gMotorEmission, value); 
            }
        
        private string _gMotorGConsumption = "Test...";

        public string GMotorGConsumption 
            { 
                get => _gMotorGConsumption; 
                set => this.RaiseAndSetIfChanged(ref _gMotorGConsumption, value); 
            }
        
        private string _gMotorMaxElec = "Test...";

        public string GMotorMaxElec 
            { 
                get => _gMotorMaxElec; 
                set => this.RaiseAndSetIfChanged(ref _gMotorMaxElec, value); 
            }

        public GasMotorViewModel()
        {
            _gMotorMaxHeat = $"Maximum heat: {gasMotor.MaxHeat} MW";
            GMotorMaxHeat = _gMotorMaxHeat;

            _gMotorPCost = $"Production Cost: {gasMotor.ProductionCost} DKK / MWh(th)";
            GMotorPCost = _gMotorPCost;

            _gMotorEmission = $"CO2 Emission: {gasMotor.Emission} kg / MWh(th)";
            GMotorEmission = _gMotorEmission;

            _gMotorGConsumption = $"Gas consumption: {gasMotor.GasConsumption} MWh / MWh(th)";
            GMotorGConsumption = _gMotorGConsumption;

            _gMotorMaxElec = $"Maximum electricity: {gasMotor.MaximumElectricity} MW";
            GMotorMaxElec = _gMotorMaxElec;

        }
    }
}