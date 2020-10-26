using Synergy.Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Synergy.Service.Interfaces
{
    public interface IUserService
    {
        Task<Response<string>> GetUserProfile(int userId);
    }
}
