using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project2.Services;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userServicec;
        private readonly ContextDB contextDB;
        public UsersController(ContextDB contextDB, IUserService userService)
        {
            this.contextDB = contextDB;
            userServicec = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await contextDB.Users.ToListAsync();
        }

        [HttpGet]
        [Route("getrollingret")]
        public ActionResult<IEnumerable<TimeSpan>> GetRollingRet()
        {
            return userServicec.GetLiveSpan();
        }
        [HttpGet]
        [Route("getrollingrett")]
        public ActionResult<string> GetRollning2()
        {
              return  userServicec.RollingUser7();
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            contextDB.Users.Add(user);
            contextDB.SaveChanges();
            return Ok(user);
        }

       

     
    }
}
