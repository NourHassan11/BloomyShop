 

using Microsoft.EntityFrameworkCore;
using Project.BLL.Interfaces;
using Project.DAL.Entities;
using Project.DAL.Entities.Data;

namespace Project.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly BloomyShopDbContext _context;

        public AdminService(BloomyShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Admin>> GetAllAsync()
        {
            return await _context.Admins
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Admin?> GetByIdAsync(int id)
        {
            return await _context.Admins
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AdminID == id);
        }

        public async Task AddAsync(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Admin admin)
        {
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.AdminID == id);

            if (admin != null)
            {
                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<EventRequest>> GetEventRequestsAsync()
        {
            return await _context.EventRequests
                .Include(e => e.Customer)
                .Include(e => e.Occasion)
                .Include(e => e.Admin)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<EventRequest?> GetEventRequestByIdAsync(int id)
        {
            return await _context.EventRequests
                .Include(e => e.Customer)
                .Include(e => e.Occasion)
                .Include(e => e.Admin)
                .FirstOrDefaultAsync(e => e.EventRequestID == id);
        }

        public async Task ReviewEventRequestAsync(
            int eventRequestId,
            int adminId,
            string? adminResponse)
        {
            var eventRequest = await _context.EventRequests
                .FirstOrDefaultAsync(e =>
                    e.EventRequestID == eventRequestId);

            if (eventRequest == null)
                return;

            eventRequest.AdminID = adminId;
            eventRequest.AdminResponse = adminResponse;

            await _context.SaveChangesAsync();
        }
    }
}
