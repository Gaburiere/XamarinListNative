﻿using Android.OS;
using Android.Views;
using Android.Support.V4.App;

namespace GiunecoTeam.Android.Fragments
{
    public class GroupFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.GroupFragment, container, false);


            return view;
        }
    }
}