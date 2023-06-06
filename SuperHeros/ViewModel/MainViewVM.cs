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
        public HeroOverViewPage HeroOverView 
        { 
            get;
        } = new HeroOverViewPage();
        public HeroDetailPage HeroDetailPage 
        { 
            get;
        } = new HeroDetailPage();


   
        public Page CurrentPage
        {
            get;
            set;

        }
        public RelayCommand SwitchPageCommand { get; set; }


        public bool IsInOverview => CurrentPage is HeroOverViewPage;
        public bool IsInDetail => CurrentPage is HeroDetailPage;

        public void SwitchPage()
        {
            if (CurrentPage is HeroOverViewPage)
            {
                Hero selectedHero = (CurrentPage.DataContext as HeroOverViewVM).SelectedHero;
                OnPropertyChanged(nameof(CurrentPage));
            }
            else
            {
                CurrentPage = HeroOverView;
                OnPropertyChanged(nameof(CurrentPage));
            }

            OnPropertyChanged(nameof(IsInDetail));
            OnPropertyChanged(nameof(IsInOverview));
        }

        public MainViewVM()
        {
            CurrentPage = HeroOverView;
            //SwitchPageCommand = new RelayCommand(SwitchPage);
        }

    }
}
