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
            allTripsGrid = new DataGridView();
            allTripsGridPlace = new DataGridViewTextBoxColumn();
            allTripsGridTransportCompanyName = new DataGridViewTextBoxColumn();
            allTripsGridDeparture = new DataGridViewTextBoxColumn();
            allTripsGridPrice = new DataGridViewTextBoxColumn();
            allTripsGridNoSeats = new DataGridViewTextBoxColumn();
            clientsGrid = new DataGridView();
            clientsGridUsername = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            placeField = new TextBox();
            reserveButton = new Button();
            filter = new Button();
            startDatePicker = new DateTimePicker();
            endDatePicker = new DateTimePicker();
            hour2Combo = new ComboBox();
            hour1Combo = new ComboBox();
            noSeatsField = new TextBox();
            phoneNumberField = new TextBox();
            nameField = new TextBox();
            filteredTripsGrid = new DataGridView();
            filteredTripsGridPlace = new DataGridViewTextBoxColumn();
            filteredTripsGridTransportCompany = new DataGridViewTextBoxColumn();
            filteredTripsGridDeparture = new DataGridViewTextBoxColumn();
            filteredTripsGridPrice = new DataGridViewTextBoxColumn();
            filteredTripsGridNoSeats = new DataGridViewTextBoxColumn();
            label8 = new Label();
            label9 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)allTripsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clientsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filteredTripsGrid).BeginInit();
            SuspendLayout();
            // 
            // allTripsGrid
            // 
            allTripsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            allTripsGrid.Location = new Point(30, 34);
            allTripsGrid.Margin = new Padding(3, 4, 3, 4);
            allTripsGrid.Name = "allTripsGrid";
            allTripsGrid.RowHeadersWidth = 51;
            allTripsGrid.RowTemplate.Height = 24;
            allTripsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            allTripsGrid.Size = new Size(944, 160);
            allTripsGrid.TabIndex = 0;
            allTripsGrid.CellContentClick += allTripsGrid_CellContentClick;
            // 
            // allTripsGridPlace
            // 
            allTripsGridPlace.HeaderText = "Place";
            allTripsGridPlace.MinimumWidth = 6;
            allTripsGridPlace.Name = "allTripsGridPlace";
            allTripsGridPlace.Width = 125;
            // 
            // allTripsGridTransportCompanyName
            // 
            allTripsGridTransportCompanyName.HeaderText = "transport Company";
            allTripsGridTransportCompanyName.MinimumWidth = 6;
            allTripsGridTransportCompanyName.Name = "allTripsGridTransportCompanyName";
            allTripsGridTransportCompanyName.Width = 125;
            // 
            // allTripsGridDeparture
            // 
            allTripsGridDeparture.HeaderText = "departure";
            allTripsGridDeparture.MinimumWidth = 6;
            allTripsGridDeparture.Name = "allTripsGridDeparture";
            allTripsGridDeparture.Width = 125;
            // 
            // allTripsGridPrice
            // 
            allTripsGridPrice.HeaderText = "price";
            allTripsGridPrice.MinimumWidth = 6;
            allTripsGridPrice.Name = "allTripsGridPrice";
            allTripsGridPrice.Width = 125;
            // 
            // allTripsGridNoSeats
            // 
            allTripsGridNoSeats.HeaderText = "noSeats";
            allTripsGridNoSeats.MinimumWidth = 6;
            allTripsGridNoSeats.Name = "allTripsGridNoSeats";
            allTripsGridNoSeats.Width = 125;
            // 
            // clientsGrid
            // 
            clientsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientsGrid.Location = new Point(12, 432);
            clientsGrid.Margin = new Padding(3, 4, 3, 4);
            clientsGrid.Name = "clientsGrid";
            clientsGrid.RowHeadersWidth = 51;
            clientsGrid.RowTemplate.Height = 24;
            clientsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientsGrid.Size = new Size(369, 215);
            clientsGrid.TabIndex = 2;
            // 
            // clientsGridUsername
            // 
            clientsGridUsername.HeaderText = "username";
            clientsGridUsername.MinimumWidth = 6;
            clientsGridUsername.Name = "clientsGridUsername";
            clientsGridUsername.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 300);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 3;
            label1.Text = "Name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 381);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 4;
            label2.Text = "No Seats";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 338);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 5;
            label3.Text = "Phone Number";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(472, 269);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 6;
            label4.Text = "Place";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(472, 325);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 7;
            label5.Text = "Start Date";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(472, 381);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 8;
            label6.Text = "End Date";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(823, 276);
            label7.Name = "label7";
            label7.Size = new Size(66, 20);
            label7.TabIndex = 9;
            label7.Text = "Between";
            // 
            // placeField
            // 
            placeField.Location = new Point(544, 269);
            placeField.Margin = new Padding(3, 4, 3, 4);
            placeField.Name = "placeField";
            placeField.Size = new Size(134, 27);
            placeField.TabIndex = 10;
            // 
            // reserveButton
            // 
            reserveButton.Location = new Point(306, 338);
            reserveButton.Margin = new Padding(3, 4, 3, 4);
            reserveButton.Name = "reserveButton";
            reserveButton.Size = new Size(75, 29);
            reserveButton.TabIndex = 11;
            reserveButton.Text = "Reserve";
            reserveButton.UseVisualStyleBackColor = true;
            reserveButton.Click += reserveButton_Click;
            // 
            // filter
            // 
            filter.Location = new Point(934, 381);
            filter.Margin = new Padding(3, 4, 3, 4);
            filter.Name = "filter";
            filter.Size = new Size(75, 29);
            filter.TabIndex = 12;
            filter.Text = "filter";
            filter.UseVisualStyleBackColor = true;
            filter.Click += filterButton_Click;
            // 
            // startDatePicker
            // 
            startDatePicker.Location = new Point(544, 318);
            startDatePicker.Margin = new Padding(3, 4, 3, 4);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(250, 27);
            startDatePicker.TabIndex = 13;
            // 
            // endDatePicker
            // 
            endDatePicker.Location = new Point(544, 374);
            endDatePicker.Margin = new Padding(3, 4, 3, 4);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(250, 27);
            endDatePicker.TabIndex = 14;
            // 
            // hour2Combo
            // 
            hour2Combo.FormattingEnabled = true;
            hour2Combo.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            hour2Combo.Location = new Point(888, 321);
            hour2Combo.Margin = new Padding(3, 4, 3, 4);
            hour2Combo.Name = "hour2Combo";
            hour2Combo.Size = new Size(121, 28);
            hour2Combo.TabIndex = 15;
            // 
            // hour1Combo
            // 
            hour1Combo.FormattingEnabled = true;
            hour1Combo.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            hour1Combo.Location = new Point(888, 276);
            hour1Combo.Margin = new Padding(3, 4, 3, 4);
            hour1Combo.Name = "hour1Combo";
            hour1Combo.Size = new Size(121, 28);
            hour1Combo.TabIndex = 16;
            // 
            // noSeatsField
            // 
            noSeatsField.Location = new Point(112, 381);
            noSeatsField.Margin = new Padding(3, 4, 3, 4);
            noSeatsField.Name = "noSeatsField";
            noSeatsField.Size = new Size(182, 27);
            noSeatsField.TabIndex = 17;
            // 
            // phoneNumberField
            // 
            phoneNumberField.Location = new Point(112, 339);
            phoneNumberField.Margin = new Padding(3, 4, 3, 4);
            phoneNumberField.Name = "phoneNumberField";
            phoneNumberField.Size = new Size(182, 27);
            phoneNumberField.TabIndex = 18;
            // 
            // nameField
            // 
            nameField.Location = new Point(112, 300);
            nameField.Margin = new Padding(3, 4, 3, 4);
            nameField.Name = "nameField";
            nameField.Size = new Size(182, 27);
            nameField.TabIndex = 19;
            // 
            // filteredTripsGrid
            // 
            filteredTripsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            filteredTripsGrid.Location = new Point(452, 418);
            filteredTripsGrid.Margin = new Padding(3, 4, 3, 4);
            filteredTripsGrid.Name = "filteredTripsGrid";
            filteredTripsGrid.RowHeadersWidth = 51;
            filteredTripsGrid.RowTemplate.Height = 24;
            filteredTripsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            filteredTripsGrid.Size = new Size(682, 145);
            filteredTripsGrid.TabIndex = 20;
            // 
            // filteredTripsGridPlace
            // 
            filteredTripsGridPlace.HeaderText = "place";
            filteredTripsGridPlace.MinimumWidth = 6;
            filteredTripsGridPlace.Name = "filteredTripsGridPlace";
            filteredTripsGridPlace.Width = 125;
            // 
            // filteredTripsGridTransportCompany
            // 
            filteredTripsGridTransportCompany.HeaderText = "transport Company";
            filteredTripsGridTransportCompany.MinimumWidth = 6;
            filteredTripsGridTransportCompany.Name = "filteredTripsGridTransportCompany";
            filteredTripsGridTransportCompany.Width = 125;
            // 
            // filteredTripsGridDeparture
            // 
            filteredTripsGridDeparture.HeaderText = "depature";
            filteredTripsGridDeparture.MinimumWidth = 6;
            filteredTripsGridDeparture.Name = "filteredTripsGridDeparture";
            filteredTripsGridDeparture.Width = 125;
            // 
            // filteredTripsGridPrice
            // 
            filteredTripsGridPrice.HeaderText = "price";
            filteredTripsGridPrice.MinimumWidth = 6;
            filteredTripsGridPrice.Name = "filteredTripsGridPrice";
            filteredTripsGridPrice.Width = 125;
            // 
            // filteredTripsGridNoSeats
            // 
            filteredTripsGridNoSeats.HeaderText = "noSeats";
            filteredTripsGridNoSeats.MinimumWidth = 6;
            filteredTripsGridNoSeats.Name = "filteredTripsGridNoSeats";
            filteredTripsGridNoSeats.Width = 125;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(7, 215);
            label8.Name = "label8";
            label8.Size = new Size(141, 29);
            label8.TabIndex = 21;
            label8.Text = "Reservation";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(447, 215);
            label9.Name = "label9";
            label9.Size = new Size(68, 29);
            label9.TabIndex = 22;
            label9.Text = "Filter";
            // 
            // button1
            // 
            button1.Location = new Point(1059, 34);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 23;
            button1.Text = "logOutButton";
            button1.UseVisualStyleBackColor = true;
            button1.Click += logOutButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1177, 704);
            Controls.Add(button1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(filteredTripsGrid);
            Controls.Add(nameField);
            Controls.Add(phoneNumberField);
            Controls.Add(noSeatsField);
            Controls.Add(hour1Combo);
            Controls.Add(hour2Combo);
            Controls.Add(endDatePicker);
            Controls.Add(startDatePicker);
            Controls.Add(filter);
            Controls.Add(reserveButton);
            Controls.Add(placeField);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(clientsGrid);
            Controls.Add(allTripsGrid);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)allTripsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)clientsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)filteredTripsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView allTripsGrid;
        private DataGridViewTextBoxColumn allTripsGridPlace;
        private DataGridViewTextBoxColumn allTripsGridTransportCompanyName;
        private DataGridViewTextBoxColumn allTripsGridDeparture;
        private DataGridViewTextBoxColumn allTripsGridPrice;
        private DataGridViewTextBoxColumn allTripsGridNoSeats;
        private DataGridView clientsGrid;
        private DataGridViewTextBoxColumn clientsGridUsername;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox placeField;
        private Button reserveButton;
        private Button filter;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private ComboBox hour2Combo;
        private ComboBox hour1Combo;
        private TextBox noSeatsField;
        private TextBox phoneNumberField;
        private TextBox nameField;
        private DataGridView filteredTripsGrid;
        private DataGridViewTextBoxColumn filteredTripsGridPlace;
        private DataGridViewTextBoxColumn filteredTripsGridTransportCompany;
        private DataGridViewTextBoxColumn filteredTripsGridDeparture;
        private DataGridViewTextBoxColumn filteredTripsGridPrice;
        private DataGridViewTextBoxColumn filteredTripsGridNoSeats;
        private Label label8;
        private Label label9;
        private Button button1;
    }
}

