using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperHeros.Model;
using SuperHeros.Repository;
using SuperHeros.View;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;

namespace SuperHeros.ViewModel
{
    internal class MainViewVM : ObservableObject
    {
        public HeroOverViewPage HeroViewPage { get; set; } = new HeroOverViewPage();
        public HeroDetailPage HeroDetailPage { get; set; } = new HeroDetailPage();

        public Page CurrentPage { get; set; } = new HeroOverViewPage();

        public RelayCommand SwitchPageCommand { get; set; }
    }
}
