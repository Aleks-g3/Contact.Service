using AutoMapper;
using Contact.Service.API.Entities;
using Contact.Service.Core.Models;
using Contact.Service.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromBody]RegisterUserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);
            var userId = await userService.RegisterAsync(user, userDTO.Password);
            return Ok(userId);
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody]LoginUserDTO userDTO)
        {
            var user = mapper.Map<LoginUser>(userDTO);
            var result = await userService.LoginAsync(user);
            return Ok(result);
        }
    }
}
