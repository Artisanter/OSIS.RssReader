using OSIS.RssReader.Helpers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OSIS.RssReader.ViewModels.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OSIS.RssReader.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [SuppressMessage("ReSharper", "RedundantExtendsListEntry")]
    public partial class MasterView : ContentPage
    {
        public ListView Menu { get; }


        public MasterView()
        {
            InitializeComponent();

            Menu = this.MenuListView;
            Menu.ItemsSource = new List<MainMenuItem>
            {
                new MainMenuItem
                {
                    Title = "Feed",
                    IconSource = UiHelpers.SetOsImagePath("home.png"),
                    TargetType = typeof(PostList)
                },
                new MainMenuItem
                {
                    Title = "Sources",
                    IconSource = UiHelpers.SetOsImagePath("RSSMenuIcon.png"),
                    TargetType = typeof(SourceList)
                }
            };
        }
    }
}