using System.Collections.Generic;

namespace MTGDeck.Models
{
  public class Deck
  {
    public Deck()
    {
      this.JoinEntities = new HashSet<CardDeck>();
    //   Key represents amount of mana needed for spell, value is the number of cards with that mana requirement. '6' is actually 6 or more.
    //   this.Mana = new Dictionary<int, int>() {
    //     {1, 0},
    //     {2, 0},
    //     {3, 0},
    //     {4, 0},
    //     {5, 0},
    //     {6, 0}
    //   };
    }
    public int DeckId { get; set; }
    public string Name { get; set; }
    //Should mana be int or a string?
    // public IDictionary<int, int> Mana { get; set; }
    public string Colors { get; set; }
    public virtual ICollection<CardDeck> JoinEntities { get; set; }
  }
}