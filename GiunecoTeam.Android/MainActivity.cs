using Android.App;
using Android.OS;
using Android.Support.V4.View;
using GiunecoTeam.Android.Adapter;

namespace GiunecoTeam.Android
{
    [Activity(Label = "Giuneco Team", MainLauncher = true, Theme = "@style/CustomTheme")]
    public class MainActivity : Activity
    {
        private ViewPager _viewPager;
        private ViewPagerAdapter _viewPagerAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            this._viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            this._viewPagerAdapter = new ViewPagerAdapter();
        }
    }
}

