using Foundation;
using System;
using GiunecoTeam.Domain.Models;
using UIKit;

namespace GiunecoTeam.Ios2
{
    public partial class TeamMemberCell : UITableViewCell
    {
        public TeamMemberCell (IntPtr handle) : base (handle)
        {
            
        }

        public void UpdateCell(TeamMember teamMember)
        {
            this.Name.Text = teamMember.Fullname;
        }
    }
}