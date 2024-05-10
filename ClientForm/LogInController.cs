using Common.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientForm
{
    internal class LogInController
    {

        private IService service;
        public LogInController(IService service)
        {
            this.service=service;
        }

        public void login(string user, string pass)
        {
            //controller
            AgencyViewController agencyViewController = new AgencyViewController();

             agencyViewController.setService(service);
            agencyViewController.findUser(user,pass);

            
                Form ff = new Form1(agencyViewController);
               
                ff.Show();
           
        }

    }
}
