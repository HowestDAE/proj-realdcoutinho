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
    internal class HerosLocalRepository : ISuperHeroRepository
    {
        private static List<Hero> _heroes;

        public async Task<List<Hero>> GetHeros()
        {
            if (_heroes != null) return _heroes;

            await LoadHeros();
            return _heroes;
        }

        private async Task LoadHeros()
        {
            if (_heroes != null) return;

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "SuperHeros.Resources.Data.Heros.json";


            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    _heroes = JsonConvert.DeserializeObject<List<Hero>>(json);

                }
            }


            foreach (Hero he in _heroes)
            {
                Console.WriteLine("hero");
            }

        }
    }
}
