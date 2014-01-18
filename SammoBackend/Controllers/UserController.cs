using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SammoBackend.Models;
namespace SammoBackend.Controllers
{
    // Delivers user information
    // POST: Register User / Login
    public class UserController : ApiController
    {

        public User Post(User u)
        {
            if (isValid())
            {
                // User user = users.AddUser(u);
            }
            User user = new User() ;
            return user;
        }


        private Boolean isValid()
        {
            return false;

        }
    }
}
