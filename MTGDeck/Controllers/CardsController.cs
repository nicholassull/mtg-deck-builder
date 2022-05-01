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

    public IActionResult Details(string name)
    {
      Card card = Card.GetCard(name);
      return View(card);
    }

    public ActionResult Edit(int id)
    {
      var thisCard = _db.Cards.FirstOrDefault(card => card.CardId == id);
      ViewBag.DeckId = new SelectList(_db.Decks, "DeckId", "Name");
      return View(thisCard);
    }

    public ActionResult AddCard(int id)
    {
      var thisCard = _db.Cards.FirstOrDefault(card => card.CardId == id);
      ViewBag.CardId = new SelectList(_db.Cards, "CardId", "Name");
      return View(thisCard);
    }

    [HttpPost]
    public ActionResult AddCard(Deck deck, int CardId)
    {
      if (CardId != 0)
      {
      _db.CardDecks.Add(new CardDeck() { CardId = CardId, DeckId = deck.DeckId });
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

    // Grabs the extra info stored in ScryfallCard and assignes passes them to the ViewBag
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

// //   public async Task Index()
// {
//     var result = await GetCard(); 
//     var transformed = result.Select(e =>
//           new Card {
//               Name = e.cards.name,  
//               Mana_Cost = e.cards.mana_cost,
//               Type_Line = e.cards.type_line,
                //  Set_Name = e.cards.set_name
//           }
//     );

//     using var cardInfo = new MTGDeckContext();
//     foreach(var item in transformed)
//     {
//         cardInfo.Cards.Add(item);
//         await cardInfo.SaveChangesAsync();
//     }                                            
// }