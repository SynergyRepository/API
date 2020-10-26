using Synergy.Service.ValidationExtension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Synergy.Service.ViewModel
{
   public class InvestmentVeiwModel
    {
        [Required]
        [Data(DataToCheck = "string", ErrorMessage = "Invalid {0}")]
        public string Title { get; set; }
        [Required]
        [Data(DataToCheck = "string", ErrorMessage = "Invalid {0}")]
        public string Description { get; set; }
        [Required]
        [Data(DataToCheck = "string", ErrorMessage = "Invalid {0}")]
        public decimal InterestRate { get; set; }
        public int Duration { get; set; }
        public int AvailableSlots { get; set; }
        [Required]
        [Data(DataToCheck = "string", ErrorMessage = "Invalid {0}")]
        public string Location { get; set; }
        [Required]
        [Data(DataToCheck = "string", ErrorMessage = "Invalid {0}")]
        public string Thumbnail { get; set; }
    }
}
