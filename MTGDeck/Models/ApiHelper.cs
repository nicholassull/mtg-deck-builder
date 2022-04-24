using System.Threading.Tasks;
using RestSharp;
using System;

namespace MTGDeck.Models
{
  class ApiHelper
  {
    // public static async Task<string> GetAll()
    // {
    //   RestClient client = new RestClient("https://api.scryfall.com");
    //   RestRequest request = new RestRequest($"animals", Method.GET);
    //   var response = await client.ExecuteTaskAsync(request);
    //   return response.Content;
    // }
    public static async Task<string> Get(string name, string color, string type)
    {
      RestClient client = new RestClient("https://api.scryfall.com");
      RestRequest request = new RestRequest($"cards/search?q={name} c:{color} t:{type}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}
//https://api.scryfall.com/cards/search?q=obzedat c:b t:creature
// https://api.scryfall.com/cards/search?order=cmc&q=obzedat c:w cmc=5  