using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DataBaseApp.Annotations;
using DataBaseApp.Model;

namespace DataBaseApp.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        //все типы девайсов 
        private List<PowerSupply> allPowerSupply = DataWorker.GetAllPowerSupply();

        //все сроки выполнения  
        private List<ElectronicComponent> allElectronicComponent = DataWorker.GetAllElectronicComponent();

        //все блоки питания 
        private List<PCB> allPCB = DataWorker.GetAllPCB();

        //все типы девайсов 
        public List<PowerSupply> AllPowerSupply
        {
            get => allPowerSupply;
            set
            {
                allPowerSupply = value;
                OnPropertyChanged(nameof(AllPowerSupply));
            }
        }

        //все сроки выполнения
        public List<ElectronicComponent> AllElectronicComponent
        {
            get => allElectronicComponent;
            set
            {
                allElectronicComponent = value;
                OnPropertyChanged(nameof(AllElectronicComponent));
            }
        }

        //все блоки питания 
        public List<PCB> AllPCB
        {
            get => allPCB;
            set
            {
                allPCB = value;
                OnPropertyChanged(nameof(AllPCB));
            }
        }

        public MainVM()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
