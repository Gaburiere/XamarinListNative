using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace GiunecoTeam.Ios
{
    public sealed class TabController: UITabBarController
    {
        private UIViewController _team, _group;

        public TabController()
        {
            this.ViewControllers = this.PopulateTabs();
        }

        private UIViewController[] PopulateTabs()
        {
            this._team = new UIViewController
            {
                View = {BackgroundColor = UIColor.FromRGB(175, 44, 43) },
                Title = "Team"
            };

            this._group = new UIViewController()
            {
                View = { BackgroundColor = UIColor.FromRGB(175, 44, 43) },
                Title = "Groups"
            };

            var tabs = new UIViewController[]
            {
                this._team,
                this._group
            };

            return tabs;
        }
    }
}