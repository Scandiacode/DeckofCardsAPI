using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeckOfCards.Models
{
    public class GetDeckCardDAL
    {
        public string GenerateNewDeck()
        {
            string url = @$"https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string JSON = reader.ReadToEnd();

            return JSON;
        }

        public string DrawCardsJson(string deckId, string drawFive)
        {
            
            string url = $@"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count={drawFive}";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string JSON = reader.ReadToEnd();

            return JSON;
        }

        public ShuffleCardModel ConvertJsonNewDeck()
        {
            string data = GenerateNewDeck();

            ShuffleCardModel deckGenerated = JsonConvert.DeserializeObject<ShuffleCardModel>(data);

            return deckGenerated;
        }

        public DrawCardModel ConvertJsonDrawCard(string drawFive, string deckId)
        {
            string data = DrawCardsJson(drawFive, deckId);

            DrawCardModel cardDrawn = JsonConvert.DeserializeObject<DrawCardModel>(data);

            return cardDrawn;
        }
    }
}
