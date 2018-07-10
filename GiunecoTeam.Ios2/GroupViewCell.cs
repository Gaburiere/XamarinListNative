using Foundation;
using System;
using System.Net;
using FFImageLoading;
using FFImageLoading.Work;
using GiunecoTeam.Domain.Models;
using UIKit;


namespace GiunecoTeam.Ios2
{
    public partial class GroupViewCell : UITableViewCell
    {
        public UIViewController Controller { get; set; }
        private string _address;

        public GroupViewCell (IntPtr handle) : base (handle)
        {
        }

        private void OpenMap()
        {
            var url = $"http://maps.apple.com/?q={_address}";
            var jrURL = new NSUrl(new System.Uri(url).AbsoluteUri);

            if (UIApplication.SharedApplication.CanOpenUrl(jrURL))
            {
                UIApplication.SharedApplication.OpenUrl(jrURL);
            }
            else
            {
                new UIAlertView("Error", "Maps is not supported on this device", null, "Ok").Show();
            }

        }

        public void UpdateCell(Group group)
        {
            _address = group.Address;
            this.GroupImage.UserInteractionEnabled = true;
            this.GroupImage.AddGestureRecognizer(new UITapGestureRecognizer(() => OpenMap()));

            ImageService.Instance.LoadUrl(group.GroupImage)
                .ErrorPlaceholder("user.png", ImageSource.CompiledResource)
                .LoadingPlaceholder("loading.png", ImageSource.CompiledResource)
                .Into(this.GroupImage);
            
            this.GroupsCollectionView.Source = new GroupMemberSource(group.GroupMembers, Controller);
            this.GroupsCollectionView.ReloadData();



        }

    }
}