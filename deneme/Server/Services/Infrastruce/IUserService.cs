using deneme.Shared.DTOs;

namespace deneme.Server.Services.Infrastruce
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserById(int Id);
        public Task<List<UserDTO>> GetUsers();
        public Task<UserDTO> CreateUser(UserDTO User);
        public Task<UserDTO> UpdateUser(UserDTO User);
        public Task<bool> DeleteUserById(int Id);
    }
}
