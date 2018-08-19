using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcVoyage.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<VoyageEntities>
    {
        protected override void Seed(VoyageEntities context)
        {
            var countries = new List<Country>
            {
                new Country { Name = "Azja" },
                new Country { Name = "Europa" },
                new Country { Name = "Australia" },
                new Country { Name = "Ameryka Północna" },
                new Country { Name = "Ameryka Południowa" }
            };

            var vtypes = new List<VoyageType>
            {
                new VoyageType { Name = "Treking" },
                new VoyageType { Name = "Rower" },
                new VoyageType { Name = "Wspinaczka" }    
            };

            new List<City>
            {
                new City { Name = "Słowacja", Price = 100, Description ="wspaniały wypad z przyjaciółkami",Country = countries.Single(g => g.Name == "Europa"), VoyageType = vtypes.Single(a => a.Name == "Treking")},
                new City { Name = "Polska", Price = 233.9M, Description = "pocałujcie mnie wszyscy w dupe",Country = countries.Single(g => g.Name == "Europa"), VoyageType = vtypes.Single(a => a.Name == "Wspinaczka")},
                 new City { Name = "Gruzja", Price = 5500.4M, Description = "Kazbek",Country = countries.Single(g => g.Name == "Azja"), VoyageType = vtypes.Single(a => a.Name == "Rower")},
                  new City { Name = "Brazylia", Price = 500, Description = "Swiątynie",Country = countries.Single(g => g.Name == "Ameryka Południowa"), VoyageType = vtypes.Single(a => a.Name == "Wspinaczka")},


            }.ForEach(a => context.Cities.Add(a));
        }

       
    }
}