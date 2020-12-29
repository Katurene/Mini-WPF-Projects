using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Lab6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Integral integral;//здесь ссылка

        BackgroundWorker backgroundWorker;//объявляем ссылку класс-объект

        public MainWindow()
        {
            InitializeComponent();

            backgroundWorker = (BackgroundWorker)this.Resources["worker"];//проинициализируем 
        }

        private void buttonParams_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();//создаем окно
            if (window1.ShowDialog() != true) return;//оно будет вызываться как диалоговое
            integral = window1.integral;//тот интеграл который окно нам передаст запомним в свой интеграл
            //MessageBox.Show($"{integral.A} {integral.B} {integral.N} ");
        }

        private void ButtonD_Click(object sender, RoutedEventArgs e)
        {           
            textBlock.Text = "";//чистим textBlock
            Thread thread = new Thread(Calculate);//для Calculate созд отдел поток чтоб работало параллельн выполнение
            thread.Start();
        }

        private void ButtonW_Click(object sender, RoutedEventArgs e)
        {
        //метод делает кнопки неактивными пока работают потоки и асинхронно запускает в фоновом режиме backgroundWorker            
            buttonD.IsEnabled = false;
            buttonW.IsEnabled = false;
            backgroundWorker.RunWorkerAsync();
        }

        private void Calculate()//метод вычисления интеграла
        {
            if (integral == null) return;
            int n = integral.N;
            double h = (integral.B - integral.A) / n;

            //Добавим отображение в Progressbar. Поскольку максимальное значение в ProgressBar по 
            //умолчанию 100, будем добавлять прогресс 100 раз
            var step = Math.Round((double)(n) / 100);//шаг для прогрессбара

            double S = 0;

            for (int i = 0; i <= n; i++)
            {
                double x = integral.A + h * i;
                S += fx(x) * h;

                //параллельный поток который будет наращивать Progressbar
                //наращивать будет только в том случае если шаг будет кратен шагу вычисления интеграла
                if (i % step == 0)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        new Action(() => pBar.Value = i / step));
                }

                //Dispatcher -отдельный класс которому передается метод кот будет выполняться в параллельном потоке
                //2 параметра - приоритет и метод, кот должен быть как стандартный делегат Action
                Dispatcher.BeginInvoke(DispatcherPriority.Normal,
     new Action(() => textBlock.Text = String.Format($"x = {x:0.00} S = {S:0.00000}\n")));//метод помещающий в текстовый блок строку

                Thread.Sleep(100);//притормозим выполнение
            }
            MessageBox.Show($"S = {S:0.00000}");
        }

        //private double fx(double x)//метод который считает по функции
        //{
        //    return Math.Pow(x, 3);
        //}

        private double fx(double x)//метод который считает по функции
        {
            return Math.Sqrt(x);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)//метод соответствует Calculate
        {
            if (integral == null) return;
            int n = integral.N;
            double h = (integral.B - integral.A) / n;
            var step = Math.Round((double)(n) / 100);
            double S = 0;

            for (int i = 0; i <= n; i++)
            {
                double x = integral.A + h * i;
                S += fx(x) * h;

                if (i % step == 0)
                {
                    //отличие - прогресбар будет работать в этом фоновом потоке
                    if (backgroundWorker != null && backgroundWorker.WorkerReportsProgress)
                        backgroundWorker.ReportProgress((int)(i / step));
                }

                Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(() => textBlock.Text = String.Format($"x = {x:0.00} S = {S:0.00000}\n")));

                Thread.Sleep(100);
            }
            MessageBox.Show($"S = {S:0.00000}");
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {//меняем значение прогрессбара
            pBar.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //пока работает BackgroundWorker делаем кнопки неактивными
            buttonD.IsEnabled = true;
            buttonW.IsEnabled = true;
        }
    }
}
