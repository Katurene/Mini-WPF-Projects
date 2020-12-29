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
                   b = Convert.ToDouble(textBoxB.Text);
            double fx = 0, g;
            if (radioButton1.IsChecked == true)
                fx = Math.Sin(x);
            if (radioButton2.IsChecked == true)
                fx = Math.Cos(x);
            if (radioButton3.IsChecked == true)
                fx = Math.Tan(x);
            double y = x * b;
            string str;
            if (y > 0.5 & y < 10)
            {
                g = Math.Exp(fx - Math.Abs(b));
                str = "\nВетвь 1: 0.5 < x * b < 10";
            }
            else if (y > 0.1 & y < 0.5)
            {
                g = Math.Sqrt(Math.Abs(fx + b));
                str = "\nВетвь 2: 0.1 < x * b < 0.5";
            }
            else
            {
                g = 2 * fx * fx;
                str = "\nВетвь 3.";
            }
            labelResult.Content = $"g = {g:0.#####}" + str;

            if (g < min)
                min = g;
            if (g > max)
                max = g;
            if (checkBoxMin.IsChecked == true)
                labelResult.Content += $"\nmin = {min:0.#####}";
            if (checkBoxMax.IsChecked == true)
                labelResult.Content += $"\nmax = {max:0.#####}";           
        }
    }
}
