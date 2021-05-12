using System.Collections.ObjectModel;
using System.Security.AccessControl;

namespace DataBaseApp.Model
{
    public class PowerSupply
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int Voltage { get; set; }
        public ObservableCollection<ElectronicComponent> ElectronicComponents { get; set; }//эл компоененты которые будут относится к блоку питания
        public ObservableCollection<PCB> PCBs { get; set; }//платы которые будут относится к блоку питания
        public int DatasheetLink { get; set; }

      

        public PowerSupply()
        {
           
        }
    }
}