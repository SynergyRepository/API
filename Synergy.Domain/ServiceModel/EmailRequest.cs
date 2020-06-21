using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Domain.ServiceModel
{
   public class EmailRequest
    {
        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
