using System.Windows;
using DataBaseApp.ViewModel;
namespace DataBaseApp.View
{
    /// <summary>
    /// Interaction logic for PowerSupplyWindow.xaml
    /// </summary>
    public partial class AddNewBDWindow : Window
    {
        public AddNewBDWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }
    }
}
