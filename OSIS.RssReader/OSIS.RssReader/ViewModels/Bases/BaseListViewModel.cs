namespace OSIS.RssReader.ViewModels.Bases
{
    public abstract class BaseListViewModel : BaseForViewModel
    {
        private bool _showEmpty;
        private bool _showListView;
        private string _itemNumberText = "";


        protected int ItemNumber { get; set; }

        public string ItemNumberText
        {
            get => _itemNumberText;
            set => OnPropertyChanging(nameof(ItemNumberText), ref _itemNumberText, value);
        }

        public bool ShowEmpty
        {
            get => _showEmpty;
            set => OnPropertyChanging(nameof(ShowEmpty), ref _showEmpty, value);
        }
        public bool ShowListView
        {
            get => _showListView;
            set => OnPropertyChanging(nameof(ShowListView), ref _showListView, value);
        }


        public abstract void DeleteItem(int id);
    }
}
