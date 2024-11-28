using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DayPlanner.Data;
using DayPlanner.Models;
using DayPlanner.Views;

namespace DayPlanner.ViewModels
{
    [QueryProperty(nameof(NoteModel), nameof(Models.NoteModel))]
    public partial class NoteEditVM : ObservableValidator
    {
        #region Private Fields

        [ObservableProperty]
        private NoteModel _noteModel;

        private INoteRepository _noteRepository;

        #endregion Private Fields

        #region Private Methods

        [RelayCommand]
        private async Task Cancel()
        {
            await Shell.Current.GoToAsync(nameof(NoteListPage));
        }

        [RelayCommand]
        private async Task Save()
        {
            NoteModel.CreatedOrUpdatedDate = DateTime.Now;

            var response = await _noteRepository.SaveNoteAsync(NoteModel);

            await Shell.Current.GoToAsync(nameof(NoteListPage));
        }

        #endregion Private Methods

        #region Public Constructors

        public NoteEditVM(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        #endregion Public Constructors
    }
}
