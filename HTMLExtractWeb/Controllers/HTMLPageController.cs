using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HTMLExtractWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HTMLExtractWeb.Controllers
{
    public class HTMLPageController : Controller
    {
        public static List<HTMLPage> Lista { get; set; }

        public HTMLPageController()
        {
            if (Lista == null)
            {
                Lista = new List<HTMLPage>();
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HTMLPage page)
        {
            page.Code = getHTMLCode(page.URI);

            if (page.RegEx != null && page.Code != null)
            {
                Regex regex = new Regex(page.RegEx);
                Match match = regex.Match(page.Code);
                page.Match = match.Groups[0].Value;
            }

            Lista.Add(page);

            return View("List", Lista);
        }

        public IActionResult List(HTMLPage page)
        {
            if (page != null)
            {
                return View(page);
            }
            return View(new List<HTMLPage>());
        }

        public string getHTMLCode(string uri)
        {
            var webClient = new WebClient();
            return new UTF8Encoding().GetString(webClient.DownloadData(uri));
        }
    }
}
