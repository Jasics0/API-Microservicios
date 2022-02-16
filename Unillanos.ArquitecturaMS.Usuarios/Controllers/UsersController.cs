using Microsoft.AspNetCore.Mvc;
using Unillanos.ArquitecturaMS.Usuarios.Model;
using Unillanos.ArquitecturaMS.Usuarios.Service;

namespace Unillanos.ArquitecturaMS.Usuarios.Controllers
{
    [Route("user/")]
    [ApiController]
    public class UsersController : Controller
    {
        private UserService _userService= new UserService();
        [HttpGet]
        [Route("get/{user}")]
        public string Get(string user)
        {
            User u = _userService.get(user);
            return (u.user == null) ? "{\"message:\":\"No se econtró el usuario.\"}" : u.ToJson();
        }

        [HttpPost]
        [Route("insert/")]
        public string Post(User user)
        {
            return  _userService.post(user);
        }

        [HttpDelete]
        [Route("delete/{user}")]
        public string Delete(string user)
        {
            return _userService.delete(user);
        }

        [HttpPut]
        [Route("update/{username}")]
        public string Put(User user,string username)
        {
            return _userService.put(username,user);
        }
        
    }
}