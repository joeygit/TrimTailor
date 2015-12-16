using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TrimTailor.Models
{
    public class Address
    {

        public string Id { get; set; }

        public DateTime created_at { get; set; }

        [DisplayName("Last Updated At")]
        public DateTime updated_at { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string street { get; set; }
        public string zipcode { get; set; }
        public string label { get; set; }
    }
}