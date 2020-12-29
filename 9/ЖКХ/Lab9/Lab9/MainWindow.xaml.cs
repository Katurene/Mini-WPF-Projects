using Lab9.BusinessLayer.Interfaces;
using Lab9.BusinessLayer.Models;
using Lab9.BusinessLayer.Services;
using Lab9.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lab9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<WorkViewModel> works;
        IWorkService workService;

        public MainWindow()
        {
            InitializeComponent();
            workService = new WorkService("CoursesContext1");
            works = workService.GetAll();
            cBoxWork.DataContext = works;
        }

        private void ButtonAddWork_Click(object sender, RoutedEventArgs e)
        {
            WorkViewModel workViewModel = new WorkViewModel();
            workViewModel.Begin = new DateTime(1990, 01, 01);
            EditWork dialog = new EditWork(workViewModel);
            var result = dialog.ShowDialog();
            if (result == true)
                workService.CreateWork(workViewModel);
            works = workService.GetAll();
            cBoxWork.DataContext = works;
        }

        private void ButtonAddWorker_Click(object sender, RoutedEventArgs e)
        {
            var worker = new WorkerViewModel();
            worker.DateOfBirth = new DateTime(1990, 01, 01);
            var dialog = new EditWorker(worker);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                var work = (WorkViewModel)cBoxWork.SelectedItem;
                work.Workers.Add(worker);
                workService.AddWorkerToWork(work.WorkId, worker);
                dialog.Close();
            }
        }

        private void cBoxWork_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)
            {// удаление по клавише delete
                if (cBoxWork.SelectedIndex > -1)
                {
                    workService.DeleteWork((cBoxWork.SelectedItem as WorkViewModel).WorkId);
                    works = workService.GetAll();
                    cBoxWork.DataContext = works;
                    cBoxWork.SelectedIndex = 0;
                }
            }
            if (e.Key == System.Windows.Input.Key.Insert)
            {// обновление по клавише Insert                
                if (cBoxWork.SelectedIndex > -1)
                {
                    WorkViewModel workViewModel = cBoxWork.SelectedItem as WorkViewModel;
                    EditWork dialog = new EditWork(workViewModel);
                    var result = dialog.ShowDialog();
                    if (result == true)
                        workService.UpdateWork(workViewModel);
                    works = workService.GetAll();
                    cBoxWork.DataContext = works;
                }
            }
        }

        private void ListBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)
            {// удаление по клавише delete
                if (listBox.SelectedIndex > -1)
                {
                    int si = cBoxWork.SelectedIndex;
                    WorkViewModel workViewModel = cBoxWork.SelectedItem as WorkViewModel;
                    WorkerViewModel workerViewModel = listBox.SelectedItem as WorkerViewModel;

                    workService.RemoveWorkerFromWork(workViewModel.WorkId, workerViewModel.WorkerId);
                    works = workService.GetAll();     
                    cBoxWork.DataContext = works;     
                    cBoxWork.SelectedIndex = si;  
                }
            }
            if (e.Key == System.Windows.Input.Key.Insert)
            {// обновление по клавише Insert               
                if (listBox.SelectedIndex > -1)
                {
                    WorkerViewModel workerViewModel = listBox.SelectedItem as WorkerViewModel;
                    var dialog = new EditWorker(workerViewModel);
                    var result = dialog.ShowDialog();
                    if (result == true)
                    {
                        workService.UpdateWorker(workerViewModel);
                        dialog.Close();
                    }
                }
            }
        }
    }
}

