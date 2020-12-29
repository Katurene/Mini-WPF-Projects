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
    /// Логика взаимодействия для UserControl_Horse.xaml
    /// </summary>
    public partial class UserControl_Horse : UserControl
    {
        int speed = 0;
        int position = 0;

        public UserControl_Horse(int speed, int position)
        {
            InitializeComponent();
            this.speed = speed;
            this.position = position;
        }

        //Добавим 2 метода обновления позиции и скорости
        public void UpdateSpeed(int newSpeed)
        {
            this.speed = newSpeed;
            //изменим метод обновления скорости
            if (InfoSpeed.Text != "")//если скор отображ то она будет изменена
                InfoSpeed.Text = speed.ToString() + " km/h";
            //чтобы скорость всегда была актуальна, во-вторых, чтобы ее можно было 
            //включать и выключать по щелчку
        }

        public void UpdatePosition(int position)
        {
            this.position = position;
            if (InfoPosition.Text != "")//Добавим отображение позиции лошадки
                InfoPosition.Text = position.ToString() + " position";
        }

        //скорость отображается в компоненте лошадки
        private void Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {//скорость появляется, но не меняется сама по себе, только по щелчку
            if (InfoSpeed.Text == "") 
            //По щелчку – если скорость отображалась – выключим ее, иначе – включим
                InfoSpeed.Text = speed.ToString() + " km/h";            
            else
                InfoSpeed.Text = "";
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (InfoPosition.Text == "")//позиция появл по щелчку левой кнопки
                InfoPosition.Text = position.ToString() + " position";
            else
                InfoPosition.Text = "";
        }
    }
}
