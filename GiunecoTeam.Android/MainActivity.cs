using Android.App;
using Android.OS;
using GiunecoTeam.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Support.V7.Widget;
using GiunecoTeam.Android.Adapter;
using GiunecoTeam.Domain.Resources.Impl;

namespace GiunecoTeam.Android
{
    [Activity(Label = "Giuneco Team", MainLauncher = true, Theme = "@style/CustomTheme")]
    public class MainActivity : Activity
    {
        private RecyclerView _teamRecyclerView;
        private RecyclerView.LayoutManager _layoutManager;
        private TeamAdapter _teamAdapter;
        private IEnumerable<TeamMember> _team;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this._team = await this.GetTeam();
            this._teamAdapter = new TeamAdapter(this, this._team);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            this._teamRecyclerView = FindViewById<RecyclerView>(Resource.Id.teamRecyclerView);

            this._teamRecyclerView.SetAdapter(this._teamAdapter);
            this._layoutManager = new LinearLayoutManager(this);
            this._teamRecyclerView.SetLayoutManager(_layoutManager);
        }

        private async Task<IEnumerable<TeamMember>> GetTeam()
        {
            var teamResource = new TeamResource();

            var stream = Assets.Open("db.json");
            return await teamResource.LocalGet(stream);
        }
    }
}

