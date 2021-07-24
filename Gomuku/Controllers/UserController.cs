using Gomoku.Logic.Interfaces;
using Gomoku.Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tofi.Framework.Logging;

namespace Gomoku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger logger = LogManager.GetLogger<UserController>();

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            return null;
        }

        [HttpGet("{id}")]
        public Task<User> GetUser([FromQuery] long id)
        {
            try
            {
                return _userService.GetUser(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }
    }
}
