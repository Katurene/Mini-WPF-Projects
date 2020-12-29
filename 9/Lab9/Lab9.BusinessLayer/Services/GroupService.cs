using AutoMapper;
using Lab9.BusinessLayer.Interfaces;
using Lab9.BusinessLayer.Models;
using Lab9.DataLayer.Entities;
using Lab9.DataLayer.Interfaces;
using Lab9.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Lab9.BusinessLayer.Services
{
    public class GroupService : IGroupService//реализация IGroupService
    {
        IUnitOfWork dataBase;

        public GroupService(string name)
        {                                          //подключение к БД
            dataBase = new EntityUnitOfWork(name);//name-строка подключения
        }

        public void AddStudentToGroup(int groupId, StudentViewModel studentViewModel)
        {
            var group = dataBase.Groups.Get(groupId);

            // Конфигурировани AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StudentViewModel, Student>());//создается и настраивается объект конфиг
            var mapper = new Mapper(config);                     //студент преобразовывается в StudentViewModel

            // Отображение объекта StudentViewModel на объект Student     
            var student = mapper.Map<StudentViewModel, Student>(studentViewModel);

            // Определение цены для студента
            student.IndividualPrice = studentViewModel.HasDiscount == true
                                    ? group.BasePrice * (decimal)0.8
                                    : group.BasePrice;
            
            group.Students.Add(student);// Добавить студента к группе            
            dataBase.Save();// Сохранить изменения в БД
        }

        public void CreateGroup(GroupViewModel groupvm)//создается группа
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GroupViewModel, Group>());
            //маппер возьмет из группы,которая перейдет от окна (GroupViewModel) группу кот наз groupvm
            var mapper = new Mapper(config);//преобразует в обычную группу, которую можно сохранить в БД
            var group = mapper.Map<GroupViewModel, Group>(groupvm);
            dataBase.Groups.Create(group);//и добавит в БД эту группу
            dataBase.Save();
        }

        //При удалении группы каскадно удалятся все студенты
        public void DeleteGroup(int groupId)//выделенная группа удалится по нажатию клавиши Delete
        {
            dataBase.Groups.Delete(groupId);//удалит по идентификатору 
            dataBase.Save();//и сохранит изменения в БД
        }

        public GroupViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<GroupViewModel> GetAll()//GetAll получаем все группы со всеми студентами для цикла foreach
        {                 //а вкачестве результата будет ObservableCollection - коллекция хорошо отображается в окне

            // Конфигурировани AutoMapper            
            var config = new MapperConfiguration(cfg => {   //преобразование но в обратную сторону
                cfg.CreateMap<Student, StudentViewModel>();
                cfg.CreateMap<Group, GroupViewModel>();
            });
            var mapper = new Mapper(config);
            // Отображение List<Group> на ObservableCollection<GroupViewModel>   
            var groups = mapper.Map<IEnumerable<Group>, ObservableCollection<GroupViewModel>>(dataBase.Groups.GetAll());
            return groups;
        }

        public void RemoveStudentFromGroup(int groupId, int studentId)//удаление студента из группы
        {
            dataBase.Students.Delete(studentId);
            dataBase.Save();
        }

        public void UpdateGroup(GroupViewModel groupvm)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentViewModel, Student>();
                cfg.CreateMap<GroupViewModel, Group>();
            });
            var mapper = new Mapper(config);
            Group group = mapper.Map<GroupViewModel, Group>(groupvm);

            dataBase.Groups.Update(group);
            dataBase.Save();
        }

        public void UpdateStudent(StudentViewModel studentViewModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentViewModel, Student>();
            });
            var mapper = new Mapper(config);
            Student student = mapper.Map<StudentViewModel, Student>(studentViewModel);

            dataBase.Students.Update(student);
            dataBase.Save();
        }
    }
}

