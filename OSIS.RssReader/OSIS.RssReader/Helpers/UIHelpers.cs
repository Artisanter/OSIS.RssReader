using Xamarin.Forms;

namespace OSIS.RssReader.Helpers
{
    public static class UiHelpers
    {
        public static string SetOsImagePath(string imageName)
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                return "Images/" + imageName;
            }

            return imageName;
        }
    }
}
