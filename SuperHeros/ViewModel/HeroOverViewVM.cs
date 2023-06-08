using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperHeros.Model;
using SuperHeros.Repository;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;



namespace SuperHeros.ViewModel
{
    internal class HeroOverViewVM : ObservableObject
    {
        private List<Hero> _heroList = new List<Hero>();
        private ISuperHeroRepository _heroApiRepository = new HerosApiRepository();
        private ISuperHeroRepository _heroLocalRepository = new HerosLocalRepository();


        private bool _IsUsingApi = false;

        public bool IsUsingAPI
        {
            get { return _IsUsingApi; }
            set
            {
                _IsUsingApi = value;
                LoadHeros();
                LoadHerosAsync();
                OnPropertyChanged(nameof(IsUsingAPI));
                OnPropertyChanged(nameof(SelectedType));
                OnPropertyChanged(nameof(Heros));


            }
        }

        public List<Hero> Heros
        {
            get { return _heroList; }
            set
            {
                _heroList = value;
                SetProperty(ref _heroList, value);
                if (_heroList != null)
                {
                    OnPropertyChanged(nameof(Heros));
                }
            }


        }

        private Hero _selectedHero = new Hero();
        public Hero SelectedHero
        {
            get { return _selectedHero; }
            set
            {
                _selectedHero = value;
                SetProperty(ref _selectedHero, value);
                if (_selectedHero != null)
                {
                    OnPropertyChanged(nameof(SelectedHero));
                }
            }

        }

        private List<string> _filterTypes;
        public List<string> FilterTypes
        {
            get { return _filterTypes; }
            set
            {
                _filterTypes = value;
                SetProperty(ref _filterTypes, value);
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
                    if (_IsUsingApi == true)
                    {
                        Heros = _heroApiRepository.GetHeroByTypes(value);
                    }
                    else
                    {
                        Heros = _heroLocalRepository.GetHeroByTypes(value);

                    }
                    OnPropertyChanged(nameof(SelectedType));
                }
            }
        }



        public HeroOverViewVM()
        {
            LoadHeros();
            LoadHerosAsync();
            FilterTypes = _heroLocalRepository.GetHeroTypes();
        }




        private async void LoadHeros()
        {
            Heros = await _heroLocalRepository.GetHeros();
        }
        private async void LoadHerosAsync()
        {
            Heros = await _heroApiRepository.GetHeros();
        }

        //private void GetFilters()
        //{
        //    FilterTypes = _heroLocalRepository.GetHeroTypes();
        //}

        public string DataText
        {
            get
            {
                if (_IsUsingApi == true) //overView page -> go to details page
                {
                    return "API READ";
                }
                else
                {
                    return "JSON READ";
                }
            }

        }


        private RelayCommand _switchRead;
        public RelayCommand SwitchDataMode
        {
            get
            {
                if (_switchRead == null)
                {
                    // Initialize the RelayCommand with the SwitchPage function
                    _switchRead = new RelayCommand(SwitchReadMode);

                }
                return _switchRead;
            }
        }


        public void SwitchReadMode()
        {


            if (_IsUsingApi == true)
            {
                _IsUsingApi = false;

            }
            else
            {
                _IsUsingApi = true;
            }
            OnPropertyChanged(nameof(DataText));

        }


    }
}
