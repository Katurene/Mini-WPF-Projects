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
using System.Windows.Threading;

//для связи с проектом Hippodrome надо подключить в ССЫЛКИ->добавить ссылку->Проекты->Hippodrome

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float[] xHorses = new float[3];//координата лошади на канвас

        int[] speedHorses = new int[3];//скорость лошади

        Canvas[] canvases = new Canvas[3];//создадим canvas программно

        Hippodrome.UserControl_Horse[] horses = new Hippodrome.UserControl_Horse[3];//создаем 3 лошади
        
        Hippodrome.UserControlFinish[] finish = new Hippodrome.UserControlFinish[3];//3 финиша

        Hippodrome.UserControlPosition[] positions = new Hippodrome.UserControlPosition[3];

        //DispatcherTimer timer;//таймер кот выз код в кот все время обновл позиц лошад
        DispatcherTimer timer, timerUpdateSpeed;//доб еще один таймер для случ изменен скор лошадок

        public MainWindow()
        {
            InitializeComponent();

            this.ResizeMode = ResizeMode.NoResize;  // запрещаем менять размер окна

            Random random = new Random();
            for (int i = 0; i < 3; i++)//три скорости
            {
                speedHorses[i] = random.Next(20, 50);//скорости случайные в диапазоне от 20 до 50
                horses[i] = new Hippodrome.UserControl_Horse(speedHorses[i], 0);//создаем лошадей со случайными скоростями
                                                                                //i-скорость 0-позиция
                canvases[i] = new Canvas();//програмное создание канваса
                Grid.SetRow(canvases[i], i);
                grid.Children.Add(canvases[i]);

                finish[i] = new Hippodrome.UserControlFinish();//прогр созд финишей

                positions[i] = new Hippodrome.UserControlPosition();//позиции лошадей
            }

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(10000);//интервал в тактах
            timer.Start();

            timerUpdateSpeed = new DispatcherTimer();//для апдейта скорости
            timerUpdateSpeed.Tick += new EventHandler(timer_Tick_Update_Speed);
            timerUpdateSpeed.Interval = new TimeSpan(0, 0, 2);//время срабат чч,мм,сс -2сек
            timerUpdateSpeed.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                if (xHorses[i] == 2000)    // эта лошадка уже финишировала - ее не обновляем
                    continue;
                canvases[i].Children.Clear();           // чистим дорожку
                canvases[i].Children.Add(finish[i]);    // установка финиша
                Canvas.SetRight(finish[i], 0);          // финиш справа
                Canvas.SetLeft(horses[i], (int)xHorses[i]); // лошадка слева + xHorses[i]
                canvases[i].Children.Add(horses[i]);    // установка лошадки

                int k = 0;  // определим позицию лошадки (текущее место в забеге)
                for (int j = 0; j < 3; j++)
                    if (xHorses[i] <= xHorses[j]) k++;
                if (xHorses[i] < 1100)  // лошадка еще не финишировала
                {
                    horses[i].UpdatePosition(k);    // обновим ее позицию
                    xHorses[i] += (float)speedHorses[i] / 50.0f;    // пересчет координаты
                }
                else
                {   // лошадка на финише в первый раз
                    positions[i].SetPosition(k);            // заполнение и отображение табло
                    canvases[i].Children.Add(positions[i]);
                    Canvas.SetLeft(positions[i], 50);

                    xHorses[i] = 2000;  // признак - лошадка уже финишировала

                    //Canvas_Horse_1.Children.Clear();//чистим канвас
                    //Canvas_Horse_2.Children.Clear();
                    //Canvas_Horse_3.Children.Clear();
                    //for (int i = 0; i < 3; i++)
                    //{
                    //    if (xHorses[i] == 2000)    // эта лошадка уже финишировала - ее не обновляем
                    //        continue;

                    //    canvases[i].Children.Clear();//чистим канвас

                    //    canvases[i].Children.Add(finish[i]);    // установка финиша
                    //    Canvas.SetRight(finish[i], 0);          // финиш справа

                    //    Canvas.SetLeft(horses[i], (int)xHorses[i]);// лошадка слева + xHorses[i]
                    //    xHorses[i] += (float)speedHorses[i] / 50.0f;//смещаем лошадей на 50.0f за единицу времени
                    //    canvases[i].Children.Add(horses[i]);//добавим лошадку на канвас

                    //    canvases[i].Children.Add(finish[i]);//отображение финишей
                    //    Canvas.SetRight(finish[i], 0);//положили в канвас и прижали вправо

                    //    int k = 0;  // определим позицию лошадки
                    //    for (int j = 0; j < 3; j++)//позиция лошадки обновляется с каждым тиком первого таймера
                    //        if (xHorses[i] <= xHorses[j]) k++;
                    //    horses[i].UpdatePosition(k);

                }

                //Canvas_Horse_1.Children.Add(horses[0]);//перерисовываем заново по новым координатам
                //Canvas_Horse_2.Children.Add(horses[1]);
                //Canvas_Horse_3.Children.Add(horses[2]);
            }
        }

        private void timer_Tick_Update_Speed(object sender, EventArgs e)//новый таймер для апдейта скорости
        {
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                if (xHorses[i] < 1100)  // если лошадка еще не финишировала
                {
                    speedHorses[i] = random.Next(20, 80);   // обновляем ее скорость
                    horses[i].UpdateSpeed(speedHorses[i]);
                }
            }
        }
    }
}
