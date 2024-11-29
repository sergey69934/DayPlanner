using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DayPlanner.Data;
using DayPlanner.Models;
using DayPlanner.Services;
using DayPlanner.Views;

namespace DayPlanner.ViewModels
{
    public partial class NoteListVM : BaseViewModel
    {
        #region Private Fields

        private INoteRepository _noteRepository;

        [ObservableProperty]
        private ObservableCollection<NoteModel> _notes = new ObservableCollection<NoteModel>();

        [ObservableProperty]
        private string _searchText;

        [ObservableProperty]
        private NoteModel _selectedNote;

        #endregion Private Fields

        #region Private Methods

        [RelayCommand]
        private async Task AddNote()
        {
            await NavigationService.NavigateToAsync(nameof(NoteEditPage), new Dictionary<string, object>
            {
                { nameof(NoteModel), new NoteModel() }
            });
        }

        [RelayCommand]
        private async Task DeleteNote(NoteModel noteModel)
        {
            await _noteRepository.DeleteNoteAsync(noteModel);
            Notes.Remove(noteModel);
        }

        [RelayCommand]
        private async Task GetNoteList()
        {
            var noteList = await _noteRepository.GetNotesAsync();

            Notes.Clear();
            if (noteList?.Count > 0)
            {
                foreach (var note in noteList)
                {
                    Notes.Add(note);
                }
            }
        }

        [RelayCommand]
        private async Task NoteTapped()
        {
            await NavigationService.NavigateToAsync(nameof(NoteEditPage), new Dictionary<string, object>
            {
                { nameof(NoteModel), SelectedNote }
            });

            SelectedNote = null;
        }

        partial void OnSearchTextChanged(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                Task.Run(async () =>
                {
                    await SearchNotes(value);
                });
            }
            else
            {
                GetNoteListCommand.Execute(this);
            }
        }

        private async Task SearchNotes(string value)
        {
            var noteList = await _noteRepository.GetFilteredNotesAsync(value);

            Notes.Clear();
            if (noteList?.Count > 0)
            {
                foreach (var note in noteList)
                {
                    Notes.Add(note);
                }
            }
        }

        #endregion Private Methods

        #region Public Constructors

        public NoteListVM(INoteRepository noteRepository, INavigationService navigationService) : base(navigationService)
        {
            _noteRepository = noteRepository;

            SelectedNote = null;
        }

        #endregion Public Constructors
    }
}