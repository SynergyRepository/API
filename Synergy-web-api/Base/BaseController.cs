using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Synergy.Service.ApiResponse;
using Synergy.Service.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synergy_web_api.Base
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public string RootPath { get; set; }
        public string TemporaryFileStore { get; set; }
        private readonly IHttpContextAccessor _httpContext;
        private IMemoryCache _memoryCache;
        public long UserIdentity { get; set; }
        public BaseController(IWebHostEnvironment env, IHttpContextAccessor httpContext, IMemoryCache memoryCache)
        {
            _env = env;
            RootPath = _env.ContentRootPath;
            TemporaryFileStore = Path.Combine(RootPath, "FileStore");
            _memoryCache = memoryCache;
            _httpContext = httpContext;

            if (_httpContext.HttpContext.User.Claims.ToList().Find(identity => identity.Type == "id") != null)
            {
                string userId = _httpContext.HttpContext.User.Claims.ToList().Find(identity => identity.Type == "id").Value;
                UserIdentity = Convert.ToInt64(userId);
            }
        }

       

        [NonAction]
        public void SetCacheData<T>(string key, T model)
        {
            _memoryCache.Set(
                key,
                model,
                new MemoryCacheEntryOptions().
                SetAbsoluteExpiration(TimeSpan.FromHours(2)));
        }

        [NonAction]
        public T GetCacheData<T>(string key, T model)
        {
            if (_memoryCache.TryGetValue(key, out model))
                return model;
            else
                return model;
        }
        [NonAction]
        public void DeleteCacheData(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
