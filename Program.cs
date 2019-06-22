using System;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace SubricApp
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            if (System.IO.File.Exists("configs_app.json"))
            {
                try
                {
                    AppSettings_Def appsetting_recovered = JsonConvert.DeserializeObject<AppSettings_Def>(
                    System.IO.File.ReadAllText("configs_app.json"));
                    appsettings.splashscreen = appsetting_recovered.splashscreen;
                    appsetting_recovered = null;
                }
                catch { }

            }

            if (appsettings.splashscreen)
            {
                var xthread = new Thread(() =>
                {
                    Application.Run(new Splash());
                    Thread.CurrentThread.Abort();
                });
                xthread.SetApartmentState(ApartmentState.STA);
                xthread.Start();
            }



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainApp());
        }
    }
}
