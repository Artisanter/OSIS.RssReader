using OSIS.RssReader.Data;
using OSIS.RssReader.ViewModels;
using System;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;

namespace OSIS.RssReader.Views
{
    [SuppressMessage("ReSharper", "RedundantExtendsListEntry")]
    public partial class SourceList : ContentPage
    {
        private SourceListViewModel _vm;

        public SourceList()
        {
            InitializeComponent();
            LoadViewModel();
        }

        private void LoadViewModel()
        {
            if (_vm == null)
            {
                _vm = new SourceListViewModel();
                BindingContext = _vm;
            }

            _vm.LoadData();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _vm = null;
            LoadViewModel();
        }


        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
            => ((ListView)sender).SelectedItem = null;

        private async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(((ListView)sender).SelectedItem is Source source))
                return;

            await Navigation.PushAsync(new SourceItem(source.Id), true);
        }

        private async void OnClickedNew(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SourceItem(0), true);
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("RssReader", "Are you sure you want to delete it?", "Yes", "Cancel");

            if (!answer)
                return;

            _vm.DeleteItem((int)((ImageButton)sender).CommandParameter);
            _vm.LoadData();
        }

        public void OnEdit(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Navigation.PushAsync(new SourceItem(  Convert.ToInt32(mi.CommandParameter)), true);
        }

        public void OnTextChanged(object sender, EventArgs e)
        {
            var search = "";
            if (!string.IsNullOrEmpty(this.SearchBar.Text))
                search = this.SearchBar.Text.Trim();
            _vm.FilterTeams(search);
        }
    }
}