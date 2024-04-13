using ReactiveUI;
using SemesterProject2.ViewModels;
using System;
using System.ComponentModel;
using System.Reactive;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Input;
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

        /*
        public string EBoilerMaxHeat()
        {
            //string HeatMax = "Maximum heat: " + electricBoiler.MaxHeat + "MW";
            string HeatMax = $"Maximum heat: {electricBoiler.MaxHeat} MW";
            return HeatMax;
        }
        
        private string? EBoilerHeat;
        public string? EBoilerMaxHeat
        {
            get => EBoilerHeat;
            set
            {
            EBoilerHeat = value;
            OnPropertyChanged("EBoilerMaxHeat");
            }
        }

        public void NewTest()
        {
            EBoilerMaxHeat = "Test";
        }

        */


        /*
        public void EBoilerMaxHeat()
        {
            _message = $"Maximum heat: {electricBoiler.MaxHeat} MW";
            Message = _message;
        }
        */
        

        /*
        string ProductionCost = "Production Cost: " + electricBoiler.ProductionCost + "DKK / MWh(th)";
        string MaximumElectricity = "Maximum electricity: " + electricBoiler.ElectricityMaximum + "MW";
        */

    }
}