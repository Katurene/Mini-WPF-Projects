using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab9.BusinessLayer.Models;

namespace Lab9.BusinessLayer.Interfaces
{ //Логика на уровне бизнеса. Запись добавляется не просто к таблице студента, а в группу. 
  //Т.к без группы студент быть не может, и удаляется только из группы.              
    public interface IGroupService
    {
        ObservableCollection<GroupViewModel> GetAll();
        GroupViewModel Get(int id);
        void AddStudentToGroup(int groupId, StudentViewModel student);//студент создается вместе с группой
        void RemoveStudentFromGroup(int groupId, int studentId);
        void CreateGroup(GroupViewModel group);
        void DeleteGroup(int groupId);
        void UpdateGroup(GroupViewModel group);
        void UpdateStudent(StudentViewModel studentViewModel);
    }
}
