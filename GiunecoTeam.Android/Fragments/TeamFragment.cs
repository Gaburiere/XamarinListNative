using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using GiunecoTeam.Android.Adapter;
using GiunecoTeam.Domain.Models;
using GiunecoTeam.Domain.Resources;
using GiunecoTeam.Domain.Resources.Impl;

namespace GiunecoTeam.Android.Fragments
{
    public class TeamFragment: Fragment
    {
        private RecyclerView _teamRecyclerView;
        private RecyclerView.LayoutManager _layoutManager;
        private TeamAdapter _teamAdapter;
        private IEnumerable<TeamMember> _team;
        private ITeamResource _teamResource;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.TeamFragment, container, false);

            this._teamRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.teamRecyclerView);
            _teamResource = new TeamResource();

            this._team = this.GetTeam().ConfigureAwait(false).GetAwaiter().GetResult();

            //this.GetTeam().ContinueWith(c => _team = c.Result);

            this._teamAdapter = new TeamAdapter(this.Activity, this._team);
            this._teamAdapter.ItemClick += (sender, position) =>
            {
                var intent = new Intent(this.Activity, typeof(TeamMemberDetail));
                intent.PutExtra("id", position + 1);
                this.Activity.StartActivity(intent);
            };

            this._teamRecyclerView.SetAdapter(this._teamAdapter);
            this._layoutManager = new LinearLayoutManager(this.Activity);
            this._teamRecyclerView.SetLayoutManager(_layoutManager);

            return view;
        }

        private async Task<IEnumerable<TeamMember>> GetTeam()
        {
            var stream = this.Activity.Assets.Open("db.json");
            return await _teamResource.LocalGet(stream);

            //return await _teamResource.Get();
        }

    }
}