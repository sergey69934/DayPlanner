using DayPlanner.ViewModels;

namespace DayPlanner.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsVM settingsVM)
	{
		InitializeComponent();

		this.BindingContext = settingsVM;
    }
}