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

namespace Program
{    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double x = -4.5;
            double y = 0.75 * Math.Pow(10, -4);
            double z = 0.845 * Math.Pow(10, 2);
            double a = Math.Pow(8 + Math.Pow(x - y, 2) + 1, 1/3f); //Math.Pow(x, 1 / 3f)кубический корень
            double b = (Math.Pow(x, 2) + Math.Pow(y, 2) + 2);
            double c = Math.Exp(Math.Abs(x - y));
            double d = Math.Pow(Math.Pow(Math.Tan(z), 2) + 1, x);
            double u = a / b - c * d;
            //textBox.Text = "Lab1" + h.ToString(); //вывод результата в текстовом поле 
            textBox.Text = "Lab1" + Environment.NewLine;
            textBox.Text += string.Format("u= {0:0.00000e000}", u); 
        }
    }
}



