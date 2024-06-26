﻿using ReactiveUI;


namespace SemesterProject2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        
        private ViewModelBase _contentViewModel;

    
        public MainWindowViewModel()
        {
            
            _contentViewModel = new MainMenuViewModel();
           
        }
    

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }
        
        public MainMenuViewModel mainMenuViewModel = new();
        public void HeatingUnits()
        {
           HeatingUnitsViewModel heatingUnitsViewModel = new();

           ContentViewModel = heatingUnitsViewModel;
        }
        
        public void HeatingGrid()
        {
            HeatingGridViewModel heatingGridViewModel = new();
            ContentViewModel = heatingGridViewModel;
        }
    
        public void GoBack()
        {
            ContentViewModel = mainMenuViewModel;
        }

        public void ElectricBoiler()
        {
            ElectricBoilerViewModel electricBoilerViewModel = new();
            ContentViewModel = electricBoilerViewModel;
        }

        public void GasBoiler()
        {
            GasBoilerViewModel gasBoilerViewModel = new();
            ContentViewModel = gasBoilerViewModel;
        }

        public void GasMotor()
        {
            GasMotorViewModel gasMotorViewModel = new();
            ContentViewModel = gasMotorViewModel;
        }

        public void OilBoiler()
        {
            OilBoilerViewModel oilBoilerViewModel = new();
            ContentViewModel = oilBoilerViewModel;
        }

        public void ElectricityPrices()
        {
            ElectricityPricesViewModel electricityPricesViewModel = new();
            ContentViewModel = electricityPricesViewModel;
        }

        public void HeatDemand()
        {
            HeatDemandViewModel heatDemandViewModel = new();
            ContentViewModel = heatDemandViewModel;
        }

        public void Scenario1()
        {
            Scenario1ViewModel scenario1ViewModel = new();
            ContentViewModel = scenario1ViewModel;
        }

        public void Scenario2()
        {
            Scenario2ViewModel scenario2ViewModel = new();
            ContentViewModel = scenario2ViewModel;
        }

    }
}
