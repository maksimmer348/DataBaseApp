using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Media;
using DataBaseApp.Annotations;
using DataBaseApp.Model.Data;
using OfficeOpenXml;
using Prism.Regions;

namespace DataBaseApp.Model
{
    public static class DataWorker
    {
        #region LegasyCode

        //создат отдел == PowerSupply
        //public static List<PowerSupply> GetAllPowerSupply()
        //{
        //    return null;
        //}

        //создать позицию == Deadlines //ElectronicComponents
        //public static List<ElectronicComponent> GetAllElectronicComponent()
        //{
        //    return null;
        //}

        //созщдать сутрудника == PCB
        //public static List<PCB> GetAllPCB()
        //{
        //    return null;
        //}

        //удаление отдела == удаление TypeDevice
        //удаление позиции == Deadlines //сроки выполннения
        //удаление сотурдинка == PowerSupply 

        #endregion

        #region CreateEntitys

        //создат отдел == PowerSupply
        public static string CreateAllPowerSupply(string name, int power,
            int voltage, List<ElectronicComponent> electronicComponents,
            List<PCB> pCBs, string pathToSchema)
        {
            var res = "уже суещствет";
            using (ApplicationContext db = new ApplicationContext())
            {
                //сужествует ли блок питания
                var checkIsExit = db.PowerSupplies.Any(ps => ps.Name
                                                             == name);
                if (!checkIsExit)
                {
                    PowerSupply newPowerSupply = new PowerSupply
                    {
                        Name = name,
                        Power = power,
                        Voltage = voltage,

                        //ElectronicComponents = electronicComponents,

                        //PCBs = pCBs,

                        PathToSchema = pathToSchema
                    };
                    db.PowerSupplies.Add(newPowerSupply);
                    db.SaveChanges();
                    res = $"БП {newPowerSupply.Name} добавлен";
                }

                return res;
            }
        }

        //создать позицию ==
        public static string CreateAllPCB(string name, string type,
            PowerSupply namePowerSupply, List<ElectronicComponent> electronicComponents,
            string pathToSchema)
        {
            var res = "уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //сужествует ли плата
                var checkIsExist = db.PCBs.Any(pcb => pcb.Name == name);

                if (!checkIsExist)
                {
                    PCB newPcb = new PCB
                    {
                        Name = name,
                        Type = type,

                        NamePowerSupplyId = namePowerSupply.Id,
                        //NamePowerSupply = namePowerSupply,

                        //ElectronicComponents = electronicComponents,

                        PathToSchema = pathToSchema
                    };
                    db.PCBs.Add(newPcb);
                    db.SaveChanges();
                    res = $"Плата {newPcb.Name} добавлена";
                }

                return res;
            }
        }

        //созщдать сутрудника == PCB
        public static string CreateAllElectronicComponents(string name, string type, int pcbId, PCB pcb,
            int namePowerSupplyId, PowerSupply namePowerSupply, string positionNumber, string datasheetLink)

        {
            var res = "уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //сущесствует ли 
                var checkIsExist = db.ElectronicComponents.Any(ec => ec.Name == name);
                if (!checkIsExist)
                {
                    ElectronicComponent newEC = new ElectronicComponent
                    {
                        Name = name,
                        Type = type,

                        PCBId = pcb.Id,
                        //PCB = pcb,

                        NamePowerSupplyId = namePowerSupply.Id,
                        //NamePowerSupply = namePowerSupply,

                        PositionNumber = positionNumber,
                        DatasheetLink = datasheetLink
                    };
                    db.ElectronicComponents.Add(newEC);
                    db.SaveChanges();
                    res = $"Элементат {newEC.Name} добавлен";

                }
                return res;
            }
        }

        #endregion

        #region DeleteEntitys
        //удалить блок питания
        public static string DeletePowerSupply(PowerSupply powerSupply)
        {
            var res = "такого БП не существует";

            using (ApplicationContext db = new ApplicationContext())
            {
                db.PowerSupplies.Remove(powerSupply);
                db.SaveChanges();
                res = $"БП {powerSupply.Name} удален";
            };

            return res;
        }
        //удалить плату
        public static string DeletePCB(PCB PCB)
        {
            var res = "такой платы не сущетвует";

            using (ApplicationContext db = new ApplicationContext())
            {
                db.PCBs.Remove(PCB);
                db.SaveChanges();
                res = $"Плата {PCB.Name} удалена";
            }
            return res;
        }
        //удалить эл компонент
        public static string DeleteElectronicComponent(ElectronicComponent electronicComponent)
        {
            var res = "такого элемента не сущетвует";

            using (ApplicationContext db = new ApplicationContext())
            {
                db.ElectronicComponents.Remove(electronicComponent);
                db.SaveChanges();
                res = $"Элемент {electronicComponent.Name} удален";
            }
            return res;
        }

        #endregion

        #region EditEntitys
        //редактровать блок питания
        public static string EditPowerSupply(PowerSupply oldPowerSupply, string newName,
            int NewVoltage, int newPower, string newPathToSchema)
        {
            var res = "такого БП не существует";

            using (ApplicationContext db = new ApplicationContext())
            {
                PowerSupply powerSupply = db.PowerSupplies.FirstOrDefault(ps =>
                    ps.Id == oldPowerSupply.Id);

                if (powerSupply != null)
                {
                    powerSupply.Name = newName;
                    powerSupply.Voltage = NewVoltage;
                    powerSupply.Power = newPower;
                    powerSupply.PathToSchema = newPathToSchema;

                    db.SaveChanges();
                    res = $"БП {oldPowerSupply.Name} изменен";
                }
            };

            return res;
        }
        //редакторивать плату
        public static string EditPCB(PCB oldPCB, string newName, string newType, string newPathToSchema)
        {
            var res = "такой платы не сущетвует";

            using (ApplicationContext db = new ApplicationContext())
            {
                PCB PCB = db.PCBs.FirstOrDefault(pcb => pcb.Id == oldPCB.Id);
                if (PCB != null)
                {
                    PCB.Name = newName;
                    PCB.Type = newType;
                    PCB.PathToSchema = newPathToSchema;

                    db.SaveChanges();
                    res = $"Плата {oldPCB.Name} изменена";
                }
            }
            return res;
        }
        //реадктировать эл компонент
        public static string EditElectronicComponent(ElectronicComponent oldElectronicComponent,
            string newName, string newType, string newPositionNumber, string newDatasheetLink)
        {
            var res = "такого элемента не сущетвует";

            using (ApplicationContext db = new ApplicationContext())
            {
                ElectronicComponent electronicComponent = db.ElectronicComponents.
                    FirstOrDefault(ec => ec.Id == oldElectronicComponent.Id);
                if (electronicComponent != null)
                {
                    electronicComponent.Name = newName;
                    electronicComponent.Type = newType;
                    electronicComponent.PositionNumber = newPositionNumber;
                    electronicComponent.DatasheetLink = newDatasheetLink;

                    db.SaveChanges();
                    res = $"Элемент {oldElectronicComponent.Name} изменен";
                }
            }
            return res;
        }

        #endregion

        #region GetAllEntitys

        //получить все блоки питания
        public static List<PowerSupply> GetAllPowerSupply()
        {
           
            using (ApplicationContext db = new ApplicationContext())
            {
                var res = db.PowerSupplies.ToList();
                return res;
            }
        }

        //получить все платы
        public static List<PCB> GetAllPCB()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var res = db.PCBs.ToList();
                return res;
            }
        }

        //получить все эл компоненты
        public static List<ElectronicComponent> GetAllElectronicComponent()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var res = db.ElectronicComponents.ToList();
                return res;
            }
        }
        
        #endregion

    }
}
