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

namespace CheckBox
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double min = Double.MaxValue;
        double max = Double.MinValue;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double x = Convert.ToDouble(textBoxX.Text),
                   y = Convert.ToDouble(textBoxY.Text);

            double fx = 0, b;

            if (radioButton1.IsChecked == true)
                fx = Math.Sin(x);
            if (radioButton2.IsChecked == true)
                fx = Math.Cos(x);
            if (radioButton3.IsChecked == true)
                fx = Math.Tan(x);

            string str;
            if (y != 0)
            {
                double z = x / y;
                if (z > 0)
                {
                    b = Math.Pow(Math.Log(fx + Math.Pow(fx, 2) + y), 3);
                    str = "\nВетвь 1: x / y > 0";
                }

                else if (z < 0)
                {
                    b = Math.Log(Math.Abs(fx / y)) + Math.Pow(fx + y, 3);
                    str = "\nВетвь 2: x / y < 0";
                }

                else //(x == 0)
                {
                    b = Math.Pow(Math.Pow(fx, 2) + y, 3);
                    str = "\nВетвь 3.";
                }
            }
            else
            {
                b = 0;
                str = "\nВетвь 4";
            }

            labelResult.Content = $"b = {b:0.#####}" + str;

            if (b < min)
                min = b;
            if (b > max)
                max = b;
            if (checkBoxMin.IsChecked == true)
                labelResult.Content += $"\nmin = {min:0.#####}";
            if (checkBoxMax.IsChecked == true)
                labelResult.Content += $"\nmax = {max:0.#####}";
        }
    }
}
