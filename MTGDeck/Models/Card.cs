using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
//     public static string SearchCards(string name, string color, string type)
//     {
//       var apiCallTask = ApiHelper.Search(name, color, type);//here I use the method I just created
//       var result = apiCallTask.Result;
//   //the response from the api is being deserialized just as with the other methods like GetAll() and GetDetails()
//       JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
//       List<Card> card = JsonConvert.DeserializeObject<List<Card>>(jsonResponse.ToString());
//       return card;
//     }
  }
}