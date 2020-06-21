using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Repository.Models
{
  public    class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryShortCode { get; set; }
        public string DailingCode { get; set; }
        public string CountryImageName { get; set; }
    }
}
