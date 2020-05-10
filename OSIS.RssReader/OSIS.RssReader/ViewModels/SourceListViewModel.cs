using OSIS.RssReader.Data;
using OSIS.RssReader.ViewModels.Bases;
using System.Collections.ObjectModel;
using System.Linq;

namespace OSIS.RssReader.ViewModels
{
    public class SourceListViewModel : BaseListViewModel
    {
        public ObservableCollection<Source> SourcesList { get; }


        public SourceListViewModel()
        {
            SourcesList = new ObservableCollection<Source>();
            LoadData();
        }

        public override void DeleteItem(int id)
        {
            Repo.DeleteSource(id);
            LoadData();
        }

        public void LoadData(string search = "")
        {
            IsBusy = true;

            SourcesList.Clear();
            var list = Repo.GetSource();

            if (!string.IsNullOrEmpty(search)) {
                list = list.Where(l => (l.Title != null && l.Title.Contains(search))).ToList();
            }

            if (list != null)
            {
                foreach (var source in list)
                {
                    SourcesList.Add(source);
                }

                ItemNumber = list.Count;
            }
            else
            {
                ItemNumber = 0;
            }

            if (ItemNumber == 0) {
                ShowEmpty = true;
                ShowListView = false;
                ItemNumberText = "No source found";
            }
            else
            {
                ShowEmpty = false;
                ShowListView = true;
                ItemNumberText = ItemNumber == 1 ? "1 source" : $"{ItemNumber} sources";
            }

            IsBusy = false;
        }

        public void FilterTeams(string search)
        {
            LoadData(search);
        }
    }
}
