using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Entities;

namespace Project.BLL.Interfaces
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAllAsync();

        Task<Admin?> GetByIdAsync(int id);

        Task AddAsync(Admin admin);

        Task UpdateAsync(Admin admin);

        Task DeleteAsync(int id);

        Task<List<EventRequest>> GetEventRequestsAsync();

        Task<EventRequest?> GetEventRequestByIdAsync(int id);

        Task ReviewEventRequestAsync(
            int eventRequestId,
            int adminId,
            string? adminResponse);
    }
}

