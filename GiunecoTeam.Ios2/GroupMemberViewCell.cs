using Foundation;
using System;
using FFImageLoading;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using GiunecoTeam.Domain.Models;
using UIKit;

namespace GiunecoTeam.Ios2
{
    public partial class GroupMemberViewCell : UICollectionViewCell
    {
        public GroupMemberViewCell (IntPtr handle) : base (handle)
        {
        }

        public void UpdateCell(TeamMember teamMember)
        {
            ImageService.Instance.LoadUrl(teamMember.Images.ImgPic)
                .Transform(new CircleTransformation())
                .ErrorPlaceholder("user.png", ImageSource.CompiledResource)
                .LoadingPlaceholder("loading.png", ImageSource.CompiledResource).Into(this.TeamMemberImage);
        }
    }
}