using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService:IOrderService{
        private readonly ApplicationDbContext _appDbContext;
        public OrderService(ApplicationDbContext applicationDbContext)
        {
            this._appDbContext = applicationDbContext;
        }
        public Task<Order> GetOrder()
        {
            return _appDbContext.Orders.Where(o=>o.Quantity>1).OrderByDescending(o=>o.CreatedAt).FirstAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            return _appDbContext.Orders.Where(o=>o.User.Status==UserStatus.Active).OrderBy(o=>o.CreatedAt).ToListAsync();
        }
    }
}