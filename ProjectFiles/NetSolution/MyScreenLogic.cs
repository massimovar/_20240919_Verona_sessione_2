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
using FTOptix.Modbus;
using FTOptix.CommunicationDriver;
#endregion

public class MyScreenLogic : BaseNetLogic
{
    private PeriodicTask myPeriodicTask;

    public override void Start()
    {
        Log.Info("Screen loaded");
    }

    public override void Stop()
    {
        myPeriodicTask?.Dispose();
    }

    [ExportMethod]
    public void PeriodicTaskTest()
    {
        myPeriodicTask = new PeriodicTask(MyAction, 1000, LogicObject);
        myPeriodicTask.Start();
    }

    [ExportMethod]
    public void ChangeScreenBackground()
    {
        // :(

        //((Screen) Owner).BackgroundColorVariable.Value = Colors.Red;
        //var button3 = Owner.Children.Get<Button>("Button3");
        //button3.BackgroundColorVariable.Value = Colors.Green;

        // :)

        var bnt3Bkr = LogicObject.GetVariable("Button3Background");
        bnt3Bkr.Value = Colors.Blue;
    }


    private void MyAction()
    {
        Log.Info("MyAction running");
    }


}
