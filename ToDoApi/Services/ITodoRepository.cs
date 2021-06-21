using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Entities;

namespace ToDoApi.Services
{
    public interface ITodoRepository
    {       
        Task <IEnumerable<ToDo>> GetToDosAsync();
        Task<ToDo> GetToDoAsync(int id);
        void AddToDo(ToDo toDo);
        bool ToDoExists(int todoId);
        void DeleteToDo(ToDo toDo);
        void DeleteAllToDo();
        void UpdateToDo(ToDo toDo);
        Boolean SaveChanges();
    }
}

