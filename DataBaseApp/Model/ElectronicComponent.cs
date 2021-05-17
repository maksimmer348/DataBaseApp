using System.Collections.Generic;

namespace DataBaseApp.Model
{
    public class ElectronicComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int PCBId { get; set; }//id плата к которой отнноситися данный элемент
        public PCB PCB { get; set; }//плата к которой отнноситися данный элемент

        public int NamePowerSupplyId { get; set; }//id блок питания к которому относится данный элемент
        public PowerSupply NamePowerSupply { get; set; } //блок питания к которому относится данный элемент

        public string PositionNumber { get; set; }
        public string DatasheetLink { get; set; }

    }
}