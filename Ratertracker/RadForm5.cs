using System;
using System.Configuration;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Fiddler;
using System.Reflection;

namespace Ratertracker
{
    public partial class RadForm5 : Telerik.WinControls.UI.RadForm
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        private const ushort fiddlerCoreListenPort = 8888;
        private static readonly string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public RadForm5()
        {
            InitializeComponent();
        }
        public static bool InstallCertificate()
        {


            if (!CertMaker.rootCertExists())
            {
                if (!CertMaker.createRootCert())
                    return false;

                if (!CertMaker.trustRootCert())
                    return false;
            }
            return true;
        }

        public static bool UninstallCertificate()
        {
            if (CertMaker.rootCertExists())
            {
                if (!CertMaker.removeFiddlerGeneratedCerts(true))
                    return false;
            }
            return true;
        }
        private void radButton9_Click(object sender, EventArgs e)
        {
            UninstallCertificate();
        }
        private static void EnsureRootCertificate()
        {
            BCCertMaker.BCCertMaker certProvider = new BCCertMaker.BCCertMaker();
            CertMaker.oCertProvider = certProvider;

            // On first run generate root certificate using the loaded provider, then re-use it for subsequent runs.
            string rootCertificatePath = Path.Combine(assemblyDirectory, "..", "..", "RootCertificate.p12");
            string rootCertificatePassword = "S0m3T0pS3cr3tP4ssw0rd";
            if (!File.Exists(rootCertificatePath))
            {
                certProvider.CreateRootCertificate();
                certProvider.WriteRootCertificateAndPrivateKeyToPkcs12File(rootCertificatePath, rootCertificatePassword);
            }
            else
            {
                certProvider.ReadRootCertificateAndPrivateKeyFromPkcs12File(rootCertificatePath, rootCertificatePassword);
            }

            if (!CertMaker.rootCertIsTrusted())
            {
                CertMaker.trustRootCert();
            }
        }
        private void radButton6_Click(object sender, EventArgs e)
        {
            EnsureRootCertificate();
        }
      
     
        private void radButton10_Click(object sender, EventArgs e)
        {
            config.AppSettings.Settings["leapforce"].Value = tleap.Text;
            config.AppSettings.Settings["payrate"].Value = tpayrate.Text;
            config.ConnectionStrings.ConnectionStrings["db"].ConnectionString = "Data Source=" + tdbpath.Text + ";Version=3;New=False;Compress=True;";
            config.Save(ConfigurationSaveMode.Modified);

            RadForm5.ActiveForm.Close();

        }

       
       
        private void RadForm5_Load(object sender, EventArgs e)
        {
            radserial.Text = ConfigurationManager.AppSettings["serial"];
            tleap.Text = ConfigurationManager.AppSettings["leapforce"];
            tpayrate.Text = ConfigurationManager.AppSettings["payrate"];
            tdbpath.Text= ConfigurationManager.ConnectionStrings["db"].ConnectionString.Replace("Data Source=","").Replace(";Version=3;New=False;Compress=True;","");
            radCheckBox1.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["soundaet"]);
           

        }

        private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (radCheckBox1.Checked == true)
            {

                //radTextBox2.Enabled = true;
                config.AppSettings.Settings["soundaet"].Value = "true";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                RadForm1.sndaet = true;
                

            }
            else
            {

                //radTextBox2.Enabled = false;
                config.AppSettings.Settings["soundaet"].Value = "false";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                RadForm1.sndaet = false;


            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                tdbpath.Text = folderPath + "\\capture.db";
            }
        }

        private void serials_Click(object sender, EventArgs e)
        {
            string lacle = ConfigurationManager.AppSettings["leapforce"];
           // if ((!string.IsNullOrWhiteSpace(radserial.Text) && !string.IsNullOrWhiteSpace(lacle)) == true)
          //  {
                try
                {
                    config.AppSettings.Settings["serial"].Value = radserial.Text;

                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");

                    RadForm5.ActiveForm.Close();
                    
                }
               catch (Exception ex)
                {
                    MessageBox.Show("invalid serial");
                }
          //  }
            
        }
    }
}
