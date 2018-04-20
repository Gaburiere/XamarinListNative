using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;
using FFImageLoading.Work;
using GiunecoTeam.Domain.Resources;
using GiunecoTeam.Domain.Resources.Impl;
using Uri = Android.Net.Uri;

namespace GiunecoTeam.Android
{
    [Activity(Theme = "@style/SplashTheme")]
    public class TeamMemberDetail: AppCompatActivity
    {
        private TextView _name;
        private TextView _role;
        private TextView _email;
        private TextView _bio;
        private ImageViewAsync _image;
        private RelativeLayout _sendMailSection;

        private int _id;

        private ITeamResource _teamResource;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.TeamMemberDetail);
            
            this._teamResource = new TeamResource();

            this._name = this.FindViewById<TextView>(Resource.Id.name);
            this._role = this.FindViewById<TextView>(Resource.Id.role);
            this._email = this.FindViewById<TextView>(Resource.Id.email);
            this._bio = this.FindViewById<TextView>(Resource.Id.bio);
            this._image = this.FindViewById<ImageViewAsync>(Resource.Id.imageFull);
            this._sendMailSection = this.FindViewById<RelativeLayout>(Resource.Id.sendEmailSection);

            this._sendMailSection.Click += (sender, e) =>
            {
                try
                {
                    Intent emailIntent = ComposeEmail();
                    this.StartActivity(Intent.CreateChooser(emailIntent,
                        "Invia email con: "));
                }
                catch (Exception ex)
                {
                   System.Diagnostics.Debug.Fail(ex.Message);
                }
            };


            this._id = Intent.GetIntExtra("id", -1);
            if(this._id == -1)
                throw new Exception("Can't parse id of clicked item!");

            this.SetTeamMember(_id);
        }

        private Intent ComposeEmail()
        {
            var emailIntent = new Intent(Intent.ActionSendto);
            emailIntent.SetData(Uri.Parse("mailto:"));
            emailIntent.PutExtra(Intent.ExtraEmail, new string[] { this._email.Text });
            emailIntent.PutExtra(Intent.ExtraSubject, "Giuneco Team email sample");
            emailIntent.PutExtra(Intent.ExtraText,
                $"Carissimo {this._name.Text}, questa è una email di test per l'evento di formazione.");
            return emailIntent;
        }

        private async void SetTeamMember(int id)
        {
            try
            {
                //todo mettere membro dbstream sulla main activity in modo che se la carichi una volta sola
                var stream = this.Assets.Open("db.json");
                var member = await this._teamResource.LocalGet(stream, id);

                this._name.Text = member.Fullname;
                this._role.Text = member.Role;
                this._email.Text = $"{member.Email}";
                this._bio.Text = member.Bio;

                if (string.IsNullOrEmpty(member.Images.ImgFull))
                    await ImageService.Instance.LoadCompiledResource("user.png").IntoAsync(this._image);
                else
                    await ImageService.Instance.LoadUrl(member.Images.ImgFull)
                        .ErrorPlaceholder("user.png", ImageSource.CompiledResource)
                        .LoadingPlaceholder("loading.png", ImageSource.CompiledResource)
                        .IntoAsync(this._image);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.Message);
            }

        }
    }
}