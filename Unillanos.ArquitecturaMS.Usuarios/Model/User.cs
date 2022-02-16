using System.Text.Json;

namespace Unillanos.ArquitecturaMS.Usuarios.Model
{
    public class User
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        
        public override string ToString()
        {
            return "Person: " + name + " " + lastname+" user: "+user+" psswd: "+password;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}