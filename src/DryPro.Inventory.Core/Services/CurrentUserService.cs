using DryPro.Inventory.Core.Services.Base;
using Microsoft.AspNetCore.Http;

namespace DryPro.Inventory.Core.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId { get { return _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApp"; } }
    }
}