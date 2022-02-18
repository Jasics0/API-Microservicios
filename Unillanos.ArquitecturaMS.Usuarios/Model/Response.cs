namespace Unillanos.ArquitecturaMS.Usuarios.Model
{
    public class Response
    {
        public string message { get; set; }

        public Response(string message)
        {
            this.message = message;
        }
    }
}