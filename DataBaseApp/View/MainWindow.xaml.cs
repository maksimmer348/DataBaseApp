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
            InitializeComponent();

        }

        void StartApp()
        {
         int Id = 12;
         string Name = "dkjfk";
         int Power = 10;
         int Voltage = 40;

        db.Add( new PowerSupply());//создадим базу данных с новым жкеземпляром класса и добавим туда значнея из тектовых полей
        db.SaveChanges();
        }
    }
}
