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

namespace Lab3_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person person;//пустая ссылка на person

        public MainWindow()
        {
            InitializeComponent();
            person = new Person();//созд нов объект- не пустой 
                                  //Он сам заполнится при вводе полей
            this.DataContext = person;//привязка объекта person  this-это окно
        }                  //все что будет в персоне меняться сразу отобр в окне

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"имя {person.Name} возраст {person.Age}");
        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            MessageBox.Show(e.Error.ErrorContent.ToString());
            //будет выв сообщ при вводе неправ данных
        }

    }
}
