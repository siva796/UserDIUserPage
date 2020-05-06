using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carousel.Contracts.Interfaces;
using Carousel.DataAcess.Interfaces;
using Carousel.Models.Models;



namespace Carousel.DataAcess.Repositories
{
  public  class UserRepository  : BaseRepository, IUserRepository
    {
        public List<UserModel> GetUserPageData()
        {
            List<UserModel> GetAllUser = new List<UserModel>();
            using (var dataset = GetDataset(ProcedureNames.GetUserData))
            {
                var UsersTable = dataset.Tables[0];
                var UsersTableDetail = UsersTable.AsEnumerable();

                foreach (var UsersRow in UsersTableDetail)
                {
                    GetAllUser.Add(PopulateData<UserModel>(UsersRow));
                }
            }
            return GetAllUser;
        }
        public List<UserModel> InsertUsers(UserModel users)
        {
            List<UserModel> usersInsert = new List<UserModel>();
            using (var dataset = GetDataset(ProcedureNames.insertData,
                    new SqlParameter("@userName", users.userName),
                    new SqlParameter("@email", users.email),
                    new SqlParameter("@isDeleted", users.isDeleted)))
               
            {
                try
                {
                    var usersTable = dataset.Tables[0];
                    var usersTableDetail = usersTable.AsEnumerable();

                    foreach (var usersRow in usersTableDetail)
                    {
                        usersInsert.Add(PopulateData<UserModel>(usersRow));
                    }

                }
                catch(Exception io)
                {
                    Console.WriteLine(io);
                }
               
            }
            return usersInsert;
        }


        public string UpdateUsers (int userId, UserModel data)
        {
            var status = GetValue<string>(ProcedureNames.updateData,
            new SqlParameter("@userId", userId),
            new SqlParameter("@userName", data.userName),
            new SqlParameter("@email", data.email)     
            ); 
            return status;
        }

        public string SoftDelete(int userId, int isDeleted)
        {
            var status = GetValue<string>(ProcedureNames.SoftDelete,
            new SqlParameter("@userId", userId),
            new SqlParameter("@isDeleted", isDeleted)
            
            );
            return status;
        }


    

    }
}


