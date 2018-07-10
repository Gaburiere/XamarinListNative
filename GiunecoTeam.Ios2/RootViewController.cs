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
        public RootViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            //if (string.IsNullOrEmpty(CommonSetting.Token))
            //{
            //    var loginViewController = this.Storyboard.InstantiateViewController("Login") as LoginViewController;
            //    if (loginViewController == null)
            //        return;
            //    PresentViewController(loginViewController, true, null);
            //}
            //else
            //{

            //}

            //base.ViewDidAppear(animated);
        }
    }
}