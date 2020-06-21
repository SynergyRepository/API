using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synergy_web_api.WebHandler
{
    public class BadRequestErrorResponse
    {
        public string ErrorKey { get; set; }
        public string ErrorMessage { get; set; }
    }
}
