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

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для WindowShape.xaml
    /// </summary>
    public partial class WindowShape : Window
    {
        Shape shape; //здесь создается

        public WindowShape()
        {
            

            InitializeComponent();

            shape = new Shape();//создаем пустой объект
            grid.DataContext = shape;//привяжем объект к разметке 

            List<string> colors = new List<string> { "Red", "Blue", "Green" };//цвета можно любые
            comboBoxFore.ItemsSource = colors;//цвета для рамки
            comboBoxBack.ItemsSource = colors;//цвета для фона
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;//вернет результат диалога при ОК Если ОТМЕНА то ничего не будет
        }

        public Shape NewShape//сдесь прописано св-во Shape кот анализирует что нах в комбобоксе
        {                      //какой цвет был выбран
            get
            {
                switch (comboBoxBack.SelectedIndex)
                {//в shape.Background кладем кисть выбранного цвета new SolidColorBrush
                    case 0: shape.Background = new SolidColorBrush(Colors.Red); break;
                    case 1: shape.Background = new SolidColorBrush(Colors.Blue); break;
                    case 2: shape.Background = new SolidColorBrush(Colors.Green); break;
                    default: shape.Background = new SolidColorBrush(Colors.White); break;
                }
                switch (comboBoxFore.SelectedIndex)
                {
                    case 0: shape.Foreground = new SolidColorBrush(Colors.Red); break;
                    case 1: shape.Foreground = new SolidColorBrush(Colors.Blue); break;
                    case 2: shape.Foreground = new SolidColorBrush(Colors.Green); break;
                    default: shape.Foreground = new SolidColorBrush(Colors.Black); break;
                }
                return shape;
            }
        }
    }
}
