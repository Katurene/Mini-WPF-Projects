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

namespace Race
{
    /// <summary>
    /// Логика взаимодействия для UserControlSmile.xaml
    /// </summary>
    public partial class UserControlSmile : UserControl
    {
        int speed = 0;
        int position = 0;

        public UserControlSmile(int speed, int position)
        {
            InitializeComponent();
            this.speed = speed;
            this.position = position;
        }

        public void UpdateSpeed(int newSpeed)
        {
            this.speed = newSpeed;
            if (InfoSpeed.Text != "")
                InfoSpeed.Text = speed.ToString() + " km/h";
        }

        public void UpdatePosition(int position)
        {
            this.position = position;
            if (InfoPosition.Text != "")
                InfoPosition.Text = position.ToString() + " position";
        }

        private void Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (InfoSpeed.Text == "")
                InfoSpeed.Text = speed.ToString() + " km/h";
            else
                InfoSpeed.Text = "";
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (InfoPosition.Text == "")
                InfoPosition.Text = position.ToString() + " position";
            else
                InfoPosition.Text = "";
        }
    }
}
