using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Repository.Models
{
  public  class SynergyInvestment : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public decimal InterestRate { get; set; }
        public int Duration { get; set; }
        public int AvailableSlot { get; set; }
        public int SoldOutSlot { get; set; }
        public string Location { get; set; }
        public int CatergoryId { get; set; }
        public InvestmentCategory InvestmentCategory { get; set; }
    }
}
