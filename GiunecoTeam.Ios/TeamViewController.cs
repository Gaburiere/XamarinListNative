using Foundation;
using System;
using System.Collections.Generic;
using GiunecoTeam.Domain.Models;
using GiunecoTeam.Domain.Resources.Impl;
using UIKit;

namespace GiunecoTeam.Ios
{
    public partial class TeamViewController : UIViewController
    {
        private readonly TeamResource _teamResource;
        private IEnumerable<TeamMember> _team;

        public TeamViewController (IntPtr handle) : base (handle)
        {
            _teamResource = new TeamResource();
        }

        public override void ViewDidLoad()
        {
           _teamResource.Get().ContinueWith(c => _team = c.Result);
            this.TeamTable.Source = new TeamSource(_team, this);
        }
    }
}