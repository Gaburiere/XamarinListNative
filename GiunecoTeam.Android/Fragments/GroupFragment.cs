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

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.GroupFragment, container, false);

            this._groupsRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.groupsRecyclerView);

            this._groups = this.GetGroups().GetAwaiter().GetResult();
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

            return view;
        }

        private async Task<IEnumerable<Group>> GetGroups()
        {
            var groupResource = new GroupsResource();
            var stream = this.Activity.Assets.Open("db.json");
            return await groupResource.LocalGet(stream);
        }
    }
}