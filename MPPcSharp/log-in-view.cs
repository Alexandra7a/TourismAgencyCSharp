using MPPcSharp.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPPcSharp
{
    internal partial class Form2 : Form
    {


        private Service service;

        public Form2(Service service)
        {
            InitializeComponent();
            this.service = service;
            
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            var result = service.findUser(userField.Text.ToString(), passField.Text.ToString());
            if (result != null)
            {
                Form ff = new Form1();
                ff.Show();
            }
            else
            {
                MessageBox.Show("Password or username wrong");
            }
        }
    }
}
