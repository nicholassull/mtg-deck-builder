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
using System;

namespace MTGDeck.Controllers
{
    [Authorize]
  public class DecksController : Controller
  {
    private readonly MTGDeckContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public DecksController(UserManager<ApplicationUser> userManager, MTGDeckContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userDecks = _db.Decks.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userDecks);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(Deck deck, int cardId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      deck.User = currentUser;
      _db.Decks.Add(deck);
      _db.SaveChanges();
      if (cardId != 0)
      {
          _db.CardDecks.Add(new CardDeck() { CardId = cardId, DeckId = deck.DeckId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisDeck = _db.Decks
          .Include(deck => deck.JoinEntities)
          .ThenInclude(join => join.Deck)
          .FirstOrDefault(deck => deck.DeckId == id);
      return View(thisDeck);
    } 

    public ActionResult Edit(int id)
    {
      Deck deck = _db.Decks.FirstOrDefault(model => model.DeckId == id);
      return View(deck);
    }
    [HttpPost]
    public ActionResult Edit(Deck deck)
    {
      _db.Entry(deck).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = deck.DeckId });
    }
    public ActionResult Delete(int id)
    {
      var thisDeck = _db.Decks.FirstOrDefault(deck => deck.DeckId == id);
      return View(thisDeck);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDeck = _db.Decks.FirstOrDefault(deck => deck.DeckId == id);
      _db.Decks.Remove(thisDeck);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddCard(Card card, int DeckId)
    {
      Console.WriteLine("=========" + card.Name + "==========");
      Console.WriteLine("=========" + DeckId + "=========");
      var thisDeck = _db.Decks.FirstOrDefault(deck => deck.DeckId == DeckId);
      _db.Cards.Add(card);
      _db.SaveChanges();
      if (DeckId != 0)
      {
        _db.CardDecks.Add(new CardDeck() { CardId = card.CardId, DeckId = thisDeck.DeckId }); 
        // thisDeck.AddManaCost(card);
        thisDeck.AddLand(card);
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteCard(int joinId)
    {
      var joinEntry = _db.CardDecks.FirstOrDefault(entry => entry.CardDeckId == joinId);
      var thisDeck = joinEntry.Deck;
      var thisCard = joinEntry.Card;
      // thisDeck.RemoveManaCost(thisCard);
      thisDeck.RemoveLand(thisCard);
      _db.CardDecks.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}