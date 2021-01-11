using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Ratertracker
{
    public partial class RadForm2 : Telerik.WinControls.UI.RadForm
    {
        private String connectionString;
        private SQLiteConnection connection;
       
        private String SQLUpdate2 = "UPDATE month SET year = ?, month = ?,totexp = ?, totsxs = ?, tottsk = ?, totaet = ?, totrt = ?, totdol = ?,totdolrt = ? WHERE id = ?";
       // private String SQLSelect = "SELECT * FROM month WHERE month = ?";
        private String SQLSelect2 = "SELECT * FROM month";
        private String SQLDelete = "DELETE FROM month WHERE id = ?";
        private string leidx;
        public RadForm2()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);
            search();
        }
        public string getgoodtimeaet(string oldtime)
        {
            string oldtimem = oldtime;
           
            var taet = TimeSpan.Parse(oldtimem);
           
            return string.Format("{0:000}:{1:00}:{2:00}",
                             (int)taet.TotalHours,
                             taet.Minutes,
                             taet.Seconds);
           

        }
        public string getgoodtimert(string oldtimert)
        {
            string oldtimemrt = oldtimert;

            var trt = TimeSpan.Parse(oldtimemrt);

            return string.Format("{0:000}:{1:00}:{2:00}",
                             (int)trt.TotalHours,
                             trt.Minutes,
                             trt.Seconds);

        }
        private void search()
        {
            dataGrid.Rows.Clear();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLSelect2;
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    dataGrid.Rows.Add(new object[] {
            read.GetValue(0),  // U can use column index
            read.GetValue(read.GetOrdinal("year")),
            read.GetValue(read.GetOrdinal("month")),  // Or column name like this
            read.GetValue(read.GetOrdinal("totexp")),
            read.GetValue(read.GetOrdinal("totsxs")),
            read.GetValue(read.GetOrdinal("tottsk")),
            getgoodtimeaet(read.GetValue(read.GetOrdinal("totaet")).ToString()),
            getgoodtimert(read.GetValue(read.GetOrdinal("totrt")).ToString()),
            read.GetValue(read.GetOrdinal("totdol")),
            read.GetValue(read.GetOrdinal("totdolrt"))
            });
                }
            }
            connection.Close();


        }
        public string modtime(string timert)
        {
            string xtimerx = timert;

            var hours = Int32.Parse(xtimerx.Split(':')[0]);
            var minutes = Int32.Parse(xtimerx.Split(':')[1]);
            var secondes = Int32.Parse(xtimerx.Split(':')[2]);

            var ts = new TimeSpan(hours, minutes, secondes);
            return ts.ToString();
        }
        private void dataGrid_CellValidating(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLUpdate2;
            command.Parameters.AddWithValue("year", dataGrid.CurrentRow.Cells[1].Value.ToString());
            command.Parameters.AddWithValue("month", dataGrid.CurrentRow.Cells[2].Value.ToString());
            command.Parameters.AddWithValue("totexp", dataGrid.CurrentRow.Cells[3].Value.ToString());
            command.Parameters.AddWithValue("totsxs", dataGrid.CurrentRow.Cells[4].Value.ToString());
            command.Parameters.AddWithValue("tottsk", dataGrid.CurrentRow.Cells[5].Value.ToString());
            command.Parameters.AddWithValue("totaet", modtime(dataGrid.CurrentRow.Cells[6].Value.ToString()));
            command.Parameters.AddWithValue("totrt", modtime(dataGrid.CurrentRow.Cells[7].Value.ToString()));
            command.Parameters.AddWithValue("totdol", dataGrid.CurrentRow.Cells[8].Value.ToString());
            command.Parameters.AddWithValue("totdolrt", dataGrid.CurrentRow.Cells[9].Value.ToString());
            command.Parameters.AddWithValue("id", dataGrid.CurrentRow.Cells[0].Value.ToString());



            command.ExecuteNonQuery();
            connection.Close();
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            RadForm2.ActiveForm.Close();
        }
        private void dataGrid_userdeletedrow(object sender, Telerik.WinControls.UI.GridViewRowEventArgs e)
        {
            if (!String.IsNullOrEmpty(leidx))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = SQLDelete;

                command.Parameters.AddWithValue("id", int.Parse(leidx));

                command.ExecuteNonQuery();
                connection.Close();
                leidx = "";
                search();
            }
        }
        private void dataGrid_userdeletingrow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            leidx = dataGrid.CurrentRow.Cells[0].Value.ToString();
        }
        private void dataGrid_Click(object sender, EventArgs e)
        {

        }

        private void RadForm2_Load(object sender, EventArgs e)
        {

        }
    }
}
