using deneme.Server.Data.Models;
using deneme.Server.Services.Infrastruce;
using deneme.Shared.DTOs;
using deneme.Shared.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace deneme.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService UserService)
        {
            userService = UserService;
        }

        [HttpGet("Users")]
        public async Task<ServiceResponse<List<UserDTO>>> GetUsers()
        {
            return new ServiceResponse<List<UserDTO>>()
            {
                Value = await userService.GetUsers(),
                Message = "İlgili Kayıtlar getirildi"
            };
        }

        [HttpGet("UserById/{Id}")]
        public async Task<ServiceResponse<UserDTO>> GetUserById(int Id)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.GetUserById(Id),
                Message = "İlgili kayıt getirildi"
            };
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<ServiceResponse<bool>> DeleteUser(int Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await userService.DeleteUserById(Id),
                Message = "İlgili Kayıt silindi"
            };
        }

        [HttpPost("Create")]
        public async Task<ServiceResponse<UserDTO>> CreateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.CreateUser(User),
                Message = "İstenilen Kayıt Oluşturuldu"
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<UserDTO>> UpdateUser([FromBody] UserDTO User)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value = await userService.UpdateUser(User),
                Message = "İstenilen Kayıt Güncellendi"
            };
        }
    }
}
