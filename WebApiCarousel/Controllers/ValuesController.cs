using Carousel.BusinessLogicData.BusinessLogic;
using Carousel.BusinessLogicData.Interfaces;
using Carousel.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiCarousel.Controllers
{
    [EnableCors("http://localhost:3000", "*", "GET,POST,PUT")]
    public class ValuesController : ApiController
    {


        private readonly IBusinessLogic _Bal;
        public ValuesController(IBusinessLogic Bal)
        {
            _Bal = Bal;
        }
       
        public IEnumerable<UserModel> Get()
        {
            return _Bal.GetUserData();
        }


        // POST api/values
        public IEnumerable<UserModel> Post([FromBody]UserModel value)
        {
            return _Bal.InsertSavePage(value);
        }

        // PUT api/values/5
        public string Put(int userId, [FromBody]UserModel value)
        {
            return _Bal.UpdateUser(userId, value);
        }


        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
