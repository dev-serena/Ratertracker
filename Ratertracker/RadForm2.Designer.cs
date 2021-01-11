namespace Ratertracker
{
    partial class RadForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadForm2));
            this.dataGrid = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.Location = new System.Drawing.Point(0, 2);
            // 
            // 
            // 
            this.dataGrid.MasterTemplate.AllowAddNewRow = false;
            this.dataGrid.MasterTemplate.AllowColumnReorder = false;
            this.dataGrid.MasterTemplate.AllowDragToGroup = false;
            gridViewTextBoxColumn1.HeaderText = "id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            gridViewTextBoxColumn1.VisibleInColumnChooser = false;
            gridViewTextBoxColumn2.HeaderImage = global::Ratertracker.Properties.Resources.thin_023_calendar_date;
            gridViewTextBoxColumn2.HeaderText = "Year";
            gridViewTextBoxColumn2.Name = "column9";
            gridViewTextBoxColumn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            gridViewTextBoxColumn2.Width = 70;
            gridViewTextBoxColumn3.HeaderImage = global::Ratertracker.Properties.Resources.thin_022_calendar_date;
            gridViewTextBoxColumn3.HeaderText = "Month";
            gridViewTextBoxColumn3.Name = "column2";
            gridViewTextBoxColumn3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            gridViewTextBoxColumn3.Width = 80;
            gridViewTextBoxColumn4.HeaderImage = global::Ratertracker.Properties.Resources.thin_001_compose_write_pencil_new;
            gridViewTextBoxColumn4.HeaderText = "EXP";
            gridViewTextBoxColumn4.Name = "column3";
            gridViewTextBoxColumn4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            gridViewTextBoxColumn4.Width = 80;
            gridViewTextBoxColumn5.HeaderImage = global::Ratertracker.Properties.Resources.thin_001_compose_write_pencil_new;
            gridViewTextBoxColumn5.HeaderText = "SXS";
            gridViewTextBoxColumn5.Name = "column4";
            gridViewTextBoxColumn5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            gridViewTextBoxColumn5.Width = 80;
            gridViewTextBoxColumn6.HeaderImage = global::Ratertracker.Properties.Resources.thin_002_write_pencil_new_edit;
            gridViewTextBoxColumn6.HeaderText = "TSK";
            gridViewTextBoxColumn6.Name = "column5";
            gridViewTextBoxColumn6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            gridViewTextBoxColumn6.Width = 70;
            gridViewTextBoxColumn7.HeaderImage = global::Ratertracker.Properties.Resources.thin_027_stopwatch_time1;
            gridViewTextBoxColumn7.HeaderText = "Time AET";
            gridViewTextBoxColumn7.Name = "column6";
            gridViewTextBoxColumn7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            gridViewTextBoxColumn7.Width = 80;
            gridViewTextBoxColumn8.HeaderImage = global::Ratertracker.Properties.Resources.thin_027_stopwatch_time1;
            gridViewTextBoxColumn8.HeaderText = "Time Real";
            gridViewTextBoxColumn8.Name = "column7";
            gridViewTextBoxColumn8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            gridViewTextBoxColumn8.Width = 80;
            gridViewTextBoxColumn9.HeaderImage = global::Ratertracker.Properties.Resources.thin_151_money_price_us_dollars_cash_coins;
            gridViewTextBoxColumn9.HeaderText = "Earn AET";
            gridViewTextBoxColumn9.Name = "column8";
            gridViewTextBoxColumn9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            gridViewTextBoxColumn9.Width = 80;
            gridViewTextBoxColumn10.HeaderImage = global::Ratertracker.Properties.Resources.thin_151_money_price_us_dollars_cash_coins;
            gridViewTextBoxColumn10.HeaderText = "Earn RT";
            gridViewTextBoxColumn10.Name = "column10";
            gridViewTextBoxColumn10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            gridViewTextBoxColumn10.Width = 80;
            this.dataGrid.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.dataGrid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(722, 399);
            this.dataGrid.TabIndex = 16;
            this.dataGrid.ThemeName = "ControlDefault";
            this.dataGrid.UserDeletingRow += new Telerik.WinControls.UI.GridViewRowCancelEventHandler(this.dataGrid_userdeletingrow);
            this.dataGrid.UserDeletedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.dataGrid_userdeletedrow);
            this.dataGrid.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dataGrid_CellValidating);
            this.dataGrid.Click += new System.EventHandler(this.dataGrid_Click);
            // 
            // radButton1
            // 
            this.radButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton1.Image = global::Ratertracker.Properties.Resources.thin_050_logout_exit_door;
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(580, 407);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(142, 44);
            this.radButton1.TabIndex = 14;
            this.radButton1.Text = "Close";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // RadForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 454);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.radButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RadForm2";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Monthly stats";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RadForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadGridView dataGrid;
    }
}
