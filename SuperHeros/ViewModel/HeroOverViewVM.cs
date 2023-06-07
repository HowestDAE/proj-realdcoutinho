using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperHeros.Model;
using SuperHeros.Repository;


namespace SuperHeros.ViewModel
{
    internal class HeroOverViewVM : ObservableObject
    {
        private List<Hero> _heroList = new List<Hero>();
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

        private List<string> _filterTypes;
        public List<string> FilterTypes
        {
            get { return _filterTypes; }
            set
            {
                _filterTypes = value;
                if (_filterTypes != null)
                {
                    OnPropertyChanged(nameof(FilterTypes));
                }
            }
        }

        private string _selectedType;
        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                if (_selectedType != null)
                {
                    SetProperty(ref _selectedType, value);
                    Heros = HerosLocalRepository.GetHeroTypes(value);
                    OnPropertyChanged(nameof(SelectedType));
                }
            }
        }



        public HeroOverViewVM()
        {
            LoadHeros();
            FilterTypes = HerosLocalRepository.GetHeroTypes();
            //LoadHerosAsync();
            //FilterType = HerosApiRepository.GetHeroTypes();
        }

        private async void LoadHerosAsync()
        {
            Heros = await HerosApiRepository.GetHeros();
        }

        private void LoadHeros()
        {
            Heros = HerosLocalRepository.GetHeros();
        }

        /// /////////////////////
        ///     FILTERS /////////
        ////////////////////////
        #region FILTERS
        public void FilterHerosByPublisher(string publisher)
        {
            Heros = HerosLocalRepository.GetHerosByPublisher(publisher);
            SelectedType = publisher;
        }

        public async Task FilterHerosByPublisherAsync(string publisher)
        {
            Heros = await HerosApiRepository.GetHerosByPublisherAsync(publisher);
            SelectedType = publisher;
        }

        public void FilterHerosByGender(string gender)
        {
            Heros = HerosLocalRepository.GetHerosByGender(gender);
            SelectedType = gender;
        }

        public async Task FilterHerosByGenderAsync(string gender)
        {
            Heros = await HerosApiRepository.GetHerosByGenderAsync(gender);
            SelectedType = gender;
        }
        #endregion















        //public void FilterHerosByName()
        //{
        //    Agents = AgentsLocalRepository.GetAgentsByName(SearchText);

        //    if (SelectedRole != null && SelectedRole != string.Empty && SelectedRole.ToUpper() != "ALL")
        //    {
        //        Agents = Agents.Where(agent => agent.role.displayName == SelectedRole).ToList();
        //    }
        //}

        //public async Task FilterAgentsByNameAsync()
        //{
        //    Agents = await AgentsApiRepository.GetAgentsByNameAsync(SearchText);

        //    //remove agents with wrong role
        //    if (SelectedRole != null && SelectedRole != string.Empty && SelectedRole.ToUpper() != "ALL")
        //    {
        //        Agents = Agents.Where(agent => agent.role.displayName == SelectedRole).ToList();
        //    }
        //}
    }
}
