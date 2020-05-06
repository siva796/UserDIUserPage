using Carousel.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carousel.BusinessLogicData.Interfaces
{
    public interface IBusinessLogic
    {
        List<UserModel> InsertSavePage(UserModel saveData);

        List<UserModel> GetUserData();
        string UpdateUser(int userId, UserModel value);
        string SoftDeleteUser(int userId, int isDeleted);
        
    }
}
