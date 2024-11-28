using DayPlanner.ViewModels;

namespace DayPlanner.Views;

public partial class NoteListPage : ContentPage
{
    private readonly NoteListVM _viewModel;

    public NoteListPage(NoteListVM notesViewModel)
    {
        InitializeComponent();

        _viewModel = notesViewModel;
        this.BindingContext = _viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetNoteListCommand.Execute(null);
    }
}