using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService:IUserService{
        private readonly ApplicationDbContext _appDbContext;
        public UserService(ApplicationDbContext applicationDbContext)
        {
            this._appDbContext = applicationDbContext;
        }
        public Task<User> GetUser()
        {
           return _appDbContext.Orders.Where(o=>o.CreatedAt.Year==2003&&o.Status==OrderStatus.Delivered).OrderByDescending(o=>o.Quantity).Select(o=>o.User).FirstAsync();
        } 

        public Task<List<User>> GetUsers()
        {
            return _appDbContext.Orders.Where(o=>o.CreatedAt.Year==2010&&o.Status==OrderStatus.Paid).Select(o=>o.User).ToListAsync();
        }
    }
}