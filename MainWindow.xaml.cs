using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2023._02._01_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDelete;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void sliRGB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliPiros.Value), Convert.ToByte(sliZold.Value), Convert.ToByte(sliKek.Value)));
            redLabel.Content = sliPiros.Value;
            greenLabel.Content = sliZold.Value;
            blueLabel.Content = sliKek.Value;
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            String colorValues = $"{Convert.ToByte(sliPiros.Value)};{Convert.ToByte(sliZold.Value)};{Convert.ToByte(sliKek.Value)}";

            if (lbSzinek.Items.Contains(colorValues))
            {
                MessageBox.Show("A megadott szín már hozzá van adva a listához!");
            }
            else
            {
                lbSzinek.Items.Add(colorValues);
            }
            
        }

        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.SelectedIndex >= 0)
            {
                if (!lbSzinek.Items.Contains(lbSzinek.SelectedIndex))
                {
                    isDelete = true;
                    lbSzinek.Items.RemoveAt(lbSzinek.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a listában!");
            }

            isDelete = false;
        }

        private void btnUrit_Click(object sender, RoutedEventArgs e)
        {
            isDelete = true;
            lbSzinek.Items.Clear();
            isDelete = false;
        }

        private void lbSzinek_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (!isDelete)
            {
                string[] colors = lbSzinek.SelectedItem.ToString().Split(';');
                redLabel.Content = colors[0];
                greenLabel.Content = colors[1];
                blueLabel.Content = colors[2];

                sliPiros.Value = Convert.ToByte(colors[0]);
                sliZold.Value = Convert.ToByte(colors[1]);
                sliKek.Value = Convert.ToByte(colors[2]);

                rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(colors[0]), Convert.ToByte(colors[1]), Convert.ToByte(colors[2])));
            }
        }
    }
}
