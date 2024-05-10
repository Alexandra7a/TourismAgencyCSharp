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
using AgencyServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Utils;
using AgencyModel.model;

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
            try
            {
                Form1 userStage = null;

                userStage = new Form1();
                Optional<Employee> result = service.findUser(userField.Text.ToString(), passField.Text.ToString(), userStage);

                if (result != null)
                {
                    userStage.setService(service, result.Value);
                  
                    userStage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password or username wrong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // this.Close();

            }

        }
    }
}
