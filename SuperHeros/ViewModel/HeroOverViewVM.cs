using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperHeros.Model;


namespace SuperHeros.ViewModel
{
    internal class HeroOverViewVM : ObservableObject
    {
        private List<Hero> _heroList;

        public List<Hero> Heros
        {
            get { return _heroList; }
            set
            {
                _heroList = value;
                OnPropertyChanged(nameof(Heros));
            }
        }

        private Hero _selectedHero = new Hero();
        public Hero SelectedHero
        {
            get { return _selectedHero; }
            set
            {
                _selectedHero = value;
                OnPropertyChanged(nameof(SelectedHero));
            }
        }
    }
}
