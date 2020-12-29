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
using System.Windows.Shapes;

namespace Lab6
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window//окно для работы с интегралом
    {
        public Integral integral;//здесь создание

        public Window1()
        {
            InitializeComponent();
            integral = new Integral();
            stackPanel1.DataContext = integral;//все окно связано(ерет свои данные) с объектом интеграл 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;//диалоговое окно
        }
    }
}
