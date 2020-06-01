using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace APP
{
    class Weather
    {
        ProcessStartInfo Info { get; set; }

        string WeatherPath = @"""C:\Users\Yoshiaki\OneDrive - St Paul`s School\Computing\Codes\MiniProject\APP\APP\APP\PyCode\WeatherAPI.py""";

        public Weather(double lati, double longi)
        {
            string Interpreter = @"C:\Users\Yoshiaki\OneDrive - St Paul`s School\Computing\Codes\MiniProject\APP\APP\APP\Python37_64\python.exe";

            string Lati = lati.ToString();
            string Longi = longi.ToString();

            List<string> Args = new List<string> { WeatherPath, Lati, Longi };

            Info = new ProcessStartInfo(Interpreter);
            Info.UseShellExecute = false;
            Info.RedirectStandardOutput = true;
            Info.Arguments = string.Join(" ", Args);
        }

        public void SetInfo(double Lati, double Longi)
        {
            List<string> Args = new List<string> { WeatherPath, Lati.ToString(), Longi.ToString() };
            Info.Arguments = string.Join(" ", Args);
        }

        public object[] Get_Weather() 
        {
            object[] data = new object[6];

            Process process = new Process();
            process.StartInfo = Info;

            process.Start();

            var sr = process.StandardOutput;
            var result = sr.ReadLine();

            process.WaitForExit();
            process.Close();
            data = result.Split(':');
            //
            //data[3] = double.Parse((string)data[3]);
            //data[4] = double.Parse((string)data[4]);
            //data[5] = double.Parse((string)data[5]);
            //
            return data;
        }
    }
}
