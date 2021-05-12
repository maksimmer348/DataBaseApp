using System.Collections.Generic;
using System.Linq;
using DataBaseApp.Model.Data;
using OfficeOpenXml;

namespace DataBaseApp.Model
{
    public static class DataWorker
    {
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

        public static string CreateAllPowerSupply(string name)
        {
            string res = "уже суещствет";
            using (ApplicationContext db = new ApplicationContext())
            {
                //сужествует ли блок питания
                bool checkIsExit = db.PowerSupplies.Any(ps => ps.Name == name);
                if (!checkIsExit)
                {
                    PowerSupply newPowerSupply = new PowerSupply { Name = name };
                    db.PowerSupplies.Add(newPowerSupply);
                    db.SaveChanges();
                    res = "Сделано!";
                }
                return res;
            }

        }

    }
}