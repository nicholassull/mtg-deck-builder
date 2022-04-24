using System.Collections.Generic;

namespace MTGDeck.Models
{
  public class Deck
  {
    public Deck()
    {
      this.JoinEntities = new HashSet<CardDeck>();
    }
    public int DeckId { get; set; }
    public string Name { get; set; }
    //Should mana be int or a string?
    public int[] Mana { get; set; }
    public List<string> Colors { get; set; }
    public virtual ICollection<CardDeck> JoinEntities { get; set; }
  }
}