//using System;
//using System.Collections;
//using System.ComponentModel;
//using System.Configuration.Install;
//using System.ServiceProcess;
//
//using System.Management;
//
//namespace APH.DataServices
//{
//	/// <summary>
//	/// Summary description for ProjectInstaller.
//	/// </summary>
//	[RunInstaller(true)]
//	public class ServiceInstaller : System.Configuration.Install.Installer
//	{
//		private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
//		private System.ServiceProcess.ServiceInstaller serviceInstaller1;
//		private System.ServiceProcess.ServiceController serviceController1;
//		/// <summary>
//		/// Required designer variable.
//		/// </summary>
////		private System.ComponentModel.Container components = null;
//
//		public ServiceInstaller()
//		{
//			// This call is required by the Designer.
//			InitializeComponent();
//
//			// TODO: Add any initialization after the InitComponent call
//		}
//
//		#region Component Designer generated code
//		/// <summary>
//		/// Required method for Designer support - do not modify
//		/// the contents of this method with the code editor.
//		/// </summary>
//		private void InitializeComponent()
//		{
//			this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
//			this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
//			this.serviceController1 = new System.ServiceProcess.ServiceController();
//			// 
//			// serviceProcessInstaller1
//			// 
//			this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
//			this.serviceProcessInstaller1.Password = null;
//			this.serviceProcessInstaller1.Username = null;
//			this.serviceProcessInstaller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller1_AfterInstall);
//			// 
//			// serviceInstaller1
//			// 
//			this.serviceInstaller1.DisplayName = "APH Data Service";
//			this.serviceInstaller1.ServiceName = "APH Data Service";
//			this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
//			// 
//			// serviceController1
//			// 
//			this.serviceController1.ServiceName = "APH Data Service";
//			// 
//			// ServiceInstaller
//			// 
//			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
//																					  this.serviceProcessInstaller1,
//																					  this.serviceInstaller1});
//
//		}
//		#endregion
//
//		private void serviceProcessInstaller1_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
//		{
//		
//		}
//
//		public override void Install(System.Collections.IDictionary stateSaver)
//		{
//
//			ServiceController Service = new ServiceController();
//			string sServiceName = this.serviceInstaller1.ServiceName;
//			
//			//Search for the current instance service (to Stop it)
//			ServiceController[] Services = ServiceController.GetServices();
//
//			Console.WriteLine("1. Searching for service '{0}'...", sServiceName);
//			for ( int i = 0 ; i < Services.Length ; i++ )
//			{
//				if (Services[i].DisplayName == sServiceName)
//				{
//					//Found the service
//					Console.WriteLine("Service '{0}' found installed.", Services[i].DisplayName);
//					Service.ServiceName = sServiceName;
//					//Stop the service
//					ServiceControllerStatus scsStatus = Service.Status;
//					Console.WriteLine("Service status = {0}", Service.Status.ToString());
//					if (scsStatus != ServiceControllerStatus.Stopped)
//					{
//						Console.WriteLine("Stopping service '{0}'...", Services[i].DisplayName);
//						Service.Stop();
//					}
//				}
//			}
//
//			//Search for the current instance service (to delete it)
//			ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE NAME = 'APH Data Service'");
//			ManagementObjectCollection qycol = query.Get();
//
//			Console.WriteLine("2. Searching for service '{0}'...", sServiceName);
//			foreach( ManagementObject mo in qycol )
//			{
//				//Console.WriteLine( mo.Path.ToString() );
//				Console.WriteLine("Deleting service '{0}'...", sServiceName);
//				mo.Delete();
//			}
//
//			// Install
//			Console.WriteLine("Installing service '{0}'...", sServiceName);
//			base.Install( stateSaver );
//			Service.ServiceName = sServiceName;
//			//Console.WriteLine("Starting service '{0}'...", sServiceName);
//			//Service.Start();
//		}
//	}
//}
