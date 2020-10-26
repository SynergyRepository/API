using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Repository.Models
{
  public  class BaseModel
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
