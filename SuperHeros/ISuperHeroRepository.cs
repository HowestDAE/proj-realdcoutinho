﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperHeros.Model;
using SuperHeros.Repository;

namespace SuperHeros.Repository
{
    public interface ISuperHeroRepository
    {
        Task<List<Hero>> GetHeros();
        List<string> GetHeroTypes();
        //Task<List<string>> GetHeroTypes();
        List<Hero> GetHeroByTypes(string heroType);
    }
}
