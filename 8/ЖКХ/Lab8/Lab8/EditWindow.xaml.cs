using System.Windows;
using Lab8.Models;

namespace Lab8
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        Payer payer;

        public EditWindow(Payer payer)
        {
            InitializeComponent();
            this.payer = payer;
            grid.DataContext = payer;
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
