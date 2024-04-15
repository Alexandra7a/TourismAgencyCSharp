namespace ClientForm
{
    partial class Form1
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
            this.allTripsGrid = new System.Windows.Forms.DataGridView();
            this.allTripsGridPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allTripsGridTransportCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allTripsGridDeparture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allTripsGridPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allTripsGridNoSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientsGrid = new System.Windows.Forms.DataGridView();
            this.clientsGridUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.placeField = new System.Windows.Forms.TextBox();
            this.reserveButton = new System.Windows.Forms.Button();
            this.filter = new System.Windows.Forms.Button();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.hour2Combo = new System.Windows.Forms.ComboBox();
            this.hour1Combo = new System.Windows.Forms.ComboBox();
            this.noSeatsField = new System.Windows.Forms.TextBox();
            this.phoneNumberField = new System.Windows.Forms.TextBox();
            this.nameField = new System.Windows.Forms.TextBox();
            this.filteredTripsGrid = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.filteredTripsGridPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filteredTripsGridTransportCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filteredTripsGridDeparture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filteredTripsGridPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filteredTripsGridNoSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.allTripsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredTripsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // allTripsGrid
            // 
            this.allTripsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allTripsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.allTripsGridPlace,
            this.allTripsGridTransportCompanyName,
            this.allTripsGridDeparture,
            this.allTripsGridPrice,
            this.allTripsGridNoSeats});
            this.allTripsGrid.Location = new System.Drawing.Point(30, 27);
            this.allTripsGrid.Name = "allTripsGrid";
            this.allTripsGrid.RowHeadersWidth = 51;
            this.allTripsGrid.RowTemplate.Height = 24;
            this.allTripsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allTripsGrid.Size = new System.Drawing.Size(944, 128);
            this.allTripsGrid.TabIndex = 0;
            this.allTripsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allTripsGrid_CellContentClick);
            // 
            // allTripsGridPlace
            // 
            this.allTripsGridPlace.HeaderText = "Place";
            this.allTripsGridPlace.MinimumWidth = 6;
            this.allTripsGridPlace.Name = "allTripsGridPlace";
            this.allTripsGridPlace.Width = 125;
            // 
            // allTripsGridTransportCompanyName
            // 
            this.allTripsGridTransportCompanyName.HeaderText = "transport Company";
            this.allTripsGridTransportCompanyName.MinimumWidth = 6;
            this.allTripsGridTransportCompanyName.Name = "allTripsGridTransportCompanyName";
            this.allTripsGridTransportCompanyName.Width = 125;
            // 
            // allTripsGridDeparture
            // 
            this.allTripsGridDeparture.HeaderText = "departure";
            this.allTripsGridDeparture.MinimumWidth = 6;
            this.allTripsGridDeparture.Name = "allTripsGridDeparture";
            this.allTripsGridDeparture.Width = 125;
            // 
            // allTripsGridPrice
            // 
            this.allTripsGridPrice.HeaderText = "price";
            this.allTripsGridPrice.MinimumWidth = 6;
            this.allTripsGridPrice.Name = "allTripsGridPrice";
            this.allTripsGridPrice.Width = 125;
            // 
            // allTripsGridNoSeats
            // 
            this.allTripsGridNoSeats.HeaderText = "noSeats";
            this.allTripsGridNoSeats.MinimumWidth = 6;
            this.allTripsGridNoSeats.Name = "allTripsGridNoSeats";
            this.allTripsGridNoSeats.Width = 125;
            // 
            // clientsGrid
            // 
            this.clientsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clientsGridUsername});
            this.clientsGrid.Location = new System.Drawing.Point(12, 346);
            this.clientsGrid.Name = "clientsGrid";
            this.clientsGrid.RowHeadersWidth = 51;
            this.clientsGrid.RowTemplate.Height = 24;
            this.clientsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientsGrid.Size = new System.Drawing.Size(369, 172);
            this.clientsGrid.TabIndex = 2;
            // 
            // clientsGridUsername
            // 
            this.clientsGridUsername.HeaderText = "username";
            this.clientsGridUsername.MinimumWidth = 6;
            this.clientsGridUsername.Name = "clientsGridUsername";
            this.clientsGridUsername.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "No Seats";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Phone Number";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(472, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Place";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(472, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Start Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(472, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "End Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(823, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Between";
            // 
            // placeField
            // 
            this.placeField.Location = new System.Drawing.Point(544, 215);
            this.placeField.Name = "placeField";
            this.placeField.Size = new System.Drawing.Size(134, 22);
            this.placeField.TabIndex = 10;
            // 
            // reserveButton
            // 
            this.reserveButton.Location = new System.Drawing.Point(306, 270);
            this.reserveButton.Name = "reserveButton";
            this.reserveButton.Size = new System.Drawing.Size(75, 23);
            this.reserveButton.TabIndex = 11;
            this.reserveButton.Text = "Reserve";
            this.reserveButton.UseVisualStyleBackColor = true;
            this.reserveButton.Click += new System.EventHandler(this.reserveButton_Click);
            // 
            // filter
            // 
            this.filter.Location = new System.Drawing.Point(934, 305);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(75, 23);
            this.filter.TabIndex = 12;
            this.filter.Text = "filter";
            this.filter.UseVisualStyleBackColor = true;
            this.filter.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(544, 254);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(250, 22);
            this.startDatePicker.TabIndex = 13;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(544, 299);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(250, 22);
            this.endDatePicker.TabIndex = 14;
            // 
            // hour2Combo
            // 
            this.hour2Combo.FormattingEnabled = true;
            this.hour2Combo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.hour2Combo.Location = new System.Drawing.Point(888, 257);
            this.hour2Combo.Name = "hour2Combo";
            this.hour2Combo.Size = new System.Drawing.Size(121, 24);
            this.hour2Combo.TabIndex = 15;
            // 
            // hour1Combo
            // 
            this.hour1Combo.FormattingEnabled = true;
            this.hour1Combo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.hour1Combo.Location = new System.Drawing.Point(888, 221);
            this.hour1Combo.Name = "hour1Combo";
            this.hour1Combo.Size = new System.Drawing.Size(121, 24);
            this.hour1Combo.TabIndex = 16;
            // 
            // noSeatsField
            // 
            this.noSeatsField.Location = new System.Drawing.Point(112, 305);
            this.noSeatsField.Name = "noSeatsField";
            this.noSeatsField.Size = new System.Drawing.Size(182, 22);
            this.noSeatsField.TabIndex = 17;
            // 
            // phoneNumberField
            // 
            this.phoneNumberField.Location = new System.Drawing.Point(112, 271);
            this.phoneNumberField.Name = "phoneNumberField";
            this.phoneNumberField.Size = new System.Drawing.Size(182, 22);
            this.phoneNumberField.TabIndex = 18;
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(112, 240);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(182, 22);
            this.nameField.TabIndex = 19;
            // 
            // filteredTripsGrid
            // 
            this.filteredTripsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filteredTripsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filteredTripsGridPlace,
            this.filteredTripsGridTransportCompany,
            this.filteredTripsGridDeparture,
            this.filteredTripsGridPrice,
            this.filteredTripsGridNoSeats});
            this.filteredTripsGrid.Location = new System.Drawing.Point(452, 334);
            this.filteredTripsGrid.Name = "filteredTripsGrid";
            this.filteredTripsGrid.RowHeadersWidth = 51;
            this.filteredTripsGrid.RowTemplate.Height = 24;
            this.filteredTripsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.filteredTripsGrid.Size = new System.Drawing.Size(682, 116);
            this.filteredTripsGrid.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(7, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 29);
            this.label8.TabIndex = 21;
            this.label8.Text = "Reservation";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(447, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 29);
            this.label9.TabIndex = 22;
            this.label9.Text = "Filter";
            // 
            // filteredTripsGridPlace
            // 
            this.filteredTripsGridPlace.HeaderText = "place";
            this.filteredTripsGridPlace.MinimumWidth = 6;
            this.filteredTripsGridPlace.Name = "filteredTripsGridPlace";
            this.filteredTripsGridPlace.Width = 125;
            // 
            // filteredTripsGridTransportCompany
            // 
            this.filteredTripsGridTransportCompany.HeaderText = "transport Company";
            this.filteredTripsGridTransportCompany.MinimumWidth = 6;
            this.filteredTripsGridTransportCompany.Name = "filteredTripsGridTransportCompany";
            this.filteredTripsGridTransportCompany.Width = 125;
            // 
            // filteredTripsGridDeparture
            // 
            this.filteredTripsGridDeparture.HeaderText = "depature";
            this.filteredTripsGridDeparture.MinimumWidth = 6;
            this.filteredTripsGridDeparture.Name = "filteredTripsGridDeparture";
            this.filteredTripsGridDeparture.Width = 125;
            // 
            // filteredTripsGridPrice
            // 
            this.filteredTripsGridPrice.HeaderText = "price";
            this.filteredTripsGridPrice.MinimumWidth = 6;
            this.filteredTripsGridPrice.Name = "filteredTripsGridPrice";
            this.filteredTripsGridPrice.Width = 125;
            // 
            // filteredTripsGridNoSeats
            // 
            this.filteredTripsGridNoSeats.HeaderText = "noSeats";
            this.filteredTripsGridNoSeats.MinimumWidth = 6;
            this.filteredTripsGridNoSeats.Name = "filteredTripsGridNoSeats";
            this.filteredTripsGridNoSeats.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 563);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.filteredTripsGrid);
            this.Controls.Add(this.nameField);
            this.Controls.Add(this.phoneNumberField);
            this.Controls.Add(this.noSeatsField);
            this.Controls.Add(this.hour1Combo);
            this.Controls.Add(this.hour2Combo);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.reserveButton);
            this.Controls.Add(this.placeField);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientsGrid);
            this.Controls.Add(this.allTripsGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.allTripsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredTripsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView allTripsGrid;
        private System.Windows.Forms.DataGridView clientsGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox placeField;
        private System.Windows.Forms.Button reserveButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button filter;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.ComboBox hour2Combo;
        private System.Windows.Forms.ComboBox hour1Combo;
        private System.Windows.Forms.TextBox noSeatsField;
        private System.Windows.Forms.TextBox phoneNumberField;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.DataGridView filteredTripsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn allTripsGridPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn allTripsGridTransportCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn allTripsGridDeparture;
        private System.Windows.Forms.DataGridViewTextBoxColumn allTripsGridPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn allTripsGridNoSeats;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientsGridUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn filteredTripsGridPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn filteredTripsGridTransportCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn filteredTripsGridDeparture;
        private System.Windows.Forms.DataGridViewTextBoxColumn filteredTripsGridPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn filteredTripsGridNoSeats;
    }
}

