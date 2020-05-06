using Carousel.BusinessLogicData.Interfaces;
using Carousel.DataAcess.Interfaces;
using Carousel.DataAcess.Repositories;
using Carousel.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carousel.BusinessLogicData.BusinessLogic
{
    public class UserBal :IBusinessLogic
    {
        private readonly IUserRepository _dal;
        
        public UserBal(IUserRepository Dal)
        {
            _dal = Dal;
        }
        public List<UserModel> InsertSavePage(UserModel saveData)
        {

            return _dal.InsertUsers(saveData);
        }
        public List<UserModel> GetUserData()
        {
            return _dal.GetUserPageData();
        }
        public string UpdateUser(int userId, UserModel value)
        {
            return _dal.UpdateUsers(userId, value);
        }
        public string SoftDeleteUser(int userId, int isDeleted)
        {
            return _dal.SoftDeleteUser(userId, isDeleted);
        }
    }
}