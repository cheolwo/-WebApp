using 수협조합장WebApp.Service;

namespace 수협Common.ViewModel.수협.Login
{
    public class 수협LoginViewModel : WebLoginViewModel
    {
        public 수협LoginViewModel(AuthenticationService authenticationService) 
            : base(authenticationService)
        {
        }
        public override async Task ExecuteLoginCommand()
        {
            await base.ExecuteLoginCommand();
        }
    }

}
