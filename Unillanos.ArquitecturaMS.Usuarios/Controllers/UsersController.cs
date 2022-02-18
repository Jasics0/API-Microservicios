using System;
using Microsoft.AspNetCore.Mvc;
using Unillanos.ArquitecturaMS.Usuarios.Filter;
using Unillanos.ArquitecturaMS.Usuarios.Model;
using Unillanos.ArquitecturaMS.Usuarios.Service;

namespace Unillanos.ArquitecturaMS.Usuarios.Controllers
{
    [Route("user/")]
    [TypeFilter(typeof(ExceptionHandler))]
    [ApiController]
    public class UsersController : Controller
    {
        private UserService _userService= new UserService();
        [HttpGet]
        [Route("get/{user}")]
        public JsonResult Get(string user)
        {
            User u = _userService.get(user);
            if (u.user == null)
            {
                throw new Exception("No se encontró el usuario.");
            }
            {
                return new JsonResult(u);
            }
        }

        [HttpPost]
        [Route("insert/")]
        public JsonResult Post(User user)
        {
            return  _userService.post(user);
        }

        [HttpDelete]
        [Route("delete/{user}")]
        public JsonResult Delete(string user)
        {
            return _userService.delete(user);
        }

        [HttpPut]
        [Route("update/{username}")]
        public JsonResult Put(User user,string username)
        {
            return _userService.put(username,user);
        }
        
    }
}