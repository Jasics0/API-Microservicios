using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Unillanos.ArquitecturaMS.Usuarios.Model;

namespace Unillanos.ArquitecturaMS.Usuarios.Service
{
    public class UserService
    {

        private string _path = "src/users.json";
        public User get(string user)
        {
            var json = File.ReadAllText(_path);
            var users = JsonConvert.DeserializeObject<List<User>>(json);
            var result = new User();
            foreach (var u in users)
            {
                if (u.user == user)
                {
                    result = u;
                    break;
                }
            }
            return result;
        }

        public JsonResult post(User user)
        {
            User exist = get(user.user);
            if (exist.user == null)
            {
                var json = File.ReadAllText(_path);
                var users = JsonConvert.DeserializeObject<List<User>>(json);
                users.Add(user);
                File.WriteAllText(_path, JsonConvert.SerializeObject(users));
                return new JsonResult(new Response(user.ToString()));
            }
            {
                throw new Exception("El usuario ya existe en la BD.");
            }

        }
        
        public JsonResult delete(string user)
        {
            User exist = get(user);
            if (exist.user != null)
            {
                var json = File.ReadAllText(_path);
                var users = JsonConvert.DeserializeObject<List<User>>(json);
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].user == user)
                    {
                        users.RemoveAt(i);
                        break;
                    }
                }
                File.WriteAllText(_path, JsonConvert.SerializeObject(users));
                return new JsonResult(new Response("Se eliminó correctamente"));
            }

            {
                throw new Exception("El usuario no se ecuentra en la BD.");
            }

        }
        
        public JsonResult put(string username,User user)
        {
            User exist = get(username);
            if (exist.user != null)
            {
                var json = File.ReadAllText(_path);
                var users = JsonConvert.DeserializeObject<List<User>>(json);
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].user == username)
                    {
                        users[i].user = user.user;
                        users[i].name=user.name;
                        users[i].lastname = user.lastname;
                        users[i].password = user.password;
                        users[i].gender = user.gender;
                        users[i].email = user.email;
                        users[i].age = user.age;
                        users[i].phone = user.phone;
                        break;
                    }
                }
                File.WriteAllText(_path, JsonConvert.SerializeObject(users));
                return new JsonResult(new Response("Se actualizó correctamnte el usuario."));
            }
            {
                throw new AuthenticationException("El usuario no se ecuentra en la BD.");
            }

        }
        
        
    }
}