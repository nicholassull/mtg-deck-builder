using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MTGDeck.Models
{
    public class Card
    {
      public Card()
      {
        this.JoinEntities = new HashSet<CardDeck>();
      }
        public int CardId { get; set; }
        public string Name { get; set; }
        public string Mana_Cost { get; set; }
        // public string Colors { get; set; }
        public string Type_Line { get; set; }
        public string Oracle_Text {get; set; }
        // public string Legalities { get; set; }
        public string Set_Name { get; set; }
        public string Rulings_Uri { get; set; }
        public virtual IDictionary<string, string> Image_Uris { get; set; }
        public virtual ICollection<CardDeck> JoinEntities {get; set; }
        // public virtual ApplicationUser User { get; set; } 

    public static List<Card> SearchCards(string name, string colors, string type)
    {
      var apiCallTask = ApiHelper.Search(name, colors, type);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      //How do we get this stored into the object?
      //Should we make a second method and return the bellow result, using a viewbag to send it to the controller.
      var imageInfo = jsonResponse["data"][0]["image_uris"]["normal"];
      Console.WriteLine("=========" + imageInfo + "===========");

      List<Card> cardList = JsonConvert.DeserializeObject<List<Card>>(jsonResponse["data"].ToString());
      
      return cardList;
    }
  }
}


// var rateInfo = json["HotelListResponse"]["HotelList"]["HotelSummary"][0]["RoomRateDetailsList"]["RoomRateDetails"]["RateInfos"]["RateInfo"];

// var result =JsonConvert.DeserializeObject<RateInfo>( rateInfo .ToString() );
 