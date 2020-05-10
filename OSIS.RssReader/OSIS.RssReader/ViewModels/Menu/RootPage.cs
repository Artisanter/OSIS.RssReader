using System;
using OSIS.RssReader.Views;
using Xamarin.Forms;

namespace OSIS.RssReader.ViewModels.Menu
{
    public class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            var menuPage = new MasterView();
            menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MainMenuItem);

            Master = menuPage;

            Detail = new NavigationPage(new PostList())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = (Color) Application.Current.Resources["PrimaryColor"]
            };
            
            this.MasterBehavior = MasterBehavior.Popover;
        }

        private void NavigateTo(MainMenuItem menu)
        {
            if (menu == null)
                return;

            var displayPage = (Page)Activator.CreateInstance(menu.TargetType);
            Detail = new NavigationPage(displayPage)
            {
                BarTextColor = Color.White,
                BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"]
            };

            IsPresented = false;
        }
    }
}