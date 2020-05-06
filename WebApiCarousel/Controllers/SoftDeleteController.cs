using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http;
using System.Web.Http.Cors;
using Carousel.BusinessLogicData.BusinessLogic;
using Carousel.BusinessLogicData.Interfaces;
using Carousel.Models.Models;


namespace WebApiCarousel.Controllers
{
    [EnableCors("http://localhost:3000", "*", "GET,POST,PUT")]
    public class SoftDeleteController : ApiController
    {

        private readonly IBusinessLogic _Bal;
        public SoftDeleteController(IBusinessLogic Bal)
        {
            _Bal = Bal;
        }
       



       
        public string Put(int userId, [FromBody]int isDeleted)
        {
            return _Bal.SoftDeleteUser(userId, isDeleted);
        }

    }
}