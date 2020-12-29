using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace _3_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Employee employee;//ссылка на объект класса Employee
        ObservableCollection<string> results;   // глобально подключаем коллекцию для работы с листбоксом      

        public MainWindow()
        {
            InitializeComponent();

            employee = new Employee(); //создаем объект           

            stackPanelEmployee.DataContext = employee;//привязка вертик панели к объекту

            results = new ObservableCollection<string>(); // MainWindow() создаем объект коллекции
            listBoxResult.DataContext = results;//связываем с листбоксом

            List<string> cities = new List<string> { "Минск", "Могилев", "Гомель", "Полоцк", "Брест" };
            comboBoxCity.ItemsSource = cities;//ItemsSource кладем коллекцию в cities

            List<string> streets = new List<string> { "Бурдейного", "Притыцкого", "Советская", "Ленина", "Калинина" };
            comboBoxStreet.ItemsSource = streets;//ItemsSource кладем коллекцию в streets

            List<string> positions = new List<string> { "бухгалтер", "водитель", "менеджер", "продавец", "юрист" };
            comboBoxPosition.ItemsSource = positions;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(employee.ToString());
            results.Add(employee.ToString());//добавл сотрудник приведенный в строку
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("text.txt");
            foreach (string str in results)
                streamWriter.WriteLine(str);
            streamWriter.Close();
        }
    }
}
