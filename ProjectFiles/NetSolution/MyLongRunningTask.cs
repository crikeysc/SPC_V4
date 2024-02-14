#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.NativeUI;
using FTOptix.System;
using FTOptix.UI;
using FTOptix.CoreBase;
using FTOptix.Alarm;
using FTOptix.DataLogger;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.Report;
using FTOptix.Modbus;
using FTOptix.RAEtherNetIP;
using FTOptix.Retentivity;
using FTOptix.CommunicationDriver;
using FTOptix.SerialPort;
using FTOptix.Core;
using System.IO;

namespace NewHMIProject
{
    #endregion
    //using System.IO; // For using the StreamReader
using FTOptix.EventLogger;
using FTOptix.WebUI;
using FTOptix.OPCUAServer;

    public class MyLongRunningTask : BaseNetLogic
    {
        public override void Start()
        {
            // Insert code to be executed when the user-defined logic is started
            myLongRunningTask = new LongRunningTask(ProcessEmailScript, LogicObject);
            myLongRunningTask.Start();
        }

        public override void Stop()
        {
            // Insert code to be executed when the user-defined logic is stopped
            myLongRunningTask.Dispose();
        }

        private void ProcessEmailScript(LongRunningTask task)
        {
            // example method to read lines from a csv file
            using (var reader = new StreamReader("path/to/csv/file.csv"))
            {
                while (!reader.EndOfStream)
                {
                    // Check whether task cancellation has been requested
                    if (task.IsCancellationRequested)
                    {
                        // Properly handle task cancellation here
                        return;
                    }

                    string line = reader.ReadLine();
                    // Process line

                }
            }
        }

        private LongRunningTask myLongRunningTask;
    }
}
