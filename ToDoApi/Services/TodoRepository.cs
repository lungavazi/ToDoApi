using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Context;
using ToDoApi.Entities;

namespace ToDoApi.Services
{
    public class TodoRepository : ITodoRepository
    {
        private ToDoContext _context;

        public TodoRepository(ToDoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddToDo(ToDo toDo)
        {
            if(toDo == null)
            {
                throw new ArgumentNullException(nameof(toDo));
            }
            _context.Add(toDo);
        }

        public void DeleteAllToDo()
        {
            //_context.ToDos.Remove();
        }

        public void DeleteToDo(ToDo toDo)
        {
            _context.ToDos.Remove(toDo);
        }

        public void DeleteToDo(int toDoId)
        {
            throw new NotImplementedException();
        }

        public async Task<ToDo> GetToDoAsync(int id)
        {
            return await  _context.ToDos.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ToDo>> GetToDosAsync()
        {
            return await _context.ToDos.ToListAsync();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool ToDoExists(int todoId)
        {
            return _context.ToDos.Any(c => c.Id == todoId);
        }

        public void UpdateToDo(ToDo toDo)
        {
            _context.ToDos.Update(toDo);
        }
    }
}
