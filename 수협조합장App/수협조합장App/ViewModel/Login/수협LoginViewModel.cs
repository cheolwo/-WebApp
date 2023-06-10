using Microsoft.JSInterop;
using 계정Common;

namespace 수협Common.ViewModel.수협.Login
{
    public class 수협LoginViewModel : WebLoginViewModel
    {
        public 수협LoginViewModel(수협Actor actor, IJSRuntime jSRuntime) : base(actor, jSRuntime)
        {
        }
        public override async Task ExecuteLoginCommand()
        {
            await base.ExecuteLoginCommand();
        }
    }
    public class 수협Actor : Actor
    {
        public 수협Actor(HttpClient httpClient) : base(httpClient)
        {
        }
    }

}
