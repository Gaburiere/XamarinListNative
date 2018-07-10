using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using GiunecoTeam.Android.Adapter;
using GiunecoTeam.Domain.Models;
using GiunecoTeam.Domain.Resources.Impl;

namespace GiunecoTeam.Android.Fragments
{
    public class GroupFragment : Fragment
    {
        private IEnumerable<Group> _groups;
        private RecyclerView _groupsRecyclerView;
        private RecyclerView.LayoutManager _layoutManager;
        private GroupsAdapter _groupsAdapter;
        private GroupsResource _groupsResource;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.GroupFragment, container, false);

            this._groupsRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.groupsRecyclerView);
            _groupsResource = new GroupsResource();

            //this.GetGroups().ContinueWith(c => this._groups = c.Result);

            //this._groupsAdapter = new GroupsAdapter(this._groups, this.Activity);
            //this._groupsAdapter.ItemClick += (sender, position) =>
            //{
            //    var groupAddress = this._groups.ElementAt(position).Address;
            //    var groupName = this._groups.ElementAt(position).Name;

            //    var geoUri = Uri.Parse($"geo:0,0?q={groupName}+{groupAddress}");


            //    var mapIntent = new Intent(Intent.ActionView, geoUri);
            //    this.StartActivity(Intent.CreateChooser(mapIntent,
            //        "Apri indirizzo con: "));
            //};

            ////Groups
            //this._groupsRecyclerView.SetAdapter(this._groupsAdapter);
            //this._layoutManager = new LinearLayoutManager(this.Activity);
            //this._groupsRecyclerView.SetLayoutManager(_layoutManager);

            return view;
        }

        public override async void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            _groups = await this.GetGroups();

            this._groupsAdapter = new GroupsAdapter(this._groups, this.Activity);
            this._groupsAdapter.ItemClick += (sender, position) =>
            {
                var groupAddress = this._groups.ElementAt(position).Address;
                var groupName = this._groups.ElementAt(position).Name;

                var geoUri = Uri.Parse($"geo:0,0?q={groupName}+{groupAddress}");


                var mapIntent = new Intent(Intent.ActionView, geoUri);
                this.StartActivity(Intent.CreateChooser(mapIntent,
                    "Apri indirizzo con: "));
            };

            //Groups
            this._groupsRecyclerView.SetAdapter(this._groupsAdapter);
            this._layoutManager = new LinearLayoutManager(this.Activity);
            this._groupsRecyclerView.SetLayoutManager(_layoutManager);

        }

        private async Task<IEnumerable<Group>> GetGroups()
        {
            return await _groupsResource.Get();
        }
    }
}