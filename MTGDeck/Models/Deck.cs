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
    public int LandCount { get; set; }
    // public int OneCost { get; set; }
    // public int TwoCost { get; set; }
    // public int ThreeCost { get; set; }
    // public int FourCost { get; set; }
    // public int FiveCost { get; set; }
    // public int SixCost { get; set; }
    // //Includes costs of 7 or more.
    // public int SevenCost { get; set; }
    public virtual ICollection<CardDeck> JoinEntities { get; set; }
    public virtual ApplicationUser User { get; set; }

    public void AddLand(Card card)
    {
      if(card.Type_Line.ToUpper().Contains("LAND"))
      {
        this.LandCount ++;
      }
    }
     public void RemoveLand(Card card)
    {
      if(card.Type_Line.ToUpper().Contains("LAND"))
      {
        this.LandCount --;
      }
    }
  }
}