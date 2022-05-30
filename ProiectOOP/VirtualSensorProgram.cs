using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataStore;


namespace ProiectOOP
{
    internal static class VirtualSensorProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MySQL_DataStore.ConnectToDB();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DataPresentation());
        }
        internal static void DisplaySensorValues(string headerText, SensorValue sv)
        {
            Console.WriteLine(headerText);
            Console.WriteLine("Type: " + sv.Type.ToString());
            Console.WriteLine("Timestamp: " + sv.TimeStampString);
            Console.WriteLine("Value: " + sv.Value.ToString("0.00"));

        }
    }
}
