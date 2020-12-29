using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person person;//ссылка

        ObservableCollection<Person> collection = new ObservableCollection<Person>();//коллекция объектов person

        public MainWindow()
        {
            person = new Person();//создаем объект
            InitializeComponent();
            stackpanelPerson.DataContext = person;//стекпанель связываем с персоной
            
            listBox.DataContext = collection;//листбокс связываем с коллекцией
        }

        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(person.ToString());
            collection.Clear();//чистим коллекцию
            foreach (var p in Person.GetAllPersons())//внутри форича будет подаваться по одной записи
            {
                collection.Add(p);//и добавляем что-то в коллекцию из БД
            }
        }

        private void FillData()
        {
            collection.Clear();
            foreach (var p in Person.GetAllPersons())
            {
                collection.Add(p);
            }
        }

        private void ButtonInsert_Click(object sender, RoutedEventArgs e)
        {
            //collection.Add(person);//по кнопке ВСТАВИТЬ объект person добавл к коллекции

            person.Insert();//вызовем метод Insert при нажатии на кнопку ВСТАВИТЬ. И сразу отобразим новое состояние БД
            FillData();//
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var id = ((Person)listBox.SelectedItem).Id;//listBox.SelectedItem - выделенный объект преобразованный к Персон
            Person.Delete(id);//извлекаем id выделенного объекта и удаляем
            FillData();
        }

        private void ButtonFind_Click(object sender, RoutedEventArgs e)//статич метод - ищет по всей коллекции
        {
            string str = textBoxName.Text;//берет в str текст из текстбокса 
            person = Person.Find(str);//подает его person
            if (person == null)//если нет то
                MessageBox.Show("Запись не найдена!");
            else
                MessageBox.Show(person.ToString());//иначе выводит эту персону
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem == null) return;//если ничего не выбрано-возврат, чтоб не ломалось
            person.Id = ((Person)listBox.SelectedItem).Id;//из выделенного SelectedItem выбираем идентификатор
            if (textBoxName.Text.Length > 0)//если что то введено то заменяется
                person.Name = textBoxName.Text;
            else
                person.Name = ((Person)listBox.SelectedItem).Name;//если в textBoxName ничего не введено 
                                                                  //то берется старое имя
            decimal d = Convert.ToDecimal(textBoxSum.Text);
            if (d != 0)                       
                person.Sum = d;  //если поменялась то введем новую
            else
                person.Sum = ((Person)listBox.SelectedItem).Sum;//если сумма равна 0 то оставим старую
            person.Update();
            FillData();
        }
    }
}
