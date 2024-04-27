using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SemesterProject2.ViewModels;

namespace SemesterProject2.Views;

public partial class ElectricBoilerView : UserControl
{
    public ElectricBoilerView()
    {
        DataContext = new ElectricBoilerViewModel();
        InitializeComponent();
    }
}