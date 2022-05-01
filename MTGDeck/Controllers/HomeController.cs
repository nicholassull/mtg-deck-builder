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

        public ActionResult Index()
        {
            var allCards = Card.SearchCards("", "U", "");
            // string cardImages = Card.GetCardImage("Aberrant Mind Sorcerer");
            // ViewBag.CardImages = Url.Content(cardImages);
            // string cardLegalities = Card.GetLegalities("Aberrant Mind Sorcerer");
            // ViewBag.CardLegalities = cardLegalities;
            // string cardPrices = Card.GetPrices("Aberrant Mind Sorcerer");
            // ViewBag.CardPrices = cardPrices;
            // string cardOracle = Card.GetOracle("Aberrant Mind Sorcerer");
            // ViewBag.CardOracle = cardOracle;
            // string cardFlavor = Card.GetFlavor("Aberrant Mind Sorcerer");
            // ViewBag.CardFlavor = cardFlavor;
            storeCardInfo("Aberrant Mind Sorcerer");
            return View(allCards);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public void storeCardInfo(string cardName)
        {
            string cardImages = Card.GetCardImage("Aberrant Mind Sorcerer");
            ViewBag.CardImages = Url.Content(cardImages);
            string cardLegalities = Card.GetLegalities("Aberrant Mind Sorcerer");
            ViewBag.CardLegalities = cardLegalities;
            string cardPrices = Card.GetPrices("Aberrant Mind Sorcerer");
            ViewBag.CardPrices = cardPrices;
            string cardOracle = Card.GetOracle("Aberrant Mind Sorcerer");
            ViewBag.CardOracle = cardOracle;
            string cardFlavor = Card.GetFlavor("Aberrant Mind Sorcerer");
            ViewBag.CardFlavor = cardFlavor;
        }

    }
}