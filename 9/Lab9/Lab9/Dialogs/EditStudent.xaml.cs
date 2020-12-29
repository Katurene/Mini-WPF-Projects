using Lab9.BusinessLayer.Models;
using System.Windows;

namespace Lab9.Dialogs
{
    public partial class EditStudent : Window   //окно редактирования
    {
        StudentViewModel student;

        public EditStudent(StudentViewModel student)
        {
            InitializeComponent();
            this.student = student;
            grid.DataContext = student;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(student.FileName + " " + student.DateOfBirth);
            this.DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

