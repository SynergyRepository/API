using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Domain.ServiceModel
{
  public  class HashDetail
    {
        public string Salt { get; set; }
        public string HashedValue { get; set; }
    }
}
