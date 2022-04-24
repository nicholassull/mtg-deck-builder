namespace MTGDeck.Models
{
  public class CardDeck
  {
    public int CardDeckId { get; set; }
    public int CardId { get; set; }
    public int DeckId { get; set; }
    public virtual Card Card { get; set; }
    public virtual Deck Deck { get; set; }
  }
}