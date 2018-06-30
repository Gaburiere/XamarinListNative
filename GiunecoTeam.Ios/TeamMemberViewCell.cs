using Foundation;
using System;
using FFImageLoading;
using GiunecoTeam.Domain.Models;
using UIKit;

namespace GiunecoTeam.Ios
{
    public partial class TeamMemberViewCell : UICollectionViewCell
    {
        public TeamMemberViewCell (IntPtr handle) : base (handle)
        {
            
        }

        public void UpdateCell(TeamMember teamMember)
        {
            this.FullName.Text = teamMember.Fullname;
            ImageService.Instance.LoadUrl(teamMember.Images.ImgPic).Into(this.Image);
        }
    }
}