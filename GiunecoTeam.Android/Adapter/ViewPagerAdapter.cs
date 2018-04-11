using System.Collections.Generic;
using System.Linq;
using Android.Support.V4.App;
using Java.Lang;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace GiunecoTeam.Android.Adapter
{
    public class ViewPagerAdapter : FragmentPagerAdapter
    {
        private readonly List<Fragment> _fragmentList;
        private readonly List<string> _fragmentTitleList;

        public ViewPagerAdapter(FragmentManager fm) : base(fm)
        {
            this._fragmentList = new List<Fragment>();
            this._fragmentTitleList = new List<string>();
        }

        public override int Count => this._fragmentList.Count();

        public override Fragment GetItem(int position)
        {
            return this._fragmentList.ElementAt(position);
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new String(this._fragmentTitleList.ElementAt(position));
        }

        public void AddFragmentWithTitle(Fragment fragment, string title)
        {
            this._fragmentList.Add(fragment);
            this._fragmentTitleList.Add(title);
        }
    }
}