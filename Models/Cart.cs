using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcVoyage.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int CityId { get; set; }
        public int Count { get; set; }
        public System.DateTime DataCreated { get; set; }
        public virtual City City { get; set; }

    }
}