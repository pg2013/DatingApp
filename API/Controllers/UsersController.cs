using API.Entities;
using System.Collections.Generic;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
           var user= _context.Users.ToListAsync(); 
           return await user;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
           return await _context.Users.FindAsync(id); 
        
        }

        // [HttpGet("{UserName}")]
        // public ActionResult<AppUser> GetUser(string UserName)
        // {
        //    return  _context.Users.FirstOrDefault(a => a.UserName==UserName);
        // //FirstOrDefault(a => a.LastName == "Shakespeare");
        // }

    }
}