using OSIS.RssReader.Data;
using OSIS.RssReader.ViewModels;
using System;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;

namespace OSIS.RssReader.Views
{
    [SuppressMessage("ReSharper", "RedundantExtendsListEntry")]
    public partial class PostList : ContentPage
    {
        private PostListViewModel _viewModel;
        private bool _showLater;


        public PostList()
        {
            InitializeComponent();
        }


        private void LoadViewModel()
        {
            if (_viewModel != null)
                return;

            _viewModel = new PostListViewModel(_showLater);
            BindingContext = _viewModel;
            _viewModel.LoadData();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadViewModel();
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView) sender).SelectedItem = null;
        }

        private async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView) sender).SelectedItem is Post post)
            {
                await Navigation.PushAsync(new PostItem(post), true);
            }
        }

        private async void OnSaveForLater(object sender, EventArgs e)
        {
            var imageButton = (ImageButton)sender;
            await _viewModel.SavePost((Post)(imageButton.CommandParameter));
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var imageButton = (ImageButton)sender;
            _viewModel.DeletePost((Post)(imageButton.CommandParameter));
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            if (!string.IsNullOrWhiteSpace(SearchBar.Text))
            {
                _viewModel.FilterTeams(SearchBar.Text.Trim());
            }
        }

        private void ButtonShow_Clicked(object sender, EventArgs e)
        {
            if (!_showLater)
            {
                _showLater = true;
                this.ButtonShow.Text = "Show all";
            }
            else
            {
                _showLater = false;
                this.ButtonShow.Text = "Show post saved";
            }

            _viewModel.ShowSaveForLater = _showLater;
            _viewModel.LoadData();
        }
    }
}
