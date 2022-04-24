namespace MTGDeck.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string Name { get; set; }
        public string Mana_Cost { get; set; }
        public string Colors { get; set; }
        public string Type_Line { get; set; }
        public string Oracle_Text {get; set; }
        public string Legalities { get; set; }
        public string Set_Name { get; set; }
        public string Rulings_Uri { get; set; }
        public string Image_Uris { get; set; }
        
    }
}