using Synergy.Repository.Database;
using Synergy.Repository.Interfaces;
using Synergy.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Service.Interfaces
{
    public class LoggingService : ILoggingService
    {
        public void LogRequestData(RequestLoggingViewModel request)
        {
            IDbContext _dbContext = new SynergyDbContext();
            var requestLog = _dbContext.Set<ClientRequestLog>();
            try
            {
                requestLog.Add(new ClientRequestLog
                {
                    ClientId = request.ClientId,
                    Payload = request.Payload,
                    RequestMethod = request.RequestMethod,
                    Url = request.Url,
                    RequestReferencId = request.RequestReferencId,
                    RequestUniqueRefernceId = request.RequestUniqueRefernceId,
                    DateLogged = DateTime.UtcNow
                });

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // log.Error(ex, "LogRequestData");
            }
        }

        public void LogResponseData(ResponseLoggingViewModel response)
        {
            IDbContext _dbContext = new SynergyDbContext();
            var responseLog = _dbContext.Set<ClientResponseLog>();
            try
            {
                responseLog.Add(new ClientResponseLog
                {
                    Payload = response.Payload,
                    RequestUniqueRefernceId = response.RequestUniqueRefernceId,
                    HttpStatusCode = response.StatusCode,
                    CadaWadaStatusCode = response.CadawadaStatusCode,
                    DateLogged = DateTime.UtcNow
                });

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                // log.Error(ex, "LogResponseData");
            }
        }
    }
}
