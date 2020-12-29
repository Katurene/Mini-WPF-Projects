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
using System.Windows.Shapes;
using Lab8.Models;

namespace Lab8
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window //модальное окно для редактирования данных чтобы не править в БД напрямую
    {
        Student student;//объект типа студент
       
        public EditWindow(Student student)//когда будет создаваться окно, то оно получит готового студента
        {
            InitializeComponent();

            this.student = student;//и положит его в свою ссылку
            grid.DataContext = student;//привязка
        }

        //стандартные обработчики
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
