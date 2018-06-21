using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using FFImageLoading;
using FFImageLoading.Transformations;
using FFImageLoading.Views;
using FFImageLoading.Work;
using GiunecoTeam.Domain.Models;
using Debug = System.Diagnostics.Debug;

namespace GiunecoTeam.Android.Adapter
{
    public class GroupMembersAdapter: RecyclerView.Adapter
    {
        private readonly IEnumerable<TeamMember> _groupMembers;
        private readonly Context _context;

        public event EventHandler<int> ItemClick;

        public GroupMembersAdapter(IEnumerable<TeamMember> groupMembers, Context context)
        {
            _groupMembers = groupMembers;
            _context = context;

            this.ItemClick += (sender, position) =>
            {
                var item = this._groupMembers.ElementAt(position);
                var intent = new Intent(this._context, typeof(TeamMemberDetailActivity));
                intent.PutExtra("id", item.Id);
                this._context.StartActivity(intent);
            };
        }

        public override int ItemCount => this._groupMembers.Count();

        public override long GetItemId(int position)
        {
            return this._groupMembers.ElementAt(position).Id;
        }

        public override async void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            try
            {
                var viewHolder = holder as GroupMemberViewHolder;

                if (string.IsNullOrEmpty(_groupMembers.ElementAt(position).Images.ImgPic))
                    await ImageService.Instance.LoadCompiledResource("user.png").IntoAsync(viewHolder?.GroupMemberImage);
                else
                    await ImageService.Instance.LoadUrl(_groupMembers.ElementAt(position).Images.ImgPic)
                        .Transform(new CircleTransformation())
                        .ErrorPlaceholder("user.png", ImageSource.CompiledResource)
                        .LoadingPlaceholder("loading.png", ImageSource.CompiledResource)
                        .IntoAsync(viewHolder?.GroupMemberImage);
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.GroupMemberItem, parent, false);

            var viewHolder = new GroupMemberViewHolder(itemView, OnClick);
            return viewHolder;
        }

        private void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }
    }

    public class GroupMemberViewHolder : RecyclerView.ViewHolder
    {
        public ImageViewAsync GroupMemberImage { get; set; }
        public GroupMemberViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            this.GroupMemberImage = itemView.FindViewById<ImageViewAsync>(Resource.Id.groupMemberImage);
            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}