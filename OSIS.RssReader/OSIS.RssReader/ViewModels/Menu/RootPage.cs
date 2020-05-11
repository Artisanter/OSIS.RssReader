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

            SetDetailPage(new PostList());
            
            this.MasterBehavior = MasterBehavior.Popover;
        }

        private void NavigateTo(MainMenuItem menu)
        {
            if (menu == null)
                return;

            var displayPage = (Page)Activator.CreateInstance(menu.TargetType);
            SetDetailPage(displayPage);

            IsPresented = false;
        }

        private void SetDetailPage(Page page)
        {
            Detail = new NavigationPage(page)
            {
                BarTextColor = (Color)Application.Current.Resources["SecondaryColor"],
                BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"]
            };
        }
    }
}