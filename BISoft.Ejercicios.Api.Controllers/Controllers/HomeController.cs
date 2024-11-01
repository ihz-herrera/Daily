using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BISoft.Ejercicios.Api.Controllers.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult MyHomeIndex()
        {
            // Get the version of the current assembly
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString()
               ;

            var mainText = "Welcome Ejercicios Service";

            var html = $"<body style=\"background-color: aliceblue;\">\r" +
                "<div style=\"height: 20%; width: 100% ; background-color: rgb( 83, 156, 227); \">" +
                "</div>" +
                "<div style=\"position:fixed; top:10%; left: 20%; background-color: white; width: 60%; height: 60%;" +
                "text-align: center; padding-top:10%;font-family: 'Segoe UI', Geneva, Verdana, sans-serif;\">" +
                "<h1 style=\"position:center\">" + mainText + "</h1>" +
                "<h3>version " + version + "</h3>" +
                "</div></body>";
            return base.Content(html, "text/html");


        }
    }
}
