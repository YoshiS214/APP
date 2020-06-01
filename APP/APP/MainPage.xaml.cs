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
