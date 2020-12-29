using Lab9.BusinessLayer.Models;
using System.Windows;

namespace Lab9.Dialogs
{
    public partial class EditWorker : Window
    {
        WorkerViewModel workerViewModel;

        public EditWorker(WorkerViewModel workerViewModel)
        {
            InitializeComponent();
            this.workerViewModel = workerViewModel;
            grid.DataContext = workerViewModel;
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

