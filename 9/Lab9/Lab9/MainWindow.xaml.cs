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
        ObservableCollection<GroupViewModel> groups;//коллекция
        IGroupService groupService;//созд объект для логики

        public MainWindow()
        {
            InitializeComponent();
            groupService = new GroupService("CoursesContext");//строка подключения
            groups = groupService.GetAll();//в groups получаем все данные студенты+группы
            cBoxGroup.DataContext = groups;//в cBoxGroup будет отражаться элемент groups 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var student = new StudentViewModel();
            student.DateOfBirth = new DateTime(1990, 01, 01);
            var dialog = new EditStudent(student);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                var group = (GroupViewModel)cBoxGroup.SelectedItem;
                group.Students.Add(student);
                groupService.AddStudentToGroup(group.GroupId, student);
                dialog.Close();
            }
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {//событие по нажатию мышью по надписи
            GroupViewModel groupViewModel = new GroupViewModel();
            groupViewModel.Commence = new DateTime(1990, 01, 01);
            EditGroup dialog = new EditGroup(groupViewModel);
            var result = dialog.ShowDialog();
            if (result == true)
                groupService.CreateGroup(groupViewModel);
            groups = groupService.GetAll();
            cBoxGroup.DataContext = groups;   
        }                              

        //Удаление будет происходить, если при выбранной в комбобоксе группе нажать Delete
        //При удалении группы каскадно удалятся все студенты
        private void CBoxGroup_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)//здесь проверяем что нажата именно клавиша Delete 
            {// удаление по клавише delete
                if (cBoxGroup.SelectedIndex > -1)//проверяем чтобы хоть что то было выделено (-1 ничего не выделено)
                {
                    groupService.DeleteGroup((cBoxGroup.SelectedItem as GroupViewModel).GroupId);//если все хорошо то выбираем группу
                    groups = groupService.GetAll();   //groupService передаем DeleteGroup
                    cBoxGroup.DataContext = groups;    //и передаем контексту 
                    cBoxGroup.SelectedIndex = 0;//база обновится в реалтайм без перезапуска при удалении
                }                              //перескочит на первую группу с индексом 0
            }

            if (e.Key == System.Windows.Input.Key.Insert)
            {// обновление по клавише Insert
                // не работает
                if (cBoxGroup.SelectedIndex > -1)
                {
                    GroupViewModel groupViewModel = cBoxGroup.SelectedItem as GroupViewModel;
                    EditGroup dialog = new EditGroup(groupViewModel);
                    var result = dialog.ShowDialog();
                    if (result == true)
                        groupService.UpdateGroup(groupViewModel);
                    groups = groupService.GetAll();
                    cBoxGroup.DataContext = groups;
                }
            }
        }

        private void ListBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)//проверяем нажата ли делит
            {// удаление по клавише delete
                if (listBox.SelectedIndex > -1)//проверяем чтобы хоть кто то был выделен
                {
                    int si = cBoxGroup.SelectedIndex;
                    GroupViewModel groupViewModel = cBoxGroup.SelectedItem as GroupViewModel;
                    StudentViewModel studentViewModel = listBox.SelectedItem as StudentViewModel;

                    groupService.RemoveStudentFromGroup(groupViewModel.GroupId, studentViewModel.StudentId);
                    groups = groupService.GetAll();     // для обновления окна
                    cBoxGroup.DataContext = groups;     // для обновления окна
                    cBoxGroup.SelectedIndex = si;        // для обновления окна
                }
            }

            if (e.Key == System.Windows.Input.Key.Insert)
            {// обновление по клавише Insert
                // не работает
                if (listBox.SelectedIndex > -1)
                {
                    StudentViewModel studentViewModel = listBox.SelectedItem as StudentViewModel;
                    var dialog = new EditStudent(studentViewModel);
                    var result = dialog.ShowDialog();
                    if (result == true)
                    {
                        groupService.UpdateStudent(studentViewModel);
                        dialog.Close();
                    }
                }
            }
        }
    }
}
