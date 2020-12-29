using Lab9.BusinessLayer.Models;
using System.Windows;

namespace Lab9.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для EditGroup.xaml
    /// </summary>
    public partial class EditGroup : Window //окно редактирования для группы
    {
        GroupViewModel groupViewModel;
        public EditGroup(GroupViewModel groupViewModel)
        {
            InitializeComponent();
            this.groupViewModel = groupViewModel;
            grid.DataContext = groupViewModel;
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

