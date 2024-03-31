namespace MPPcSharp
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
            this.filteredTripsGrid = new System.Windows.Forms.DataGridView();
            this.clientsGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.placeField = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.hour2Field = new System.Windows.Forms.ComboBox();
            this.hour1Field = new System.Windows.Forms.ComboBox();
            this.noSeatsField = new System.Windows.Forms.TextBox();
            this.phoneNumberField = new System.Windows.Forms.TextBox();
            this.nameField = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.allTripsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredTripsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // allTripsGrid
            // 
            this.allTripsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allTripsGrid.Location = new System.Drawing.Point(30, 12);
            this.allTripsGrid.Name = "allTripsGrid";
            this.allTripsGrid.RowHeadersWidth = 51;
            this.allTripsGrid.RowTemplate.Height = 24;
            this.allTripsGrid.Size = new System.Drawing.Size(865, 107);
            this.allTripsGrid.TabIndex = 0;
            this.allTripsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allTripsGrid_CellContentClick);
            // 
            // filteredTripsGrid
            // 
            this.filteredTripsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filteredTripsGrid.Location = new System.Drawing.Point(475, 346);
            this.filteredTripsGrid.Name = "filteredTripsGrid";
            this.filteredTripsGrid.RowHeadersWidth = 51;
            this.filteredTripsGrid.RowTemplate.Height = 24;
            this.filteredTripsGrid.Size = new System.Drawing.Size(534, 172);
            this.filteredTripsGrid.TabIndex = 1;
            // 
            // clientsGrid
            // 
            this.clientsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientsGrid.Location = new System.Drawing.Point(12, 346);
            this.clientsGrid.Name = "clientsGrid";
            this.clientsGrid.RowHeadersWidth = 51;
            this.clientsGrid.RowTemplate.Height = 24;
            this.clientsGrid.Size = new System.Drawing.Size(369, 172);
            this.clientsGrid.TabIndex = 2;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Reserve";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(934, 305);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "filter";
            this.button2.UseVisualStyleBackColor = true;
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
            // hour2Field
            // 
            this.hour2Field.FormattingEnabled = true;
            this.hour2Field.Location = new System.Drawing.Point(888, 257);
            this.hour2Field.Name = "hour2Field";
            this.hour2Field.Size = new System.Drawing.Size(121, 24);
            this.hour2Field.TabIndex = 15;
            // 
            // hour1Field
            // 
            this.hour1Field.FormattingEnabled = true;
            this.hour1Field.Location = new System.Drawing.Point(888, 215);
            this.hour1Field.Name = "hour1Field";
            this.hour1Field.Size = new System.Drawing.Size(121, 24);
            this.hour1Field.TabIndex = 16;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 530);
            this.Controls.Add(this.nameField);
            this.Controls.Add(this.phoneNumberField);
            this.Controls.Add(this.noSeatsField);
            this.Controls.Add(this.hour1Field);
            this.Controls.Add(this.hour2Field);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.placeField);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientsGrid);
            this.Controls.Add(this.filteredTripsGrid);
            this.Controls.Add(this.allTripsGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.allTripsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredTripsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView allTripsGrid;
        private System.Windows.Forms.DataGridView filteredTripsGrid;
        private System.Windows.Forms.DataGridView clientsGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox placeField;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.ComboBox hour2Field;
        private System.Windows.Forms.ComboBox hour1Field;
        private System.Windows.Forms.TextBox noSeatsField;
        private System.Windows.Forms.TextBox phoneNumberField;
        private System.Windows.Forms.TextBox nameField;
    }
}

