using Foundation;
using System;
using System.Threading.Tasks;
using GiunecoTeam.Domain;
using GiunecoTeam.Domain.Resources;
using GiunecoTeam.Domain.Resources.Impl;
using UIKit;

namespace GiunecoTeam.Ios2
{
    public partial class LoginViewController : UIViewController
    {
        private readonly IUserResource _userResource;
        public event EventHandler OnLoginSuccess;

        public LoginViewController (IntPtr handle) : base (handle)
        {
            _userResource = new UserResource();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.Password.ShouldReturn += (textField) => {
                textField.ResignFirstResponder();
                return true;
            };

            this.LoginButton.AddGestureRecognizer(new UITapGestureRecognizer(async () => await this.Login()));
        }

        private async Task Login()
        {
            try
            {
                var username = this.Username.Text;
                var password = this.Password.Text;

                var token = await _userResource.Login(username, password);
                CommonSetting.Token = token;

                OnLoginSuccess?.Invoke(this, null);
                //this.DismissViewController(true, null);
            }
            catch (Exception e)
            {
                var _error = new UIAlertView("Error", e.Message, null, "Ok", null);

                _error.Show();
            }

        }
    }
}