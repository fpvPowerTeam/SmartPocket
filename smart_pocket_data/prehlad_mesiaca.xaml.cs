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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using System.Windows.Media;
using Windows.UI;
using Windows.Foundation;
using Windows.Foundation.Collections;

using smart_pocket_data.Resources;
using smart_pocket_data.ViewModels;

namespace smart_pocket_data
{
    public partial class prehlad_mesiaca : PhoneApplicationPage
    {
        List<string> strings = new List<string>() { "dsvs", "sdgfsd", "gdsrfgvedsr", "geswfvs", "sfedc", "sef", "486svdc", "fsecf", "argwse", "sre", "ag4", "edsarfh", "drf35v", "rbesd", "fsdfs", "scdre" };
        
        public prehlad_mesiaca()
        {
            InitializeComponent();
            DataContext = App.ViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }

        private void spat_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/uvod.xaml", UriKind.Relative));
        }

        private void uprav_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/novy_zaznam.xaml", UriKind.Relative));
        }

        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (MainLongListSelector.SelectedItem == null)
                return;

            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as ItemViewModel).ID, UriKind.Relative));
            MainLongListSelector.SelectedItem = null;
        }
    }
}