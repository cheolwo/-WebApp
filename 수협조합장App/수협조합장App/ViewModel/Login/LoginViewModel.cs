using AppCommon.DTO;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.JSInterop;
using 계정Common;

namespace 수협Common.ViewModel.수협.Login
{
    public class LoginViewModel : ObservableObject
    {
        private readonly Actor _actor;
        private LoginModel _loginModel;
        protected string Token = "";
        private bool _isLogin;
        public bool IsLogin
        {
            get => _isLogin;
            set => _isLogin = value;
        }
        public string Username
        {
            get => _loginModel.Username;
            set => _loginModel.Username = value;
        }

        public string Password
        {
            get => _loginModel.Password;
            set => _loginModel.Password = value;
        }

        public bool RememberMe
        {
            get => _loginModel.RememberMe;
            set => _loginModel.RememberMe = value;
        }

        //private bool CanExecuteLoginCommand() =>
        //    !string.IsNullOrEmpty(_loginModel.Username) && !string.IsNullOrEmpty(_loginModel.Password);
        public LoginViewModel(Actor actor)
        {
            _actor = actor;
            //LoginCommand = new AsyncRelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            _loginModel = new LoginModel();
        }
        public virtual async Task ExecuteLoginCommand()
        {
            Token = await _actor.Login(_loginModel);
        }
    }
    public class WebLoginViewModel : LoginViewModel
    {
        private readonly IJSRuntime _jsRuntime;

        public WebLoginViewModel(Actor actor, IJSRuntime jSRuntime) : base(actor)
        {
            _jsRuntime = jSRuntime;
        }
        public override async Task ExecuteLoginCommand()
        {
            await base.ExecuteLoginCommand();
            if (Token != null)
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "token", Token);
                IsLogin = true;
            }
        }
    }
}
