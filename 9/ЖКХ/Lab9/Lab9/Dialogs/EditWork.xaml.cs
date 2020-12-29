using Lab9.BusinessLayer.Models;
using System.Windows;

namespace Lab9.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для EditGroup.xaml
    /// </summary>
    public partial class EditWork : Window
    {
        WorkViewModel workViewModel;
        public EditWork(WorkViewModel workViewModel)
        {
            InitializeComponent();
            this.workViewModel = workViewModel;
            grid.DataContext = workViewModel;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

