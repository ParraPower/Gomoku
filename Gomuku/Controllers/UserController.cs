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
    [Route("[controller]")]
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
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticateRequest)
        {
            try
            {
                return await _userService.Authenticate(authenticateRequest);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }

        [HttpPost("register")]
        public Task<User> Register(UserCreate userCreate)
        {
            try
            {
                return _userService.Register(userCreate);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<User> GetUser([FromRoute]long id)
        {
            try
            {
                return await _userService.GetUser(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }
    }
}
