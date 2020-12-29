using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using Lab8.Models;

namespace Lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EntityContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new EntityContext();
            db.Payers.Load(); // загружаем данные
            dGrid.ItemsSource = db.Payers.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Payer payer = new Payer();
            EditWindow ew = new EditWindow(payer);
            var result = ew.ShowDialog();
            if (result == true)
            {
                db.Payers.Add(payer);
                db.SaveChanges();
                ew.Close();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Payer pr = dGrid.SelectedItem as Payer;
                db.Payers.Remove(pr);
                db.SaveChanges();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Payer payer = dGrid.SelectedItem as Payer;
            EditWindow ew = new EditWindow(payer);
            var result = ew.ShowDialog();
            if (result == true)
            {
                db.SaveChanges();
                ew.Close();
            }
            else
            {
                db.Entry(payer).Reload();
                dGrid.DataContext = null;
                dGrid.DataContext = db.Payers.Local;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
