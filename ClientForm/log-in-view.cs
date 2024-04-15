using Common.business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClientForm
{
    internal partial class Form2 : Form
    {


        private IService service;

        public Form2(IService service)
        {
            InitializeComponent();
            this.service = service;
            
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            var result = service.findUser(userField.Text.ToString(), passField.Text.ToString());
            if (result != null)
            {
                Form ff = new Form1(service,result);
                ff.Show();
            }
            else
            {
                MessageBox.Show("Password or username wrong");
            }
        }
    }
}
