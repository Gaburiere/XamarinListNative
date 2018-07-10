using Foundation;
using System;
using GiunecoTeam.Domain;
using GiunecoTeam.Domain.Resources;
using GiunecoTeam.Domain.Resources.Impl;
using UIKit;

namespace GiunecoTeam.Ios2
{
    public partial class RootViewController : UITabBarController
    {
        private IUserResource _userResource;

        public RootViewController (IntPtr handle) : base (handle)
        {
            _userResource = new UserResource();
        }

        public override void ViewDidAppear(bool animated)
        {
            var loginViewController = this.Storyboard.InstantiateViewController("Login") as LoginViewController;
            if (loginViewController == null)
                return;

            this.PresentModalViewController(loginViewController, true);
            base.ViewDidAppear(animated);
        }
    }
}