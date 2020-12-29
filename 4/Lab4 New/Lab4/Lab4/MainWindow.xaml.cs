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

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float[] xSmiles = new float[4];

        int[] speedSmiles = new int[4];

        Canvas[] canvases = new Canvas[4];        

        Race.UserControlSmile[] smiles = new Race.UserControlSmile[4];

        Race.UserControlFinish[] finish = new Race.UserControlFinish[4];

        Race.UserControlPosition[] positions = new Race.UserControlPosition[4];

        DispatcherTimer timer, timerUpdateSpeed;

        public MainWindow()
        {
            InitializeComponent();

            this.ResizeMode = ResizeMode.NoResize;  

            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                speedSmiles[i] = random.Next(20, 50);
                smiles[i] = new Race.UserControlSmile(speedSmiles[i], 0);

                canvases[i] = new Canvas();
                Grid.SetRow(canvases[i], i);
                grid.Children.Add(canvases[i]);

                finish[i] = new Race.UserControlFinish();

                positions[i] = new Race.UserControlPosition();
            }

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(10000);
            timer.Start();

            timerUpdateSpeed = new DispatcherTimer();
            timerUpdateSpeed.Tick += new EventHandler(timer_Tick_Update_Speed);
            timerUpdateSpeed.Interval = new TimeSpan(0, 0, 2);
            timerUpdateSpeed.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (xSmiles[i] == 2000)   
                    continue;
                canvases[i].Children.Clear();           
                canvases[i].Children.Add(finish[i]);    
                Canvas.SetRight(finish[i], 0);          
                Canvas.SetLeft(smiles[i], (int)xSmiles[i]); 
                canvases[i].Children.Add(smiles[i]);   

                int k = 0;  
                for (int j = 0; j < 4; j++)
                    if (xSmiles[i] <= xSmiles[j]) k++;
                if (xSmiles[i] < 1100)  
                {
                    smiles[i].UpdatePosition(k);  
                    xSmiles[i] += (float)speedSmiles[i] / 50.0f;   
                }
                else
                {   
                    positions[i].SetPosition(k);           
                    canvases[i].Children.Add(positions[i]);
                    Canvas.SetLeft(positions[i], 50);

                    xSmiles[i] = 2000;  
                }
            }
        }

        private void timer_Tick_Update_Speed(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                if (xSmiles[i] < 1100)  
                {
                    speedSmiles[i] = random.Next(20, 80);  
                    smiles[i].UpdateSpeed(speedSmiles[i]);
                }
            }
        }
    }
}
