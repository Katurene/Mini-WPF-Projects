using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Lab8.Models;

namespace Lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EntityContext db;//ссылка на объект EntityContext, через кот осущ связь с БД-загрузка обновление удаление

        public MainWindow()
        {
            InitializeComponent();

            db = new EntityContext();//создаем сам объект
            db.Students.Load(); // загружаем данные, обращаемся к коллекции Students
            dGrid.ItemsSource = db.Students.Local.ToBindingList(); // устанавливаем привязку Students к dGrid
                                      //Local.ToBindingList() стандарт кот извлечет всех студентов кот будут в таблице
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();//созд новый объект студент
            EditWindow ew = new EditWindow(student);//вызываем окно редактирования и подаем ему студента
            var result = ew.ShowDialog();//вызываем диалоговое окно
            if (result == true)//если пользователь ввел к-л данные
            {
                db.Students.Add(student);//то мы добавляем нового студента к БД
                db.SaveChanges();//и фиксируем изменения
                ew.Close();//и закрываем окно редактирования
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //при удалении спрашиваем. Для более безопасной работы с БД
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)//если да
            {
                Student stud = dGrid.SelectedItem as Student;//выделенная запись
                db.Students.Remove(stud);//удаляется
                db.SaveChanges();
            }
            //    if (dGrid.SelectedItems.Count > 0)//удаление работает по выделенной записи, если больше 0
            //    {
            //        for (int i = 0; i < dGrid.SelectedItems.Count; i++)//то проходим по всем записям
            //        {
            //            Student student = dGrid.SelectedItems[i] as Student;//находим выделенную
            //            if (student != null)
            //            {
            //                db.Students.Remove(student);//удаляем
            //            }
            //        }
            //    }
            //    db.SaveChanges();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Student student = dGrid.SelectedItem as Student;//берем студента который был выделен в данный момент
            EditWindow ew = new EditWindow(student);//передаем этого студента в окно редактирования
            var result = ew.ShowDialog();//выз диалог окно
            if (result == true)//если было редактирование то сохраняем
            {
                db.SaveChanges();//команда кот переносит(сохраняет) изменения в БД как только в 
                                 //таблице что то поменяется
                ew.Close();
            }
            else
            {
                //если не было редактирования,то вернем начальное значение
                db.Entry(student).Reload();
                // перегрузить DataContext
                dGrid.DataContext = null;
                dGrid.DataContext = db.Students.Local;
            }
        }

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {//спец обработчик для автоматической нумерации строк при загрузке БД
            e.Row.Header = e.Row.GetIndex() + 1;//берется индекс строки и наращ на 1 тк индекс с 0 начинается
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();//при закрытии окна происходит разрыв с базой
        } 

    }
}
