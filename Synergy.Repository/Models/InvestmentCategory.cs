using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Repository.Models
{
   public class InvestmentCategory : BaseModel
    {
        public InvestmentCategory()
        {
            SynergyInvestments = new HashSet<SynergyInvestment>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<SynergyInvestment> SynergyInvestments { get; set; }
    }
}
