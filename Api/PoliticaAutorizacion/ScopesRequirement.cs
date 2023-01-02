using Microsoft.AspNetCore.Authorization;

namespace Api.PoliticaAutorizacion
{
    public class ScopesRequirement : IAuthorizationRequirement
    {
        public readonly string ScopeName;
        public ScopesRequirement(string scopeName)
        {
            ScopeName = scopeName;
        }
    }
}
