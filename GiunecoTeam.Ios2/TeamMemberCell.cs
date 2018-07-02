using Foundation;
using System;
using FFImageLoading;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
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
            ImageService.Instance.LoadUrl(teamMember.Images.ImgPic)
                .Transform(new CircleTransformation())
                .DownSample(100, 100)
                .ErrorPlaceholder("user.png", ImageSource.CompiledResource)
                .LoadingPlaceholder("loading.png", ImageSource.CompiledResource).Into(this.Image);
        }
    }
}