using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services.Utilities
{
    public interface IRecaptchaValidator
    {
        Task<bool> IsCaptchaPassedAsync(string token);
        Task<JObject> GetCaptchaResultDataAsync(string token);
        void UpdateSecretKey(string key);
    }
}