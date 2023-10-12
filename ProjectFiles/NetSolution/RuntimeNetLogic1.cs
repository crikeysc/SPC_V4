#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Alarm;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.DataLogger;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.Report;
using FTOptix.Modbus;
using FTOptix.RAEtherNetIP;
using FTOptix.Retentivity;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
using System.Reflection;
using System.Collections.Generic;
using FTOptix.SerialPort;
using FTOptix.System;
using FTOptix.EventLogger;
using FTOptix.WebUI;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        string[,] myArray = (string[,])Project.Current.GetVariable("Model/Arrays/LocationValue").Value.Value;

        if (myArray[0, 0] == "0" && myArray[0, 1] == "0" && myArray[0, 2] == "0")
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[0, i] = "";
            }
        }
    }
    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }
}
