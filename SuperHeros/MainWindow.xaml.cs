using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SuperHeros.Model;
using SuperHeros.Repository;

namespace SuperHeros
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HeroRepository _heroRepository;

        private ISuperHeroRepository _repository;

        public MainWindow()
        {
            InitializeComponent();
            _heroRepository = new HeroRepository();
            _repository = new HerosLocalRepository();
            GetHeros();
        }

        public async void GetHeros()
        {
            //await _heroRepository.GetHeroes();
            await _repository.GetHeros();
        }
    }
}
