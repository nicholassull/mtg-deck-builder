using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MTGDeck.Models
{
  //This is the reference object for our database
  public class MTGDeckContext : IdentityDbContext<ApplicationUser>
  {
    //The DbSets represent the tables within out database
    public DbSet<Card> Cards { get; set; }
    public DbSet<Deck> Decks { get; set; }
    public DbSet<CardDeck> CardDecks { get; set; }
    public MTGDeckContext(DbContextOptions options) : base(options) { }
    
    //Enables lazy loading
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}