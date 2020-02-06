    namespace  mcWebService
    {
    using System;
    using System.Collections;
    using System.Core;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Web.Services;
    using System.Diagnostics;
    using System.ServiceProcess;
    public class WinService1 : System.ServiceProcess.ServiceBase
    {
    /// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components;
    public WinService1()
    {
    // This call is required by the WinForms Component Designer.
    InitializeComponent();
    // TODO: Add any initialization after the InitComponent call
    }
    // The main entry point for the process
static void Main()
    {
    System.ServiceProcess.ServiceBase[] ServicesToRun;
     
    // More than one user Service may run within the same process. To add
// another service to this process, change the following line to
// create a second service object. For example,
//
// ServicesToRun = New System.ServiceProcess.ServiceBase[] {new WinService1(), new MySecondUserService()};
//
    ServicesToRun = new System.ServiceProcess.ServiceBase[] { new WinService1() };
    System.ServiceProcess.ServiceBase.Run(ServicesToRun);
    }
    /// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private void InitializeComponent()
    {
    components = new System.ComponentModel.Container();
    this.ServiceName = "WinService1";
    }
    /// <summary>
/// Set things in motion so your service can do its work.
/// </summary>
protected override void OnStart(string[] args)
    {
    // TODO: Add code here to start your service.
    }
     
    /// <summary>
/// Stop this service.
/// </summary>
protected override void OnStop()
    {
    // TODO: Add code here to perform any tear-down necessary to stop your service.
    }
    }
    }