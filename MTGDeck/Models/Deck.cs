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
    public virtual ICollection<CardDeck> JoinEntities { get; set; }
    public virtual ApplicationUser User { get; set; } 
  }
}