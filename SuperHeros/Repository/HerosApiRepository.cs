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
                _heroIds.Add(70);  //batman // works
                _heroIds.Add(263); //flash  // works
                _heroIds.Add(720); //wonder woman // works
                _heroIds.Add(542); //catwoman // works

                _heroIds.Add(620); //spider man
                _heroIds.Add(346); //iron man // works
                _heroIds.Add(275); // Gamora // works
                _heroIds.Add(107); //balck widow
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


        public static async Task<List<string>> GetHeroTypes()
        {
            List<Hero> allHeros = await GetHeros();

            List<string> types = new List<string>();

            List<string> uniquePublishers = allHeros.Select(hero => hero.Biography.Publisher).Distinct().ToList();
            List<string> uniqueGenders = allHeros.Select(hero => hero.Appearance.Gender).Distinct().ToList();

            types.AddRange(uniquePublishers);
            types.AddRange(uniqueGenders);

            return types;
        }

        #region FILTERS
        public static async Task<List<Hero>> GetHerosByPublisherAsync(string publisher)
        {
            if (_heros == null)
            {
                _heros = await GetHeros();
            }

            if (publisher.ToLower() == "all") return _heros;
            else return _heros.Where(_heros => _heros.Biography.Publisher.ToLower() == publisher.ToLower()).ToList();
        }

        public static async Task<List<Hero>> GetHerosByGenderAsync(string gender)
        {
            if (_heros == null)
            {
                _heros = await GetHeros();
            }

            if (gender.ToLower() == "all") return _heros;
            else return _heros.Where(_heros => _heros.Appearance.Gender.ToLower() == gender.ToLower()).ToList();
        }

        public static async Task<List<Hero>> GetHerosByNameAsync(string name)
        {
            if (_heros == null)
            {
                _heros = await GetHeros();
            }

            if (name.ToLower() == "all") return _heros;
            else return _heros.Where(_heros => _heros.Name.ToLower() == name.ToLower()).ToList();
        }
        #endregion

    }

}
