using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Add(TodoItem item)
        {
            _context.Todos.Add(item);
            _context.SaveChanges();

        }

        public TodoItem Find(string key)
        {
            return _context.Todos.FirstOrDefault(x => x.Key == key);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.Todos;
        }

        public TodoItem Remove(string key)
        {
            var item = _context.Todos.FirstOrDefault(x => x.Key == key);

            if(item != null)
            {
                _context.Todos.Remove(item);
                _context.SaveChanges();
            }

            return item;
        }

        public void Update(TodoItem item)
        {
            var todoitem = _context.Todos.Attach(item);
            todoitem.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
