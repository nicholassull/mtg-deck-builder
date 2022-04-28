using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MTGDeck.Models;

namespace MTGDeck.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var allCards = Card.SearchCards("", "", "elf");
            string cardImages = Card.GetCardImage("Aberrant Mind Sorcerer");
            ViewBag.CardImages = Url.Content(cardImages);
            return View(allCards);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}