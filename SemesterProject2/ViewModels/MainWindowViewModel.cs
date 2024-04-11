using ReactiveUI;
using System;
using System.Reactive.Linq;


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
        
        public void Menu()
        {
            MainMenuViewModel mainMenuViewModel = new();
            ContentViewModel = mainMenuViewModel;
        }
    
        

    }
}
