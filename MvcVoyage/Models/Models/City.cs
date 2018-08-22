using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcVoyage.Models
{
    public class City
    {
        public int Id { get; set; }
        [DisplayName("VoyageType")]
        public int VoyageTypeId { get; set; }
        [DisplayName("Country")]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Country Country { get; set; }
        public VoyageType VoyageType { get; set; }
    }
}