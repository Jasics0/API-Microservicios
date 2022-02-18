using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Unillanos.ArquitecturaMS.Usuarios.Filter
{
    class _ExceptionJson
    {
        public string message { get; set; }
        public string type { get; set; }

        public _ExceptionJson (string message,string type)
        {
            this.message = message;
            this.type = type;
        }
    }

    public class ExceptionHandler : IExceptionFilter
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public ExceptionHandler(IWebHostEnvironment hostEnvironment,IModelMetadataProvider modelMetadataProvider)
        {
           _hostEnvironment = hostEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            _ExceptionJson exceptionJson = new _ExceptionJson(context.Exception.Message,context.Exception.GetType().ToString());
            context.Result =new JsonResult(exceptionJson);
            context.HttpContext.Response.StatusCode = 400;
        }
    }
}