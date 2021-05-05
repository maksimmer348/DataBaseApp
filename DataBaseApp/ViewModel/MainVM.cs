using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using DataBaseApp.Model.Excel;
using Prism.Commands;
using Prism.Mvvm;
//using DataBaseApp.Model;


namespace DataBaseApp.ViewModel
{
    public class MainVM : BindableBase
    {
        public ExcelReader ExcelRead = new ExcelReader();

        public MainVM()
        {
            //таким нехитрым способом мы пробрасываем изменившиеся свойства модели во View
           // model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
            AddCommand = new DelegateCommand<string>(str => {
                //проверка на валидность ввода - обязанность VM
                int ival;
                if (int.TryParse(str, out ival)) model.AddValue(ival);
            });
            RemoveCommand = new DelegateCommand<int?>(i => {
                if (i.HasValue) model.RemoveValue(i.Value);
            });
            //
            HaveSignal = new DelegateCommand<bool?>(b =>
            {
                {
                    model.signal = !model.signal;
                    RaisePropertyChanged(nameof(s));//ищет толко в этом классе
                }
            });
        }
        public DelegateCommand<string> AddCommand { get; }

        public DelegateCommand<int?> RemoveCommand { get; }

        public DelegateCommand<bool?> HaveSignal { get; }
        public int Sum => model.Sum;
        public bool s => model.signal;
        public ReadOnlyObservableCollection<int> MyValues => model.MyPublicValues;


    }
}
