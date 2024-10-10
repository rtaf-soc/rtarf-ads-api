using Microsoft.IdentityModel.Tokens;

namespace Its.Ads.Api.Authentications
{
    public interface IJwtSigner
    {
        public SecurityKey GetSignedKey(string? url);
    }
}
