using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchEngine.DomainModels.Models;
using SearchEngine.Repositories.Contracts;
using WebGrease.Css.Extensions;

namespace SearchEngine.Web.Controllers
{
    public class HomeController : Controller
    {
        protected IUrlRepository UrlRepository;

        public HomeController(IUrlRepository urlRepository)
        {
            UrlRepository = urlRepository;
        }

        //
        // GET: /Home/

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String urlToProcess)
        {
            var s = urlToProcess;
            return View("Index");
        }

    }
}
