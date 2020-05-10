using System.Collections.ObjectModel;
using System.Linq;

namespace OSIS.RssReader.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static int RemoveAll<T>(this ObservableCollection<T> observableCollection)
        {
            if (observableCollection != null)
            {
                var toRemove = observableCollection
                    .ToList();

                if (toRemove.Count > 0 && observableCollection.Count > 0)
                    return toRemove.Count(observableCollection.Remove);
                return -1;
            }

            return -1;
        }
    }
}
