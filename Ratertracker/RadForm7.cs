using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Win32;

namespace Ratertracker
{
    public partial class RadForm7 : Telerik.WinControls.UI.RadForm
    {

        private String connectionString;
        private SQLiteConnection connection;
        // SQLiteDataReader sqlite_datareader;
        //  private String SQLInsert = "INSERT INTO month(year,month, totexp, totsxs, tottsk, totaet, totrt, totdol) VALUES(?, ?, ?, ?, ?, ?, ?, ?)";
        //  private String SQLUpdate = "UPDATE month SET year = ?,totexp = ?, totsxs = ?, tottsk = ?, totaet = ?, totrt = ?, totdol = ? WHERE month = ? AND year = ?";

        private String SQLSelect2 = "SELECT * FROM tasks WHERE year = ? AND month = ? AND day=? AND tottsk!=?";
        private String SQLSelect = "SELECT * FROM tasks WHERE year = ? AND month = ? AND tottsk!=?";
        private String SQLSelect3 = "SELECT * FROM tasks WHERE year = ? AND month = ? AND tottsk!=?";

        private int cntrow = 0;
        private string previousMonth;
        private string currentyear;
        private string ccurrentyear;
        private string ppreviousMonth;
        private string monthnum;
        public RadForm7()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);
            previousMonth = DateTime.Now.AddMonths(-1).ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture);
            ppreviousMonth = DateTime.Now.AddMonths(-2).ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture);
            currentyear = DateTime.Now.AddYears(0).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ccurrentyear = DateTime.Now.AddYears(-1).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
      
      
        private void RadForm7_Load(object sender, EventArgs e)
        {
            radDropDownList1.Text = previousMonth;
            radDropDownList1.Items.Add(previousMonth);
            radDropDownList1.Items.Add(ppreviousMonth);
            radDropDownList2.Text = currentyear;
            radDropDownList2.Items.Add(currentyear);
            radDropDownList2.Items.Add(ccurrentyear);
            monthnum = DateTime.ParseExact(radDropDownList1.Text, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month.ToString();
            label1.Text = monthnum;
            radLabel2.Text = "Clique on Open IE Button for opening internet explorer";
            int BrowserVer, RegVal;

            // get the installed IE version
            using (WebBrowser Wb = new WebBrowser())
                BrowserVer = Wb.Version.Major;
            label1.Text = BrowserVer.ToString(); ;
            // set the appropriate IE version
            if (BrowserVer >= 11)
                RegVal = 11001;
            else if (BrowserVer == 10)
                RegVal = 10001;
            else if (BrowserVer == 9)
                RegVal = 9999;
            else if (BrowserVer == 8)
                RegVal = 8888;
            else
                RegVal = 7000;

            // set the actual key
            using (RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", RegistryKeyPermissionCheck.ReadWriteSubTree))
                if (Key.GetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe") == null)
                    Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);

        }

        private void radButton10_Click(object sender, EventArgs e)
        {
            RadForm7.ActiveForm.Close();
        }
        
        public static double ConvertSecondsToMinutes(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalMinutes;
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            //webBrowser1.Navigate("https://www.ratertracker.xyz/invoice.html");
            webBrowser1.Navigate("https://connect.appen.com/qrp/core/vendors/invoice/add");

            int RowCount = 0;
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLSelect;
            command.Parameters.AddWithValue("year", radDropDownList2.Text);
            command.Parameters.AddWithValue("month", radDropDownList1.Text);
            command.Parameters.AddWithValue("tottsk", "0");
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    RowCount++;
                }
            }

            label1.Text = RowCount.ToString();
            cntrow = RowCount;
            connection.Close();
            radButton2.Enabled = true;
            radLabel2.Text = "Login to your account and select the good month for invoice then click on fill invoice";

        }

        private async void radButton2_Click(object sender, EventArgs e)
        {
            label1.Text = cntrow.ToString();
            int number = 1;
          
           // while (number < cntrow)
           // {

              //  HtmlElement row = webBrowser1.Document.GetElementById("addRow");
              //  row.InvokeMember("Click");
              //  await PutTaskDelay();
               // number = number + 1;
            //}
           
            int x = 0;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            for (int i = 1; i < 32; i++)
            {

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = SQLSelect2;
                command.Parameters.AddWithValue("year", radDropDownList2.Text);
                command.Parameters.AddWithValue("month", radDropDownList1.Text);
                command.Parameters.AddWithValue("day", i);
                command.Parameters.AddWithValue("tottsk", "0");

                using (SQLiteDataReader read = command.ExecuteReader())


                {
                    while (read.Read())
                    {
                        TimeSpan timeq = TimeSpan.Parse(read.GetValue(read.GetOrdinal("totaet")).ToString());
                        string ladate = read.GetValue(read.GetOrdinal("day")).ToString();

                        HtmlElement RowDate = webBrowser1.Document.GetElementById("entries[" + x + "].date");
                        RowDate.InnerText = monthnum.PadLeft(2, '0') + "/" + ladate.PadLeft(2, '0') + "/" + currentyear;

                        HtmlElement RowType = webBrowser1.Document.GetElementById("entries[" + x + "].type");
                        RowType.SetAttribute("value", "PROJECT");
                        RowType.InvokeMember("change");

                        HtmlElement Rowaddnote = webBrowser1.Document.GetElementById("add-" + x);
                        Rowaddnote.InvokeMember("Click");

                        HtmlElement RowProject = webBrowser1.Document.GetElementById("selected-project-" + x);
                        RowProject.SetAttribute("value", "1");
                        
                         SendKeys.Send("y");
                       
                       
                        HtmlElement RowDesc = webBrowser1.Document.GetElementById("entries[" + x + "].description");
                        RowDesc.InnerText = read.GetValue(read.GetOrdinal("totexp")).ToString() + "-EXP " + read.GetValue(read.GetOrdinal("totsxs")).ToString() + "-SXS";
                        HtmlElement row = webBrowser1.Document.GetElementById("addRow");
                        if ( x + 1 < cntrow)
                           {
                            row.InvokeMember("Click");
                        }
                        
                        await PutTaskDelay();
                        HtmlElement RowHours = webBrowser1.Document.GetElementById("entries[" + x + "].hours");
                        RowHours.SetAttribute("value", timeq.Hours.ToString());

                        HtmlElement RowMinutes = webBrowser1.Document.GetElementById("entries[" + x + "].minutes");
                        RowMinutes.SetAttribute("value", timeq.Minutes.ToString());
                       


                        x = x + 1;


                        //  getgoodtimeaet(read.GetValue(read.GetOrdinal("totaet")).ToString()),


                    }
                }
            }
            connection.Close();
            radButton4.Enabled = true;
            radLabel2.Text = "Now you can check if everything is good and click on submit";
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
           
        }

       

        private void radButton5_Click(object sender, EventArgs e)
        {
            

        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            

            HtmlElement row = webBrowser1.Document.GetElementById("save");
            row.InvokeMember("Click");
            
            radLabel2.Text = "Done";
        }

        private void radDropDownList1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            monthnum = DateTime.ParseExact(radDropDownList1.Text, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month.ToString();
            label1.Text = monthnum;
        }

        private void radDropDownList2_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void radButton3_Click_1(object sender, EventArgs e)
        {
           
           
           
                    
        }

        private void radButton5_Click_1(object sender, EventArgs e)
        {
            
            
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLSelect3;
            command.Parameters.AddWithValue("year", radDropDownList2.Text);
            command.Parameters.AddWithValue("month", radDropDownList1.Text);
            command.Parameters.AddWithValue("tottsk", "0");
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    TimeSpan timeq = TimeSpan.Parse(read.GetValue(read.GetOrdinal("totaet")).ToString());
                    string ladate = read.GetValue(read.GetOrdinal("day")).ToString();
                    radTextBox1.Text = radTextBox1.Text + ladate.PadLeft(2, '0') + "/" + radDropDownList1.Text + " " + " " + read.GetValue(read.GetOrdinal("totexp")).ToString() + "-EXP " + read.GetValue(read.GetOrdinal("totsxs")).ToString() + "-SXS " + " " + read.GetValue(read.GetOrdinal("totaet")).ToString() + "\r\n";


                    // radTextBox1.Text = radTextBox1.Text + " " + read.GetValue(read.GetOrdinal("totexp")).ToString() + "-EXP " + read.GetValue(read.GetOrdinal("totsxs")).ToString() + "-SXS";
                    // radTextBox1.Text = radTextBox1.Text + " " + timeq.Hours.ToString();
                    // radTextBox1.Text = radTextBox1.Text + " " + timeq.Minutes.ToString();
                }
            }



            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HtmlElement user = webBrowser1.Document.GetElementById("username");
            user.InnerText = "mimidra@mail.com";
            HtmlElement pwd = webBrowser1.Document.GetElementById("password");
            pwd.InnerText = "Bouboule666";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HtmlElement row = webBrowser1.Document.GetElementById("addRow");
            row.InvokeMember("Click");
            Thread.Sleep(3000);
            HtmlElement row2 = webBrowser1.Document.GetElementById("addRow");
            row2.InvokeMember("Click");
            Thread.Sleep(3000);
            HtmlElement row3 = webBrowser1.Document.GetElementById("addRow");
            row3.InvokeMember("Click");
            Thread.Sleep(3000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int number = 1;

            while (number < 5)
            {

                HtmlElement row = webBrowser1.Document.GetElementById("addRow");
                row.InvokeMember("Click");
                Thread.Sleep(3000);
                number = number + 1;
            }
        }
        async Task PutTaskDelay()
        {
            await Task.Delay(4000);
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            int number = 1;

            while (number < 5)
            {

                HtmlElement row = webBrowser1.Document.GetElementById("addRow");
                row.InvokeMember("Click");
                await PutTaskDelay();
                number = number + 1;
            }
        }
    }
}