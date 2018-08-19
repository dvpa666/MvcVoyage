using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcVoyage.Models
{
    public class City
    {
        public int Id { get; set; }
        public int VoyageTypeId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Country Country { get; set; }
        public VoyageType VoyageType { get; set; }
    }
}