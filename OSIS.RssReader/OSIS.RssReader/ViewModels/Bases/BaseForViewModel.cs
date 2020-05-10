using MvvmHelpers;
using OSIS.RssReader.Repositories;

namespace OSIS.RssReader.ViewModels.Bases
{
    public abstract class BaseForViewModel : BaseViewModel
    {
        private int _id;
        protected readonly RssRepository Repo = new RssRepository();
        protected bool SaveOnDatabase;


        public int Id
        {
            get => _id;
            set => OnPropertyChanging(nameof(Id), ref _id, value);
        }

        protected void OnPropertyChanging<T>(string name, ref T property, T value)
        {
            if (property is null)
            {
                if(value is null)
                    return;
            }
            else if (property.Equals(value))
            {
                return;
            }

            property = value;
            OnPropertyChanged(name);
        }
    }
}
