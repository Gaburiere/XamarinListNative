using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GiunecoTeam.Domain;
using GiunecoTeam.Domain.Resources;
using GiunecoTeam.Domain.Resources.Impl;

namespace GiunecoTeam.Android
{
    [Activity(Theme = "@style/SplashTheme")]
    public class LoginActivity : Activity
    {
        private EditText _usernameEditText;
        private EditText _passwordEditText;
        private Button _loginButton;
        private IUserResource _userResource;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.Login);

            _userResource = new UserResource();

            _usernameEditText = this.FindViewById<EditText>(Resource.Id.usernameEditText);
            _passwordEditText = this.FindViewById<EditText>(Resource.Id.passwordEditText);
            _loginButton = this.FindViewById<Button>(Resource.Id.loginButton);

            _loginButton.Click += async (sender, e) => { await this.Login(); };
            // Create your application here

        }

        private async Task Login()
        {
            try
            {
                var username = _usernameEditText.Text;
                var password = _passwordEditText.Text;

                var token = await _userResource.Login(username, password);
                CommonSetting.Token = token;
                this.SetResult(Result.Ok);
                this.Finish();
            }
            catch (Exception e)
            {
                Toast.MakeText(this, e.Message, ToastLength.Short);
            }
        }
    }
}