using Foundation;
using System;
using GiunecoTeam.Domain.Resources;
using GiunecoTeam.Domain.Resources.Impl;
using UIKit;

namespace GiunecoTeam.Ios
{
    public partial class TeamCollectionViewController : UIViewController
    {
        private ITeamResource _teamResource;

        public TeamCollectionViewController (IntPtr handle) : base (handle)
        {
            _teamResource = new TeamResource();
        }

        public override void ViewDidLoad()
        {
        }
    }
}