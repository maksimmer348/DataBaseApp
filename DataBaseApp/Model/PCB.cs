using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

     namespace DataBaseApp.Model
{
    public class PCB//платы
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int  NamePowerSupplyId { get; set; }//id блок питания к которому будет отнносится плата
        public PowerSupply NamePowerSupply { get; set; }// блок питания к которому будет отнносится плата

        public List<ElectronicComponent> ElectronicComponents { get; set; }//электорнные компоненты которые будут отнносится к плате
        
        public string PathToSchema { get; set; }
        
    }
}
