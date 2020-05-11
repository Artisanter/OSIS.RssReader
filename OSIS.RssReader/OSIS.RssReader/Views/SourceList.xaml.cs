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
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = _vm = new SourceListViewModel();
        }


        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView) sender).SelectedItem = null;
        }

        private async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView) sender).SelectedItem is Source source)
            {
                await Navigation.PushAsync(new SourceItem(source.Id), true);
            }
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
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            _vm.FilterTeams(((SearchBar)sender).Text);
        }
    }
}