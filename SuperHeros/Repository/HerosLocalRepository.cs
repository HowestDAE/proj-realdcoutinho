using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperHeros.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeros.Repository
{
    internal class HerosLocalRepository /*: ISuperHeroRepository*/
    {
        private static List<Hero> _heros;
        public static List<Hero> GetHeros()
        {
            if (_heros != null) return _heros;

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
            return _heros;
        }
    }
}
