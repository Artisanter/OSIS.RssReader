namespace OSIS.RssReader.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new OSIS.RssReader.App());
        }
    }
}
