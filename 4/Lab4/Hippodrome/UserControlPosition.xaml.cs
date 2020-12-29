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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hippodrome
{
    /// <summary>
    /// Логика взаимодействия для UserControlPosition.xaml
    /// </summary>
    public partial class UserControlPosition : UserControl
    {
        public UserControlPosition()
        {
            InitializeComponent();
        }

        public void SetPosition(int pos)//метод записи в табло - нужен чтоб  
                                        //можно было записать в позицию то что нужно
        {
            position.Text = pos.ToString();
        }

    }
}
