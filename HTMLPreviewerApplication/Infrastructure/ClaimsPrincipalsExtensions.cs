namespace HTMLPreviewerApplication.Infrastructure
{
    using System.Security.Claims;

    public static class ClaimsPrincipalsExtensions
    {
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
