using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace APP
{
    class News
    {
        public string[] country_name { get; set; }

        string[] country_code { get; set; }
        ProcessStartInfo Info { get; set; }

        string Num { get; set; }

        string NewsPath = @"""C:\Users\Yoshiaki\OneDrive - St Paul`s School\Computing\Codes\MiniProject\APP\APP\APP\PyCode\News.py""";

        public News()
        {
            string Interpreter = @"C:\Users\Yoshiaki\OneDrive - St Paul`s School\Computing\Codes\MiniProject\APP\APP\APP\Python37_64\python.exe";
            country_code = new string[] { "uk" };
            Num = "8";

            List<string> Args = new List<string> { NewsPath, Num, country_code[0]};

            Info = new ProcessStartInfo(Interpreter);
            Info.UseShellExecute = false;
            Info.RedirectStandardOutput = true;
            Info.Arguments = string.Join(" ", Args);
        }

        public void SetInfo(int num)
        {
            Num = num.ToString();
            List<string> Args = new List<string> { NewsPath, Num, country_code[0] };
            Info.Arguments = string.Join(" ", Args);
        }

        public List<List<string>> Get_News()
        {
            List< List<string>> news = new List<List<string>> ();

            Process process = new Process();
            process.StartInfo = Info;

            process.Start();

            var sr = process.StandardOutput;
            var result = sr.ReadToEnd();

            process.WaitForExit();
            process.Close();

            string[] del = { "##new##" };
            List<string> data = new List<string>(result.Split(del, StringSplitOptions.None));

            for (int x = 0; x < data.Count; x += 1)
            {
                news.Add(new List<string>(data[x].Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None)));
            }

            return news;
        }
    }
}
