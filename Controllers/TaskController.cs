using Microsoft.AspNetCore.Mvc;
using ProjetoTarefa.Models;
using ProjetoTarefa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTarefa.Controllers
{
    [ApiController]
    [Route("api/v1/TaskController")]
    public class TaskController : Controller
    {
        TaskListService _serviceTask;
        public TaskController(TaskListService serviceTask)
        {
            _serviceTask = serviceTask;
        }
        [HttpGet]
        [Route("GetTaskByID")]
        public IActionResult GetTask(int id) => Ok(_serviceTask.GetTask(id));
        [HttpGet]
        [Route("GetAllTask")]
        public IActionResult GetTaskAll() => Ok(_serviceTask.GetTaskAll());
        [HttpGet]
        [Route("GetTaskOrderByPriority")]
        public IActionResult GetTaskPriority() => Ok(_serviceTask.GetTaskOrdebyPriority());
        [HttpGet]
        [Route("GetTaskOrderByDateTime")]
        public IActionResult GetTaskDateTime(DateTime date) => Ok(_serviceTask.GetTaskDateTime(date));
        [HttpGet]
        [Route("GetTaskToday")]
        public IActionResult GetTaskToday() => Ok(_serviceTask.GetTaskToday());
        [HttpPost]
        [Route("CreateTask")]
        public IActionResult CreateTask(TaskList task) => Ok(_serviceTask.CreateTask(task));
        [HttpDelete]
        [Route("DeleteTask")]
        public IActionResult DeleteTask(int id) => Ok(_serviceTask.DeleteTask(id));
        [HttpPut]
        [Route("UpdateTask")]
        public IActionResult UpdateTask(TaskList task) => Ok(_serviceTask.UpdateTask(task));
        
    }
}
