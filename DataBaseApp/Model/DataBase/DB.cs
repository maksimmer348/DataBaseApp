using System.Collections.ObjectModel;

namespace DataBaseApp.Model.DataBase
{
    public class DB
    {
        private readonly ObservableCollection<int> _myValues = new ObservableCollection<int>();

        public readonly ReadOnlyObservableCollection<int> MyPublicValues;

    }
}