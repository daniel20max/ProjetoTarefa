using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoTarefa.Models;
using ProjetoTarefa.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTarefa.Data
{
    public class ProjectTaskContext : IdentityDbContext<Client>
    {
       public ProjectTaskContext(DbContextOptions<ProjectTaskContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
    }
}
