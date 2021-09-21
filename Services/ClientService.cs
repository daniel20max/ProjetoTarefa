using ProjetoTarefa.Data;
using ProjetoTarefa.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTarefa.Services
{
    public class ClientService
    {
        ProjectTaskContext _context;
        public ClientService(ProjectTaskContext context)
        {
            _context = context;
        }
        public List<Client> GetAll() => _context.Clients.ToList();
        public Client GetClient(string email) => _context.Clients.FirstOrDefault(client => client.Email == email);
        public bool UpdateClient(Client client)
        {
            try
            {
                if (GetClient(client.Email) == null)
                {
                    return false;
                }
                _context.Clients.Update(client);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteClient(string email)
        {
            try
            {
                _context.Clients.Remove(GetClient(email));
                _context.SaveChanges();
                return true;
            }
            catch
            {

                throw;
            }
        }
    }
}
