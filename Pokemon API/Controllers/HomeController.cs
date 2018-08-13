using System.Diagnostics;
using System.Net;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json.Linq;
using Pokemon_API.Models;

namespace Pokemon_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Create request to API
            WebRequest request = WebRequest.Create("http://pokeapi.co/api/v2/pokemon/1");
            // Send that request off
            WebResponse response = request.GetResponse();

            // Function that returns a stream of information
            // Get back the response stream
            Stream stream = response.GetResponseStream();
            // Make it accessible
            StreamReader reader = new StreamReader(stream);
            
            // Reads all of information in StreamReader and put in it string
            // Which is json formatted
            string responseFromServer = reader.ReadToEnd();
            // JObject is a way of parsing jSon data
            // Turns into jObject a much more readable json
            JObject parsedString = JObject.Parse(responseFromServer);
           
            // Take parsed string and map it to Pokemon Model class
            Pokemon myPokemon = parsedString.ToObject<Pokemon>();

            // Now we have an object that has all of the data of the pokemon we request
            Debug.WriteLine(myPokemon.moves[0].move.name);
            return View();
        }

    }
}