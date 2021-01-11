using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls;
using System.Threading;

namespace Ratertracker
{
    public partial class RadForm6 : Telerik.WinControls.UI.RadForm
    {
        public RadForm6()
        {
            InitializeComponent();
        }
        void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread.Sleep(500);
            Application.Restart();
            Environment.Exit(0);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["leapforce"].Value = tleap.Text;
            config.AppSettings.Settings["payrate"].Value = tpayrate.Text;
            config.Save(ConfigurationSaveMode.Modified);


            RadForm8 otherForm = new RadForm8();
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherForm.Show();


        }
       
        private void RadForm6_Load(object sender, EventArgs e)
        {
           
        }
    }
}
