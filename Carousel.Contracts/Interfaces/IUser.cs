using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carousel.Contracts.Interfaces
{
  public interface IUser
    {
        string userName { get; set; }
        string email { get; set; }
        int userId { get; set; }
        int isDeleted { get; set; }
        int status { get; set; }
        int topRows { get; set; }
        int skipRows { get; set; }
       

    }

   
}
