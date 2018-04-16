using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;
using FFImageLoading.Work;
using FFImageLoading.Transformations;
using GiunecoTeam.Domain.Models;

namespace GiunecoTeam.Android.Adapter
{
    public class TeamAdapter : RecyclerView.Adapter
    {
        private readonly IEnumerable<TeamMember> _team;
        private readonly Activity _activity;

        public event EventHandler<int> ItemClick;

        public TeamAdapter(Activity activity, IEnumerable<TeamMember> team)
        {
            this._activity = activity;
            this._team = team;
        }

        public override int ItemCount => this._team.Count();

        public override long GetItemId(int position)
        {
            return this._team.ElementAt(position).Id;
        }

        public override async void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            try
            {
                var viewHolder = holder as TeamMemberViewHolder;

                if (string.IsNullOrEmpty(_team.ElementAt(position).Images.ImgPic))
                    await ImageService.Instance.LoadCompiledResource("user.png").IntoAsync(viewHolder?.ContactImage);
                else
                    await ImageService.Instance.LoadUrl(_team.ElementAt(position).Images.ImgPic)
                        .Transform(new CircleTransformation())
                        .ErrorPlaceholder("user.png", ImageSource.CompiledResource)
                        .LoadingPlaceholder("loading.png", ImageSource.CompiledResource)
                        .IntoAsync(viewHolder?.ContactImage);

                if (viewHolder != null) viewHolder.ContactName.Text = _team.ElementAt(position).Fullname;
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
            }
            
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.TeamItem, parent, false);

            var viewHolder = new TeamMemberViewHolder(itemView, OnClick);
            return viewHolder;
        }

        private void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }
    }

    public class TeamMemberViewHolder : RecyclerView.ViewHolder
    {
        public ImageViewAsync ContactImage { get; }      
        public TextView ContactName { get; }

        public TeamMemberViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            this.ContactName = itemView.FindViewById<TextView>(Resource.Id.fullName);
            this.ContactImage = itemView.FindViewById<ImageViewAsync>(Resource.Id.imagePic);

            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}