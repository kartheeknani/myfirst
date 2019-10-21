using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hello.Controllers
{
    public class helloworldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}