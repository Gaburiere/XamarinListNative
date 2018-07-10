using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Graphics.Drawable;
using Android.Support.V4.View;
using Android.Support.V7.App;
using GiunecoTeam.Android.Adapter;
using GiunecoTeam.Android.Fragments;

namespace GiunecoTeam.Android
{
    [Activity(Label = "Giuneco Team", MainLauncher = true, Theme = "@style/SplashTheme")]
    public class MainActivity : AppCompatActivity
    {
        private ViewPager _viewPager;
        private TabLayout _tabLayout;

        private ViewPagerAdapter _viewPagerAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            // get the viewPager and tabLayout
            this._viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            this._tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);

            // init adapter
            this._viewPagerAdapter = new ViewPagerAdapter(this.SupportFragmentManager);

            this.ShowLogin();
        }

        private void InitTabLayoutAndFragment()
        {
            // add fragments in the adapter
            this.PopulateFragment();

            // set adapter in viewPager
            this._viewPager.Adapter = this._viewPagerAdapter;

            this._tabLayout.SetupWithViewPager(this._viewPager);

            this.SetIcons();
        }

        private void SetIcons()
        {
            //var states = new int[][]
            //{
            //    new int[] {Android.Resource.Attribute.state}, // tab focused
            //    new int[] {Android.Resource.Attribute.StateEnabled} // tab unfocused
            //};
            var tabIconColorsId = Resource.Drawable.tab_icon_color;
            var tabIconColors = Resources.GetColorStateList(tabIconColorsId);

            var teamTab = _tabLayout.GetTabAt(0).SetIcon(Resource.Drawable.teamIco);

            var teamIconWrap = DrawableCompat.Wrap(teamTab.Icon);
            DrawableCompat.SetTintList(teamIconWrap, tabIconColors);

            var groupTab = _tabLayout.GetTabAt(1).SetIcon(Resource.Drawable.groupIco);
            var groupIconWrap = DrawableCompat.Wrap(groupTab.Icon);
            DrawableCompat.SetTintList(groupIconWrap, tabIconColors);
        }

        private void ShowLogin()
        {
            var login = new Intent(this, typeof(LoginActivity));
            this.StartActivityForResult(login, 666);
        }

        private void PopulateFragment()
        {
            var groupFragment = new GroupFragment();
            var teamFragment = new TeamFragment();

            this._viewPagerAdapter.AddFragmentWithTitle(teamFragment, "Team");
            this._viewPagerAdapter.AddFragmentWithTitle(groupFragment, "Groups");

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == 666)
            {
                if (resultCode == Result.Ok)
                {
                    this.InitTabLayoutAndFragment();
                }
            }

            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}

