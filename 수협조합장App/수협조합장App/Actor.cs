using System.Text.Json;
using System.Text;
using AppCommon.DTO;

namespace 계정Common
{
    public interface IActorLoginService
    {
        Task<string> Login(LoginModel model);
    }
    public class Actor : IActorLoginService
    {
        private readonly HttpClient _httpClient;
        public Actor(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> Login(LoginModel model)
        {
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Account/login", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // 로그인 실패
                // 적절한 처리를 수행하거나 예외 처리
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}