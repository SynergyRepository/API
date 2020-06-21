using Synergy.Domain.ServiceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Domain.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailRequest request);
    }
}
