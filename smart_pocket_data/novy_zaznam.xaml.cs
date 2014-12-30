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
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Xml;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;

namespace smart_pocket_data
{
    public partial class novy_zaznam : PhoneApplicationPage
    {

        List<string> strings = new List<string>();
        int check_suma = 0, check_poznamka = 0;

        public novy_zaznam()
        {
            InitializeComponent();
          //  listBox.ItemsSource = strings;

            // READ FROM XML
            try
            {
                using (IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream str = ISF.OpenFile("People.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                        strings = (List<string>)serializer.Deserialize(str);
                        
                        this.listBox.ItemsSource = strings;         
                        
                    }
                }
            }
            catch
            {
                //add some code here
                MessageBox.Show("File not found :("); 
            }
        }

        private void plus_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            strings.Add(textbox_suma.Text);
            XmlWriterSettings x_W_Settings = new XmlWriterSettings();
            x_W_Settings.Indent = true;
           
            using (IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = ISF.OpenFile("People.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, x_W_Settings))
                    {
                        serializer.Serialize(xmlWriter, strings);
                        MessageBox.Show("Data Save!!!!");
                    }
                }
            }
           // listBox.ItemsSource = strings;
           // this.plus.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/images/minus.png");
            /*
            double suma = Convert.ToDouble(textbox_suma.Text);
            if (suma < 0)
                suma = suma * (-1);
            textbox_suma.Text = suma.ToString();/*
            this.listBox1.Items.Add(suma.ToString());
            listBox1.Width = 140;
            listBox1.SelectionChanged += ListBox_SelectionChanged;
          */
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Add code to perform some action here.
        }
        private void minus_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            textbox_suma.Text = "-" + textbox_suma.Text;
        }

        private void spat_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/uvod.xaml", UriKind.Relative));
        }

        private void suma_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (check_suma == 0)
            {
                textbox_suma.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                textbox_suma.Text = "";
                check_suma = 1;
            }
        }

        private void poznamka_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (check_poznamka == 0)
            {
                textbox_poznamka.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                textbox_poznamka.Text = "";
                check_poznamka = 1;
            }
        }

        private async void ok_tap(object sender, GestureEventArgs e)
        {
            await WriteToFile("ahoj.txt", "ahoj\nahoj");

            NavigationService.Navigate(new Uri("/prehlad_mesiaca.xaml", UriKind.Relative));
        }

        public async Task WriteToFile(string fileName, string content)
        {
            byte[] data = System.Text.Encoding.Unicode.GetBytes(content);

            var folder = ApplicationData.Current.LocalFolder;
            var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            using (var s = await file.OpenStreamForWriteAsync())
            {
                await s.WriteAsync(data, 0, data.Length);
            }
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