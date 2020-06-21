using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NLog;
using Synergy.Domain.Interfaces;
using Synergy.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Service.Implementations
{
   public class BaseService
    {
        public IHostingEnvironment _evn;
        public readonly ICryptographyService cryptographyService;
        public readonly IEmailService emailService;
       // public readonly ISMSService SmsService;
        public static Logger log = LogManager.GetCurrentClassLogger();
        public const int SqlServerViolationOfUniqueIndex = 2601;
        public const int SqlServerViolationOfUniqueConstraint = 2627;
        public readonly IConfiguration _config;
        public readonly IDbContext _dbContext;
        public string uploadextension;
        public string CurrencyFolder;
        public int OtpTimerValue;
        public readonly string webUrl = "BaseEndpoint";
        public readonly string logoPath;
        public readonly string clientKeyPrefix;
        public readonly string kycNotificationResponseEmail;
        public string ContentPath { get; set; }

        //private readonly IOptions<ApplicationResourcesProvider> _applicationResourcesProvider;
        // private readonly IOptions<CloudinaryAccount> _cloudinaryAccount;
        // public ApplicationResourcesProvider ApplicationResourcesProvider { get; set; }
        // public CloudinaryAccount CloudinaryConfiguration { get; set; }

        public BaseService(IHostingEnvironment evn, ICryptographyService cryptographyService, IEmailService emailService, IConfiguration config, IDbContext dbContext)
        {
            _evn = evn;
            ContentPath = _evn.ContentRootPath;
            this.cryptographyService = cryptographyService;
            this.emailService = emailService;
            _config = config;
            _dbContext = dbContext;
            uploadextension = config["UploadExtensions"];
            CurrencyFolder = config["UploadFolder:Currency"];
            OtpTimerValue = int.Parse(config["OtpSetting:OtpExpiry"]);
            logoPath = config["cadawadaLogo:LogoPath"];
            clientKeyPrefix = config["ClientCredentials:ClientKeyPrefix"];
            kycNotificationResponseEmail = config["KycNotification:To"];

           // _applicationResourcesProvider = applicationResourcesProvider;
          //  ApplicationResourcesProvider = _applicationResourcesProvider.Value;

           // _cloudinaryAccount = cloudinaryAccount;
           // CloudinaryConfiguration = _cloudinaryAccount.Value;
        }
    }
}
