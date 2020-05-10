using System.Diagnostics.CodeAnalysis;
using OSIS.RssReader.ViewModels;
using Xamarin.Forms;

namespace OSIS.RssReader.Views
{

    [SuppressMessage("ReSharper", "RedundantExtendsListEntry")]
    public partial class SourceItem : ContentPage 
    {
        public SourceItem()
        {
            InitializeComponent();
        }

        public SourceItem(int sourceId = 0)
        {
            InitializeComponent();

            var vm = new SourceItemViewModel(sourceId);
            vm.OnSave += async () => await Navigation.PopAsync();
            BindingContext = vm;
        }
    }
}
