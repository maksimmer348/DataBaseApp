using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using DataBaseApp.Annotations;
using DataBaseApp.Model;
using DataBaseApp.View;
using Prism.Commands;


namespace DataBaseApp.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {



        #region AllEntitys

        //все блоки питания
        private List<PowerSupply> allPowerSupply = DataWorker.GetAllPowerSupply();//наполняем список блокапами питания
        public List<PowerSupply> AllPowerSupply
        {
            get => allPowerSupply;
            set
            {
                allPowerSupply = value;
                INotifyPropertyChanged(nameof(AllPowerSupply));
            }
        }

        //все платы 
        private List<PCB> allPCB = DataWorker.GetAllPCB();//наполняем список платами
        public List<PCB> AllPCB
        {
            get => allPCB;
            set
            {
                allPCB = value;
                INotifyPropertyChanged(nameof(AllPCB));
            }
        }

        //все эл компоненты
        private List<ElectronicComponent> allElectronicComponent = DataWorker.GetAllElectronicComponent();//наполняем
        //список электоронными компоннеотиами
        public List<ElectronicComponent> AllElectronicComponent
        {
            get => allElectronicComponent;
            set
            {
                allElectronicComponent = value;
                INotifyPropertyChanged(nameof(AllElectronicComponent));
            }
        }

        #endregion

        #region InitVM

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void INotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region CommandsToAddNewPosition

        private RelayCommand addNewPowerSupply;
        public string PowerSupplyName { get; set; }
        public int PowerSupplyPower { get; set; }
        public int PowerSupplyVoltage { get; set; }
        private string pathToChxem { get; set; }
        List<ElectronicComponent> electronicComponents = new List<ElectronicComponent>();
        private List<PCB> PCB = new List<PCB>();

        
        public RelayCommand AddNewPowerSupply
        {
            get
            {
                return addNewPowerSupply ?? new RelayCommand(obj =>
                {
                    string res = "";
                   
                    if (PowerSupplyName != null || PowerSupplyName.Replace(" ", "").Length == 0
                        && PowerSupplyPower != null && PowerSupplyVoltage != null &&
                        electronicComponents != null && PCB != null && pathToChxem != null || 
                        pathToChxem.Replace(" ", "").Length == 0)
                    {
                        res = DataWorker.CreateAllPowerSupply(PowerSupplyName, PowerSupplyPower,
                                PowerSupplyVoltage, electronicComponents, PCB, pathToChxem);
                    }
                });
            }

        }



        #endregion

        #region Comands&MethodsOpeningWindow

        RelayCommand openAddNewWindow;

        public RelayCommand OpenAddNewWindow//используетсся для привязки команды открытия окна к биндингу кнопки
        {
            get
            {
                //если окно гне открыто используя метод OpenAddNewBDWindow открываем окно
                return openAddNewWindow ?? new RelayCommand(obj =>
                {
                    OpenAddNewBDWindow();
                });
            }
        }

        void OpenAddNewBDWindow()
        {
            AddNewBDWindow newBdWindow = new AddNewBDWindow();
            newBdWindow.Owner = Application.Current.MainWindow;//определяем его как главное окно приложения
            newBdWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;//выводим окно по центру экрана
            newBdWindow.ShowDialog();//пока окно открыто мыы не можем перейти на коно его вызвавшее
        }

        void SetColorBolck(Window wnd, string BlockName)
        {

        }

        public bool s//булево значение кторое пойдет в результат операции на которое срагирует xalm система
        {
            get
            {
                return signal;
            }
        }
        #endregion
        public bool signal = false;

        public MainVM()
        {

        }


    }
}
