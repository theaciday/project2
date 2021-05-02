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
        private readonly IUserService userService;
        private readonly ContextDB contextDB;
        public UsersController(ContextDB contextDB)
        {
            this.contextDB = contextDB;       
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await contextDB.Users.ToListAsync();
        }

        [HttpGet]
        [Route("api/getrollingret")]
        public ActionResult<IEnumerable<TimeSpan>> GetRollingRet() 
        {
            userService.RollingUser7();
            return userService.GetLiveSpan();
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            contextDB.Users.Add(user);
            contextDB.SaveChanges();
            
            return Ok(user);

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
