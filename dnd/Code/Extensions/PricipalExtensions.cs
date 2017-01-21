using System.Security.Principal;

namespace dnd.Code.Extensions
{
    public static class PricipalExtensions
    {
        public static bool IsAdmin(this IPrincipal source)
        {
            return source.IsInRole("Admin");
        }
    }
}