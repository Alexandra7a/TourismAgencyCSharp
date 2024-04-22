
using ClientForm.business;
using Common.business;

namespace ClientForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IService serviceProxy = new ServiceProxy("127.0.0.1", 55556);
            
            Application.Run(new Form2(serviceProxy));
        }
    }
}