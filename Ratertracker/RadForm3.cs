using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SQLite;

namespace Ratertracker
{

    public partial class RadForm3 : Telerik.WinControls.UI.RadForm
    {
        private String connectionString;
        private SQLiteConnection connection;
      //  SQLiteDataReader sqlite_datareader;
      //  private String SQLInsert = "INSERT INTO tasks(year, month, day, totexp, totsxs, tottsk, totaet, totrt, totdol) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)";
       // private String SQLUpdate = "UPDATE tasks SET year = ?,totexp = ?, totsxs = ?, tottsk = ?, totaet = ?, totrt = ?, totdol = ? where month = ?";
        private String SQLUpdate2 = "UPDATE tasks SET year = ?, month = ?, day = ?, totexp = ?, totsxs = ?, tottsk = ?, totaet = ?, totrt = ?, totdol = ?, totdolrt = ? WHERE id = ?";
        private String SQLSelect = "SELECT * FROM tasks WHERE year = ? AND month = ?";
        private String SQLSelect2 = "SELECT * FROM tasks WHERE year = ? ";
        private String SQLDelete = "DELETE FROM tasks WHERE id = ?";
        private string leid;
        public RadForm3()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);
            radTextBox1.Text = GetPacificStandardTime(DateTime.Now).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture);
            radDropDownList2.Text = GetPacificStandardTime(DateTime.Now).ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture);
            search();
        }
        public DateTime GetPacificStandardTime(DateTime from)
        {
            //find TimeZoneInfo of PST
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            //Convert time from Local to PST
            return TimeZoneInfo.ConvertTime(from, TimeZoneInfo.Local, tzi);
        }
        private void search()
        {
            dataGrid.Rows.Clear();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLSelect2;
            command.Parameters.AddWithValue("year", GetPacificStandardTime(DateTime.Now).ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture));
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    dataGrid.Rows.Add(new object[] {
            read.GetValue(0),  // U can use column index
            read.GetValue(read.GetOrdinal("year")),
            read.GetValue(read.GetOrdinal("month")),
            read.GetValue(read.GetOrdinal("day")),
            read.GetValue(read.GetOrdinal("totexp")),
            read.GetValue(read.GetOrdinal("totsxs")),
            read.GetValue(read.GetOrdinal("tottsk")),
            read.GetValue(read.GetOrdinal("totaet")),
            read.GetValue(read.GetOrdinal("totrt")),
            read.GetValue(read.GetOrdinal("totdol")),
            read.GetValue(read.GetOrdinal("totdolrt"))
            });
                }
            }
             
            connection.Close();
         }
        private void selectgood()
        {
            dataGrid.Rows.Clear();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLSelect;
            command.Parameters.AddWithValue("year", radTextBox1.Text);
            command.Parameters.AddWithValue("month", radDropDownList2.Text);
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                while (read.Read())
                {
                    dataGrid.Rows.Add(new object[] {
            read.GetValue(0),  // U can use column index
            read.GetValue(read.GetOrdinal("year")),
            read.GetValue(read.GetOrdinal("month")),
            read.GetValue(read.GetOrdinal("day")),
            read.GetValue(read.GetOrdinal("totexp")),
            read.GetValue(read.GetOrdinal("totsxs")),
            read.GetValue(read.GetOrdinal("tottsk")),
            read.GetValue(read.GetOrdinal("totaet")),
            read.GetValue(read.GetOrdinal("totrt")),
            read.GetValue(read.GetOrdinal("totdol")),
            read.GetValue(read.GetOrdinal("totdolrt"))
            });
                }
            }



            connection.Close();


        }
        private void dataGrid_CellValidating(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLUpdate2;
            command.Parameters.AddWithValue("year", dataGrid.CurrentRow.Cells[1].Value.ToString());
            command.Parameters.AddWithValue("month", dataGrid.CurrentRow.Cells[2].Value.ToString());
            command.Parameters.AddWithValue("day", dataGrid.CurrentRow.Cells[3].Value.ToString());
            command.Parameters.AddWithValue("totexp", dataGrid.CurrentRow.Cells[4].Value.ToString());
            command.Parameters.AddWithValue("totsxs", dataGrid.CurrentRow.Cells[5].Value.ToString());
            command.Parameters.AddWithValue("tottsk", dataGrid.CurrentRow.Cells[6].Value.ToString());
            command.Parameters.AddWithValue("totaet", dataGrid.CurrentRow.Cells[7].Value.ToString());
            command.Parameters.AddWithValue("totrt", dataGrid.CurrentRow.Cells[8].Value.ToString());
            command.Parameters.AddWithValue("totdol", dataGrid.CurrentRow.Cells[9].Value.ToString());
            command.Parameters.AddWithValue("totdolrt", dataGrid.CurrentRow.Cells[10].Value.ToString());
            command.Parameters.AddWithValue("id", dataGrid.CurrentRow.Cells[0].Value.ToString());



            command.ExecuteNonQuery();
            connection.Close();
        }


        private void radButton1_Click(object sender, EventArgs e)
        {
             RadForm3.ActiveForm.Close();
        }

        private void dataGrid_Click(object sender, EventArgs e)
        {

        }

        private void radDropDownList2_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            selectgood();
        }
        private void dataGrid_userdeletedrow(object sender, Telerik.WinControls.UI.GridViewRowEventArgs e)
        {
            if (!String.IsNullOrEmpty(leid))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = SQLDelete;

                command.Parameters.AddWithValue("id", int.Parse(leid));

                command.ExecuteNonQuery();
                connection.Close();
                leid = "";
                search();
            }
        }
        private void dataGrid_userdeletingrow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            leid = dataGrid.CurrentRow.Cells[0].Value.ToString();
        }
        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {
            selectgood();
        }

        private void RadForm3_Load(object sender, EventArgs e)
        {

        }
    }
}
