using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataBaseApp.Model;
using DataBaseApp.Model.Data;
using DataBaseApp.ViewModel;
using MaterialDesignThemes.Wpf;

namespace DataBaseApp.View
{

    public partial class MainWindow : Window
    {
        private ApplicationContext db;

        public MainWindow()
        {
            AddNewBDWindow b = new AddNewBDWindow();
            b.ShowDialog();
            InitializeComponent();
            DataContext = new MainVM();//подключаем биндинги
            db = new ApplicationContext();
        }

    }
}
