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
        public HeroDetailPage HeroPage 
        { 
            get;
        } = new HeroDetailPage();



        public HeroOverViewPage MainPage
        {
            get; set;
        } = new HeroOverViewPage();

        private Page _currentPage;

        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
                OnPropertyChanged(nameof(CommandText));
            }
        }


        public string CommandText
        {
            get
            {
                if (CurrentPage is HeroOverViewPage) //overView page -> go to details page
                {
                    return "SHOW DETAILS";
                }
                else
                {
                    return "GO BACK";
                }
            }

        }

        private RelayCommand _switchPageCommand;
        public RelayCommand SwitchPageCommand
        {
            get
            {
                if (_switchPageCommand == null)
                {
                    // Initialize the RelayCommand with the SwitchPage function
                    _switchPageCommand = new RelayCommand(SwitchPage);
                }
                return _switchPageCommand;
            }
        }




        //public bool IsInOverview => CurrentPage is HeroOverViewPage;
        //public bool IsInDetail => CurrentPage is HeroDetailPage;

        public void SwitchPage()
        {
            if (CurrentPage is HeroOverViewPage)
            {
                //get the selected pokemon
                Hero selectedHero = (CurrentPage.DataContext as HeroOverViewVM).SelectedHero;
                if (selectedHero == null)
                {
                    CurrentPage = MainPage;
                    return;
                }


                (HeroPage.DataContext as DetailPageVM).CurrentHero = selectedHero;

                //Set the current page. TODO notify the view of the change
                CurrentPage = HeroPage;
            }
            else
            {
                CurrentPage = MainPage;
            }

        }

        public MainViewVM()
        {
            HeroPage = new HeroDetailPage();
            CurrentPage = HeroOverView;
            //SwitchPageCommand = new RelayCommand(SwitchPage);
        }

    }
}
