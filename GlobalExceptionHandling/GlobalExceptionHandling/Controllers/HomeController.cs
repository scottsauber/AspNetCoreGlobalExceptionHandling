using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptionHandling.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("Something bad happened.");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                string routeWhereExceptionOccurred = exceptionFeature.Path;

                Exception exceptionThatOccurred = exceptionFeature.Error;


                //throw exceptionThatOccurred;
                // TODO: Do something with the exception
                // Log it with Serilog?
                // Send an e-mail, text, fax, or carrier pidgeon?  Maybe all of the above?
                // Whatever you do, be careful to catch any exceptions, otherwise you'll end up in an endless loop of throwing exceptions.
            }

            return View();
        }
    }
}
