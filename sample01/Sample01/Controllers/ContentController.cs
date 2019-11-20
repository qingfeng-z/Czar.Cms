using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sample01.Controllers
{
    using Microsoft.Extensions.Options;
    using Sample01.Models;

    public class ContentController : Controller
    {
        private readonly Content contents;
        public ContentController(IOptions<Content> option)
        {
            contents = option.Value;
        }

        public IActionResult Index()
        {
            return this.View(new ContentView { Contents = new List<Content> { this.contents } });
        }
    }
}