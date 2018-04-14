using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace GiunecoTeam.Android
{
    [Activity]
    public class TeamMemberDetail: AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.TeamMemberDetail);
        }
    }
}