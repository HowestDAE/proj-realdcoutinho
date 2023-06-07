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
    public class HerosApiRepository : ISuperHeroRepository
    {
        private static List<Hero> _heros;
        private static List<int> _heroIds;

        public async Task<List<Hero>> GetHeros()
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


        public List<string> GetHeroTypes()
        {
            List<string> types = new List<string>();

            types.Add("All");
            types.Add("Male");
            types.Add("Female");
            types.Add("DC Comics");
            types.Add("Marvel Comics");

            return types;
        }


        public List<Hero> GetHeroByTypes(string heroType)
        {
            List<Hero> list = new List<Hero>();

            if (heroType == "All") return _heros;

            if (heroType == "Male" || heroType == "Female")
            {
                list = GetHerosByGender(heroType);
            }
            if (heroType == "DC Comics" || heroType == "Marvel Comics")
            {
                list = GetHerosByPublisher(heroType);
            }
            return list;
        }


        #region FILTERS
        private List<Hero> GetHerosByPublisher(string publisher)
        {
            return _heros.Where(_heros => _heros.Biography.Publisher.ToLower() == publisher.ToLower()).ToList();
        }

        private List<Hero> GetHerosByGender(string gender)
        {
            return _heros.Where(_heros => _heros.Appearance.Gender.ToLower() == gender.ToLower()).ToList();
        }
        #endregion

    }

}
