using ProjetoTarefa.Data;
using ProjetoTarefa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTarefa.Services
{
    public class TaskListService
    {
        ProjectTaskContext _context;
        public TaskListService(ProjectTaskContext context)
        {
            _context = context;
        }

        public bool CreateTask(TaskList task)
        {
            try
            {

                var exists = _context.TaskLists.FirstOrDefault(t => t.Name == task.Name) != null;
                if (task == null || exists) return false;

                _context.TaskLists.Add(task);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public TaskList GetTask(int id) => _context.TaskLists.FirstOrDefault(t => t.Id == id);
        public bool DeleteTask(int id)
        {
            try
            {
                var exist = _context.TaskLists.FirstOrDefault(t => t.Id == id) != null;
                if (exist)
                {
                    _context.TaskLists.Remove(GetTask(id));
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateTask(TaskList task)
        {
            try
            {
                var exist = GetTask(task.Id);
                if (exist == null) return false;

                _context.TaskLists.Update(task);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public List<TaskList> GetTaskAll() => _context.TaskLists.ToList();
        public List<TaskList> GetTaskOrdebyPriority() => _context.TaskLists.OrderBy(task => task.Priority).ToList();
        public List<TaskList> GetTaskToday() => _context.TaskLists.OrderBy(task => task.Time == DateTime.Now).ToList();
        public List<TaskList> GetTaskDateTime(DateTime date) => _context.TaskLists.OrderBy(task => task.Time == date).ToList();

    }

}
