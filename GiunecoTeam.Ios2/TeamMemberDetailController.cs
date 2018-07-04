using Foundation;
using System;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Work;
using GiunecoTeam.Domain.Models;
using GiunecoTeam.Domain.Resources;
using GiunecoTeam.Domain.Resources.Impl;
using MessageUI;
using UIKit;

namespace GiunecoTeam.Ios2
{
    public partial class TeamMemberDetailController : UIViewController
    {
        private int _id;
        private readonly ITeamResource _teamResource;
        private MFMailComposeViewController _mailController;

        public TeamMemberDetailController (IntPtr handle) : base (handle)
        {
            _teamResource = new TeamResource();
            
        }

        private void ComposeEmail()
        {
            var email = this.Email.Text;
            var subject = "Giuneco Team mail sample";
            var body = "questa è una email di test per l'evento di formazione.";
            //using (var encoded = new NSString($"mailto:{email}?subject={subject}&body={body}").CreateStringByAddingPercentEscapes(NSStringEncoding.UTF8))
            //using (var url = NSUrl.FromString(encoded))
            //{
            //    UIApplication.SharedApplication.OpenUrl(url);
            //}

            if (!MFMailComposeViewController.CanSendMail)
            {
                var _error = new UIAlertView("Error", "Sending email is not supporter on this device", null, "OK", null);
                _error.Show();
                return;
            }

            _mailController = new MFMailComposeViewController();
            _mailController.SetToRecipients(new string[] { email });
            _mailController.SetSubject(subject);
            _mailController.SetMessageBody(body, false);

            _mailController.Finished += (object s, MFComposeResultEventArgs args) => {
                Console.WriteLine(args.Result.ToString());
                args.Controller.DismissViewController(true, null);
            };

            this.PresentViewController(_mailController, true, null);
        }

        public override async void ViewDidLoad()
        {
            var member = await this.GetTeamMember(_id);
            SetTeamMember(member);
            this.Email.AddGestureRecognizer(new UITapGestureRecognizer(() => ComposeEmail()));
            base.ViewDidLoad();
        }

        private void SetTeamMember(TeamMember member)
        {
            ImageService.Instance.LoadUrl(member.Images.ImgFull)
                .ErrorPlaceholder("user.png", ImageSource.CompiledResource)
                .LoadingPlaceholder("loading.png", ImageSource.CompiledResource)
                .Into(this.Image);

            this.Name.Text = member.Fullname;
            this.Role.Text = member.Role;
            this.Email.Text = member.Email;
            this.Bio.Text = member.Bio;
        }

        private async Task<TeamMember> GetTeamMember(int id)
        {
            return await _teamResource.Get(id);
        }

        public void InitTeamMember(int teamMemberId)
        {
            _id = teamMemberId;
        }
    }
}