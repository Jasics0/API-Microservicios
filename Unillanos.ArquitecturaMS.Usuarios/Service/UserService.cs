using System.Collections.Generic;
using System.IO;
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

        public string post(User user)
        {
            User exist = get(user.user);
            if (exist.user == null)
            {
                var json = File.ReadAllText(_path);
                var users = JsonConvert.DeserializeObject<List<User>>(json);
                users.Add(user);
                File.WriteAllText(_path, JsonConvert.SerializeObject(users));
                return user.ToString();
            }
            {
                return "{\"message\":\"El usuario ya existe en la BD.\"}";
            }

        }
        
        public string delete(string user)
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
                return"{\"message\":\"El usuario se eliminó de la BD.\"}";
            }
            {
                return "{\"message\":\"El usuario no existe en la BD.\"}";
            }

        }
        
        public string put(string username,User user)
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
                        break;
                    }
                }
                File.WriteAllText(_path, JsonConvert.SerializeObject(users));
                return"{\"message\":\"El usuario se actualizó correctamente.\"}";
            }
            {
                return "{\"message\":\"El usuario no existe en la BD.\"}";
            }

        }
        
        
    }
}