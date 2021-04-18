using API.Entities;
using System.Collections.Generic;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
           var user= _context.Users.ToListAsync(); 
           return await user;
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
           return await _context.Users.FindAsync(id); 
        
        }

         [HttpGet("c/{UserName}")]
         public ActionResult<AppUser> GetUserByName(string UserName)
         {
            return _context.Users.FirstOrDefault(a => a.UserName==UserName);
        // //FirstOrDefault(a => a.LastName == "Shakespeare");
         }

    }
}