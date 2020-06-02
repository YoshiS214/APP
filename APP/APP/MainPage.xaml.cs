using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace APP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Weather weather { get; set; }
        News news { get; set; }

        public MainPage()
        {
            InitializeComponent();

            double[] position = PositionAsync().Result;
            
            weather = new Weather(position[0], position[1]);

            news = new News();

            Reload();
        }

        public async void Reload()
        {
            while (true)
            {
                object[] w = weather.Get_Weather();
                Town.Text = w[0].ToString();
                Weather.Text = w[2].ToString();
                Temp.Text = String.Format("{0}℃", w[3].ToString());

                NewsList.Children.Clear();
                List<List<string>> n = news.Get_News();
                foreach (List<string> topic in n)
                {
                    NewsList.Children.Add(new Button { Text = topic[0] + "\n" + topic[1], BackgroundColor = Color.White, });
                }
                await Task.Delay(1000*60*10);
            }
        }

        public async Task OpenBrowser(Uri uri)
        {
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        private async Task<double[]> PositionAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    return new double[] { location.Latitude, location.Longitude };
                }
            }
            catch (Exception e)
            {
                return new double[] { 0, 0 };
            }
            return new double[] { 0, 0 };
        }
    }
}
