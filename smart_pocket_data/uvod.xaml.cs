using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Input;
using System.Windows.Documents;

namespace smart_pocket_data
{
    public partial class uvod : PhoneApplicationPage
    {
        public uvod()
        {
            InitializeComponent();
            /*
            var str = Application.GetResourceStream(new Uri("aktualny_stav.txt", UriKind.Relative));
            StreamReader sreader = new StreamReader(str.Stream);
            suma_aktualna.Text = sreader.ReadToEnd();
            double aktualna = Convert.ToDouble(suma_aktualna.Text);
            if (aktualna >= 0)
            {
                suma_aktualna.Text = "+" + suma_aktualna.Text + " €";
                aktualna_pozadie.Background = new SolidColorBrush(Color.FromArgb(255, 15, 186, 15));
            }
            else
            {
                suma_aktualna.Text = suma_aktualna.Text + " €";
                aktualna_pozadie.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            }*/
        }

        private void koniec_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Application.Current.Terminate();
        }

        private void prehlad_mesiaca_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/prehlad_mesiaca.xaml", UriKind.Relative));
        }

        private void novy_zaznam_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/novy_zaznam.xaml", UriKind.Relative));
        }

        public async Task<string> ReadFileContentsAsync(string fileName)
        {
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync(fileName);

                using (var streamReader = new StreamReader(file))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}