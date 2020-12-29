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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Shape shape;//сдесь просто ссылка

        public MainWindow()
        {
            InitializeComponent();

            //настраиваем команды
            CommandBinding commandBindingHelp = new CommandBinding(); // создаем привязку команды
            commandBindingHelp.Command = ApplicationCommands.Help; // устанавливаем команду
            commandBindingHelp.Executed += help;
            menuItemHelp.CommandBindings.Add(commandBindingHelp);
            buttonHelp.CommandBindings.Add(commandBindingHelp);

            CommandBinding commandBindingClose = new CommandBinding(); // создаем привязку команды
            commandBindingClose.Command = ApplicationCommands.Close; // устанавливаем команду
            commandBindingClose.Executed += close;
            menuItemExit.CommandBindings.Add(commandBindingClose);
            buttonExit.CommandBindings.Add(commandBindingClose);

            CommandBinding commandBindingLoad = new CommandBinding(); // создаем привязку команды
            commandBindingLoad.Command = ApplicationCommands.Open; // устанавливаем команду
            commandBindingLoad.Executed += load;
            menuItemLoad.CommandBindings.Add(commandBindingLoad);
            buttonLoad.CommandBindings.Add(commandBindingLoad);

            CommandBinding commandBindingSave = new CommandBinding(); // создаем привязку команды
            commandBindingSave.Command = ApplicationCommands.Save; // устанавливаем команду
            commandBindingSave.Executed += save;
            commandBindingSave.CanExecute += save_CanExecute;//проверит доступна ли команда
            menuItemSave.CommandBindings.Add(commandBindingSave);
            buttonSave.CommandBindings.Add(commandBindingSave);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowShape windowShape = new WindowShape();//появляется окно модальное кот пока не закроешь не перейдешь в главное
            if (windowShape.ShowDialog() == true)//вызов второго окна ShowDialog() диалоговое окно
            //MessageBox.Show("Гыы");// отладочный messagebox
            {
                shape = windowShape.NewShape;//NewShape- к-л свойство кот вернет диалогов окно
                //MessageBox.Show(shape.ToString());// отладочный messagebox номера цвета выводит
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)//щелчек по канвасу вызыв обработчик движения мыши
        {//когда водим мышью по гл окну координаты прописыв в статусной строке
            textBlockCursorPosition.Text = e.GetPosition(this).ToString();//GetPosition возвращ координаты мыши X Y            
        }

        //private void canvas_MouseDown(object sender, MouseButtonEventArgs e)//рисуем объект(треугольник) по нажатию
        //{
        //    if (shape == null) return; // если объект пустой, сразу уйдем
        //    Polygon t = new Polygon();//если объект есть то создаем треугольник Полигон-набор точек по кот рисуем фигуру
        //    t.Points = new PointCollection();//в полигоне создаем коллекцию точек
        //    Point point1 = e.GetPosition(this);//точка по кот щелкнули мышью
        //    shape.X = point1.X;//заполн перв точку
        //    shape.Y = point1.Y;
        //    t.Points.Add(point1);//первая точка Та по кот щелкнули
        //    t.Points.Add(new Point(shape.X + 100, shape.Y));//вторая точка-берем Х и смещаем на 100 а Y ост без измен
        //    t.Points.Add(new Point(shape.X, shape.Y + 100));//третья смещ на 100 вниз
        //    t.Fill = shape.Background;//заполнение 
        //    t.Stroke = shape.Foreground;//обрамление
        //    t.StrokeThickness = shape.Width;//тощина линии
        //    canvas.Children.Add(t);//добавляем к канвасу заполненную фигуру
        //}

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)//рисуем объект по нажатию
        {
            if (shape == null) return; // если объект пустой, сразу уйдем
            Polygon t = new Polygon();//если объект есть то создаем треугольник Полигон-набор точек по кот рисуем фигуру
            t.Points = new PointCollection();//в полигоне создаем коллекцию точек
            Point point1 = e.GetPosition(this);//точка по кот щелкнули мышью
            shape.X = point1.X;//заполн перв точку
            shape.Y = point1.Y;

            //t.Points.Add(point1);//первая точка Та по кот щелкнули           
            t.Points.Add(new Point(shape.X + 80, shape.Y));
            t.Points.Add(new Point(shape.X + 26, shape.Y + 18));
            t.Points.Add(new Point(shape.X + 26, shape.Y + 80));
            t.Points.Add(new Point(shape.X - 10, shape.Y + 30));
            t.Points.Add(new Point(shape.X - 68, shape.Y + 50));
            t.Points.Add(new Point(shape.X - 32, shape.Y));
            t.Points.Add(new Point(shape.X - 68, shape.Y - 50));
            t.Points.Add(new Point(shape.X - 10, shape.Y - 30));
            t.Points.Add(new Point(shape.X + 26, shape.Y - 80));
            t.Points.Add(new Point(shape.X + 26, shape.Y - 18));

            t.Fill = shape.Background;//заполнение 
            t.Stroke = shape.Foreground;//обрамление
            t.StrokeThickness = shape.Width;//тощина линии
            canvas.Children.Add(t);//добавляем к канвасу заполненную фигуру
        }

        private void help(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Справка по приложению");
        }

        private void close(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void load(object sender, ExecutedRoutedEventArgs e)
        {
            shape = Shape.LoadFromFile();//load создает новый объект и помещает его в shape
        }

        private void save(object sender, ExecutedRoutedEventArgs e)
        {
            shape.SaveToFile();//save сохранит текущий объект в файл
        }

        //Требуется, чтобы команда Save была доступна только, если фигура уже задана. 
        //Настроим событие команды CanExecute
        private void save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = shape != null;
        }

    }
}
