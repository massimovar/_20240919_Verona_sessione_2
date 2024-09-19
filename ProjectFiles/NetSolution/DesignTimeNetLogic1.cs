#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.DataLogger;
using FTOptix.NativeUI;
using FTOptix.Recipe;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.OPCUAServer;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.Alarm;
using System.Xml.Schema;
using FTOptix.Modbus;
using FTOptix.CommunicationDriver;
#endregion

public class DesignTimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void GenerateAlarms()
    {

        // Ricavo la cartella "Alarm"
        var alarmsFolder = Project.Current.Get<Folder>("Alarms");
        alarmsFolder.Children.Clear();
        // Creo sottocartella "MyAlarms"
        var myAlarmsFolder = InformationModel.Make<Folder>("MyAlarms");
        // Associo la sottocartella "MyAlarms" ad "Alarms"
        alarmsFolder.Add(myAlarmsFolder);
        // Creo n allarmi inserendoli in "MyAlarms"
        for (int i = 1; i <= 10; i++)
        {
            var dAl = InformationModel.Make<DigitalAlarm>("myAlarm" + i);
            dAl.InputValueVariable.SetDynamicLink(Project.Current.GetVariable("CommDrivers/ModbusDriver1/ModbusStation1/Tags/ModbusTag" + i), DynamicLinkMode.ReadWrite);
            myAlarmsFolder.Children.Add(dAl);
        }
    }
}
