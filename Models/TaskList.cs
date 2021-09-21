using ProjetoTarefa.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTarefa.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public DateTime CreateTime { get; set; }
        public bool Priority { get; set; }
        public bool TaskDone { get; set; }
        public string UserId { get; set; }
        public Client User { get; set; }

    }
}
