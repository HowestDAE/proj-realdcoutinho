using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperHeros.Model;

namespace SuperHeros.Repository
{
    internal class HerosApiRepository /*: ISuperHeroRepository*/
    {
        private static List<Hero> _heros;
        private static List<int> _heroIds;

        public static async Task<List<Hero>> GetHeros()
        {
            if (_heros != null) return _heros;

            if (_heroIds == null)
            {
                _heroIds = new List<int>();
                _heroIds.Add(70);
                _heroIds.Add(644);
                _heroIds.Add(720);
                _heroIds.Add(63);

                _heroIds.Add(620);
                _heroIds.Add(346);
                _heroIds.Add(157);
                _heroIds.Add(107);
            }

         

            _heros = new List<Hero>();

            List<string> allInformationList = new List<string>();
            foreach (int id in _heroIds)
            {
                string endpoint = $"https://www.superheroapi.com/api.php/6825821920779096/{id}";

                //create an HttpClient
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        var response = await client.GetAsync(endpoint);

                        if (!response.IsSuccessStatusCode)
                        {
                            throw new HttpRequestException(response.ReasonPhrase);
                        }

                        string currentInfo = await response.Content.ReadAsStringAsync();

                        Hero hero = JsonConvert.DeserializeObject<Hero>(currentInfo);

                        _heros.Add(hero);
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            return _heros;
        }
    }
    
}
