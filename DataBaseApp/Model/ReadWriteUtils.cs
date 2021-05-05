using System.Collections.ObjectModel;

namespace DataBaseApp.Model
{
    public class ReadWriteUtils
    {
        private readonly ObservableCollection<int> _myValues = new ObservableCollection<int>();

        public readonly ReadOnlyObservableCollection<int> MyPublicValues;
    }
}