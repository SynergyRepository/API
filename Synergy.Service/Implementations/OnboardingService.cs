using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Synergy.Domain.Interfaces;
using Synergy.Repository.Interfaces;
using Synergy.Repository.Models;
using Synergy.Service.ApiResponse;
using Synergy.Service.Interfaces;
using Synergy.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Synergy.Domain.ServiceModel;
using Synergy.Service.Constants;

namespace Synergy.Service.Implementations
{
    public class OnboardingService : BaseService, IOnboardingService
    {
        
        public OnboardingService(IHostingEnvironment evn, ICryptographyService cryptographyService, IEmailService emailService, IConfiguration config, IDbContext dbContext) : base(evn, cryptographyService, emailService, config, dbContext)
        {
        }

        public async Task<Response<string>> UserSignOn(RegisterUserViewmodel request)
        {
            var customweAccountContext = _dbContext.Set<CustomerAccount>();
            try
            {
                bool isUserExist = customweAccountContext.Any(a => a.PhoneNumber.Equals(request.PhoneNumber) || a.EmailAddress.Equals(request.EmailAddress,StringComparison.OrdinalIgnoreCase));

                if (isUserExist)
                    return new Response<string>
                    {
                        Status = Enums.ResponseStatus.Conflict,
                        ErrorData = new ErrorResponse<string>
                        {
                            Data = $"Either {request.EmailAddress} or {request.PhoneNumber} already exist"

                        }
                    };

                HashDetail encryptPassword = cryptographyService.GenerateHash(request.Password);
                customweAccountContext.Add(new CustomerAccount
                {
                    CountryId = request.CountryId,
                    DailingCode = request.DailingCode,
                    EmailAddress = request.EmailAddress,
                    FirstName = request.Firstname,
                    LastName = request.Lastname,
                    Password = encryptPassword.HashedValue,
                    PasswordKey = encryptPassword.Salt,
                    isEmailVerified = false,
                    PhoneNumber  = request.PhoneNumber,
                });

                _dbContext.SaveChanges();


                return new Response<string>
                {
                    Status = Enums.ResponseStatus.Success,
                    SuccessData = new SuccessResponse<string>
                    {
                        Data = "Account Created successfully, kindly check your email to verify your account",
                        ResponseCode = SuccessCode.DEFAULT_SUCCESS_CODE,
                        ResponseMessage = "",
                    }
                };
            }
            catch (Exception ex)
            {

                log.Error(ex, "SendSMSVericationService");
                return new Response<string>
                {
                    Status = Enums.ResponseStatus.ServerError,
                    ErrorData = new ErrorResponse<string>
                    {
                        Data = "Error retrieving data, try again",
                        ResponseCode = ErrorCode.INTERNAL_SERVER_ERROR,
                        ResponseMessage = "",
                    }
                };
            }
        }
    }

}
