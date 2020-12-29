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

namespace Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window   //partial - частичный код класса
    {
        double x;
        char oper;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            if(textBox.Text == "0")
            textBox.Text = ((Button)sender).Content.ToString();
            else
                if(textBox.Text.Length < 15)
                textBox.Text += ((Button)sender).Content.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.IndexOf(",") < 0)   //запятая не найдена
                textBox.Text += ",";
        }

        private void ButtonOper_Click(object sender, RoutedEventArgs e)
        {
            x = Convert.ToDouble(textBox.Text); //сохраняем введенное число
            oper = ((Button)sender).Content.ToString()[0];//сохраняем знак операции (0=только один нулевой-первый)
            textBox.Text = "0"; //чистим поле, присвоив 0
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e) //для =
        {
            double y = Convert.ToDouble(textBox.Text);
            double result = 0;
            switch(oper)
            {
                case '+': result = x + y; break;
                case '-': result = x - y; break;
                case '*': result = x * y; break;
                case '/': result = x / y; break;
                case 's': result = Math.Sin(x * Math.PI / 180.0); break;
                case 'c': result = Math.Cos(x * Math.PI / 180.0); break;
                case 't': result = Math.Tan(x * Math.PI / 180.0); break;
            }
            textBox.Text = result.ToString(); //вывод результата в текстовом поле
        }     

        private void ButtonClean_Click(object sender, RoutedEventArgs e) //для С
        {
            textBox.Text = "0";
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)//для удалить
        {
            if (textBox.Text.Length == 1)
                textBox.Text = "0";
            else
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
        }

    }
}
