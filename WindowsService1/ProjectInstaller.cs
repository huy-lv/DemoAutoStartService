using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;

namespace WindowsService1
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            this.AfterInstall += serviceInstaller1_AfterInstall;
            //serviceInstaller1.Committed += OnCommitted;
        }

        //public void OnCommitted(object sender, InstallEventArgs e)
        //{
        //    using (ServiceController sc = new ServiceController(serviceInstaller1.ServiceName))
        //    {
        //        sc.Start();
        //    }
        //}

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            using (ServiceController sc = new ServiceController(serviceInstaller1.ServiceName))
            {
                sc.Start();
            }
        }
        //protected override void OnCommitted(System.Collections.IDictionary savedState)
        //{
        //    ServiceController sc = new ServiceController("Service1");
        //    sc.Start();
        //}
    }
}
