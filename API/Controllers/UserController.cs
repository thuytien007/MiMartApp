using System.Collections.Generic;
using System.Threading.Tasks;
using Application.User;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseController
    {
        // [HttpGet]
        // [AllowAnonymous]
        // public async Task<ActionResult<List<User>>> List()
        // {
        //     return await Mediator.Send(new List.Query());
        // }
        //AllowAnonymous là cho phép user truy cập, k có thì k cho
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(Login.Query query)
        {
            return await Mediator.Send(query);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(Register.Command command)
        {
            return await Mediator.Send(command);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<User>> CurrentUser()
        {
            return await Mediator.Send(new CurrentUser.Query());
        }
    }
}