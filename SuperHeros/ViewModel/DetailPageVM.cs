using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using SuperHeros.Model;

namespace SuperHeros.ViewModel
{
    internal class DetailPageVM : ObservableObject
    {
        private Hero _currentHero;

        public Hero CurrentHero
        {
            get => _currentHero;
            set
            {
                SetProperty(ref _currentHero, value);
                OnPropertyChanged(nameof(CurrentHero));
            }

        }

        public DetailPageVM()
        {
            // Set default CurrentPokemon
            CurrentHero = new Hero();
        }

    }
}
