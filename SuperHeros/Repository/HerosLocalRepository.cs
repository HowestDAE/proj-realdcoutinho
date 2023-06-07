using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperHeros.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeros.Repository
{
    public class HerosLocalRepository : ISuperHeroRepository
    {
        private static List<Hero> _heros;
        public Task<List<Hero>> GetHeros()
        {
            if (_heros != null)
                return Task.FromResult(_heros);

            _heros = new List<Hero>();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "SuperHeros.Resources.Data.Heros.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    _heros = JsonConvert.DeserializeObject<List<Hero>>(json);
                }
            }

            return Task.FromResult(_heros);
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
        //public static List<Hero> GetHerosByPublisher(string publisher)
        //{
        //    if (_heros == null)
        //    {
        //        _heros = GetHeros();
        //    }

        //    if (publisher.ToLower() == "all") return _heros;
        //    else return _heros.Where(_heros => _heros.Biography.Publisher.ToLower() == publisher.ToLower()).ToList();
        //}

        //public static List<Hero> GetHerosByGender(string gender)
        //{
        //    if (_heros == null)
        //    {
        //        _heros = GetHeros();
        //    }

        //    if (gender.ToLower() == "all") return _heros;
        //    else return _heros.Where(_heros => _heros.Appearance.Gender.ToLower() == gender.ToLower()).ToList();
        //}

        //public static List<Hero> GetHerosByName(string name)
        //{
        //    if (_heros == null)
        //    {
        //        _heros = GetHeros();
        //    }

        //    if (name.ToLower() == "all") return _heros;
        //    else return _heros.Where(_heros => _heros.Name.ToLower() == name.ToLower()).ToList();
        //}
        #endregion

    }
}
