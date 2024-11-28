using DayPlanner.ViewModels;

namespace DayPlanner.Views;

public partial class NoteEditPage : ContentPage
{
    public NoteEditPage(NoteEditVM noteVM)
    {
        InitializeComponent();

        BindingContext = noteVM;
    }
}