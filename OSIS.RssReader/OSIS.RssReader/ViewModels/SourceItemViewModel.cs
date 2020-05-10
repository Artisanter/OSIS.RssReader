using OSIS.RssReader.Data;
using OSIS.RssReader.ViewModels.Bases;
using System.Windows.Input;
using Xamarin.Forms;

namespace OSIS.RssReader.ViewModels
{
    public class SourceItemViewModel : BaseForViewModel
    {
        public SourceItemViewModel(int sourceId = 0, bool saveOnDatabase = true)
        {
            SaveOnDatabase = saveOnDatabase;
            if (sourceId != 0)  {
                Id = sourceId;
            }

            IsBusy = true;
            LoadData();
            IsBusy = false;
        }


        public void LoadData()
        {
            if (Id == 0)
                return;

            var source = Repo.GetSource(Id);
            Title = source.Title;
            SourceUrl = source.SourceUrl;
        }


        private string _sourceUrl;

        public string SourceUrl
         {
            get => _sourceUrl;
            set => OnPropertyChanging(nameof(SourceUrl), ref _sourceUrl, value);
        }

        private ICommand _saveCommand;

        public ICommand SaveSourceItem => _saveCommand ??= new Command(ExecuteSaveSourceCommand);


        public delegate void EmptyHandler();

        public event EmptyHandler OnSave;

        private void ExecuteSaveSourceCommand()
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(SourceUrl))
            {
                return;
            }

            IsBusy = true;

            var source = Repo.GetSource(Id);
            source ??= new Source();

            source.Title = Title;
            source.SourceUrl = SourceUrl;

            if (SaveOnDatabase)
            {
               Id = Repo.SaveSource(source);
            }

            IsBusy = false;

            OnSave?.Invoke();
        }
    }
}
