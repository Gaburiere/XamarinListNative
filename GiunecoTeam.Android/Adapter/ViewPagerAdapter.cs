using System.Collections.Generic;
using System.Linq;
using Android.Support.V4.App;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace GiunecoTeam.Android.Adapter
{
    public class ViewPagerAdapter : FragmentPagerAdapter
    {
        private readonly IEnumerable<Fragment> _fragmentList;

        public ViewPagerAdapter(FragmentManager fm, IEnumerable<Fragment> fragmentList) : base(fm)
        {
            this._fragmentList = fragmentList;
        }

        public override int Count => this._fragmentList.Count();

        public override Fragment GetItem(int position)
        {
            return this._fragmentList.ElementAt(position);
        }
    }
}