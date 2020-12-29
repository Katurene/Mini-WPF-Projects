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
using System.Collections.ObjectModel;

namespace Lab3_1_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> results;//чтобы привязать к листу Получим листбокс результат
        Values values;

        public MainWindow()
        {
            InitializeComponent();
            values = new Values();
            grid.DataContext = values;//имя grid прописать в xaml

            results = new ObservableCollection<string>();//создадим коллекцию пустую
            listBox.DataContext = results;//привяжем коллекцию
        }

        //private void Button_Click(object sender, RoutedEventArgs e)//вариант произвольный Работает
        //{
        //    results.Clear();//чистим коллекцию чтоб старое не сохран
        //    for (double x = values.XStart; x <= values.XStop; x += values.Step)
        //    {

        //        double s = 1, y = 0;
        //        double c = 1, z = 1;
        //        for (int k = 1; k <= values.N; k++)
        //        {
        //            c *= -x * x;
        //            z *= 2 * k * (2 * k - 1);
        //            s += c / z;
        //        }
        //        y = Math.Cos(x);
        //        results.Add($"y = {y:0.000} s = {s:0.000}");
        //    }
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)//мой из задания Не работает
        //{
        //    results.Clear();//чистим коллекцию чтоб старое не сохран
        //    for (double x = values.XStart; x <= values.XStop; x += values.Step)
        //    {
        //        double s = 1, y = 0;
        //        for (int k = 1; k <= values.N; k++)
        //        {                    
        //            s += Math.Cos(k * x) / k;
        //        }
        //        y = -Math.Log(Math.Abs(2 * Math.Sin(x / 2)));
        //        results.Add($"y = {y:0.000} s = {s:0.000}");
        //    }
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            results.Clear();//чистим коллекцию чтоб старое не сохран
            for (double x = values.XStart; x <= values.XStop; x += values.Step)
            {                
                double s = 0, y = 0;
                for (int k = 0; k <= values.N; k++)
                {
                    int f = 1, c;
                    for (c = 1; c <= k; c++)
                        f = f * c;
                    s = s + ((Math.Pow(k, 2) + 1) / f * Math.Pow((x / 2), k));
                }
                y = (Math.Pow(x, 2) / 4 + x / 2 + 1) * Math.Exp(x / 2); 
                results.Add($"y = {y:0.000} s = {s:0.000}");
            }
        }
    }
}
