using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MTGDeck.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace MTGDeck.Controllers
{
  [Authorize]
  public class CardsController : Controller
  {
    private readonly MTGDeckContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public CardsController(UserManager<ApplicationUser> userManager, MTGDeckContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public IActionResult Search(string name, string color, string type)
    {
    List<Card> result = Card.SearchCards(name, color, type);
    return View(result);
    }

    public ActionResult Create()
    {
      ViewBag.DeckId = new SelectList(_db.Decks, "DeckId", "Name");
      return View();
    }

    public ActionResult Edit(int id)
    {
      var thisCard = _db.Cards.FirstOrDefault(card => card.CardId == id);
      ViewBag.DeckId = new SelectList(_db.Decks, "DeckId", "Name");
      return View(thisCard);
    }

    public ActionResult AddDeck(int id)
    {
      var thisCard = _db.Cards.FirstOrDefault(treat => treat.CardId == id);
      ViewBag.DeckId = new SelectList(_db.Decks, "DeckId", "Name");
      return View(thisCard);
    }

    [HttpPost]
    public ActionResult AddDeck(Card card, int DeckId)
    {
      if (DeckId != 0)
      {
      _db.CardDecks.Add(new CardDeck() { DeckId = DeckId, CardId = card.CardId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCard = _db.Cards.FirstOrDefault(card => card.CardId == id);
      return View(thisCard);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCard = _db.Cards.FirstOrDefault(card => card.CardId == id);
      _db.Cards.Remove(thisCard);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteFlavor(int joinId)
    {
      var joinEntry = _db.CardDecks.FirstOrDefault(entry => entry.CardDeckId == joinId);
      _db.CardDecks.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}