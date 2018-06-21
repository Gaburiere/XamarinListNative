using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using GiunecoTeam.Android.Adapter;
using GiunecoTeam.Android.Fragments;

namespace GiunecoTeam.Android
{
    [Activity(Theme = "@style/MainTheme")]
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
            // add fragments in the adapter
            this.PopulateFragment();

            // set adapter in viewPager
            this._viewPager.Adapter = this._viewPagerAdapter;

            this._tabLayout.SetupWithViewPager(this._viewPager);
        }

        private void PopulateFragment()
        {
            var groupFragment = new GroupFragment();
            var teamFragment = new TeamFragment();

            this._viewPagerAdapter.AddFragmentWithTitle(teamFragment, "Team");
            this._viewPagerAdapter.AddFragmentWithTitle(groupFragment, "Groups");

        }
    }
}

