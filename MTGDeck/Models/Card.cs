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
        // public string Image_Uris { get; set; }
        public virtual ICollection<CardDeck> JoinEntities {get; set; }
        // public virtual ApplicationUser User { get; set; } 

    public static List<Card> SearchCards(string name, string colors, string type)
    {
      var apiCallTask = ApiHelper.Search(name, colors, type);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Card> cardList = JsonConvert.DeserializeObject<List<Card>>(jsonResponse["data"].ToString());
      
      return cardList;
    }

//     public static string SearchImage(string name, string colors, string type)
//     {
//       var apiCallTask = ApiHelper.Search(name, colors, type);
//       var result = apiCallTask.Result;
//   //the response from the api is being deserialized just as with the other methods like GetAll() and GetDetails()
//       JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
//       var imageInfo = jsonResponse["data"][0]["image_uris"]["small"];
//       string imageResult = JsonConvert.DeserializeObject<string>(imageInfo.ToString());
//       // string imageList = JsonConvert.DeserializeObject<string>(jsonResponse["data"][0]["image_uris"]["small"].ToString());
//       Console.WriteLine("=========" + imageInfo + "===========");
//       return imageResult;
//     }
  }
}


// var rateInfo = json["HotelListResponse"]["HotelList"]["HotelSummary"][0]["RoomRateDetailsList"]["RoomRateDetails"]["RateInfos"]["RateInfo"];

// var result =JsonConvert.DeserializeObject<RateInfo>( rateInfo .ToString() );
 