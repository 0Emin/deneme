using AutoMapper;
using AutoMapper.QueryableExtensions;
using deneme.Server.Data.Context;
using deneme.Server.Services.Infrastruce;
using deneme.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace deneme.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly SmartContext context;

        public UserService(IMapper Mapper, SmartContext Context)
        {
            mapper = Mapper;
            context = Context;
        }

        public async Task<UserDTO> CreateUser(UserDTO User)
        {
            var dbUser = await context.Users.Where(i => i.Id == User.Id).FirstOrDefaultAsync();

            if (dbUser != null)
            {
                throw new Exception("Kullanıcı Mevcut");
            }

            dbUser = mapper.Map<Data.Models.User>(User);

            await context.Users.AddAsync(dbUser);
            int result = await context.SaveChangesAsync();

            return mapper.Map<UserDTO>(User);
        }

        public async Task<bool> DeleteUserById(int Id)
        {
            var dbUser = await context.Users.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbUser == null)
            {
                throw new Exception("Kullanıcı Bulunamadı");
            }

            context.Users.Remove(dbUser);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<UserDTO> GetUserById(int Id)
        {
            return await context.Users
                .Where(i => i.Id == Id)
                .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<UserDTO> UpdateUser(UserDTO User)
        {
            var dbUser = await context.Users.Where(i => i.Id == User.Id).FirstOrDefaultAsync();

            if (dbUser == null)
            {
                throw new Exception("İlgili Kayıt Bulunamadı");
            }

            dbUser = mapper.Map<Data.Models.User>(User);

            mapper.Map(User, dbUser);

            int result = await context.SaveChangesAsync();

            return mapper.Map<UserDTO>(User);
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await context.Users
                 .Where(i => i.IsActive == 1)
                 .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                 .ToListAsync();
        }
    }
}
