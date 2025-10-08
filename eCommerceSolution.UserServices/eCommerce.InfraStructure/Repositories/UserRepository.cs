using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.InfraStructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.InfraStructure.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;
        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            //Generate teh UserId
            user.UserID = Guid.NewGuid();
            string query = "INSERT INTO Users (UserID,Email,PersonName,Gender,Password)" +
                " VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";
            var rowEffected=await _dbContext.DbConnection.ExecuteAsync(query,user);
            if (rowEffected > 0)
                return user;
            else
                return null;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            var parameters = new { Email = email, Password = password };
            string query = "SELECT * FROM Users WHERE Email=@Email AND Password=@Password";
            _dbContext.DbConnection.Open();
            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
            return user;
        }

        public async Task<ApplicationUser?> GetUserByUserID(Guid? userID)
        {
            var query = "SELECT * FROM Users WHERE UserID = @UserID";
            var parameters = new { UserID = userID };

            using var connection = _dbContext.DbConnection;
            return await connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
        }
    }
}
