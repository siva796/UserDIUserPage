using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carousel.DataAcess
{
    class ProcedureNames
    {
        public const string GetUserData = "[dbo].[GetUsersData]";
        public const string insertData = "[dbo].[SpInsert]";
        public const string updateData = "[dbo].[spUpdate]";
        public const string SoftDelete = "[dbo].[softDelete]";
    }
}
