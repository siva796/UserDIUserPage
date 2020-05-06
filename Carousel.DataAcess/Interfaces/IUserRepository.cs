using Carousel.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carousel.DataAcess.Interfaces
{
 public interface IUserRepository
    {
        List<UserModel> GetUserPageData();
        List<UserModel> InsertUsers(UserModel users);
        string UpdateUsers(int userId, UserModel data);

        string SoftDeleteUser(int userId, int isDeleted);

    }
}
