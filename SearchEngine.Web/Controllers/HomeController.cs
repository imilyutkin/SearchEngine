using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchEngine.DomainModels.Models;
using SearchEngine.Repositories.Contracts;

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

        public ActionResult Index()
        {
            UrlRepository.Save(new Url
            {
                Title = "tut",
                Address = "http://tut.by"
            });
            return View();
        }

    }
}
