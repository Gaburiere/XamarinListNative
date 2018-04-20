using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;
using FFImageLoading.Work;
using GiunecoTeam.Domain.Models;

namespace GiunecoTeam.Android.Adapter
{
    public class GroupsAdapter: RecyclerView.Adapter
    {
        private readonly IEnumerable<Group> _groups;
        private readonly Context _context;

        public event EventHandler<int> ItemClick;

        public GroupsAdapter(IEnumerable<Group> groups, Context context)
        {
            _groups = groups;
            _context = context;
        }

        public override int ItemCount => this._groups.Count();

        public override long GetItemId(int position)
        {
            return this._groups.ElementAt(position).Id;
        }

        public override async void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            try
            {
                var item = this._groups.ElementAt(position);
                var viewHolder = holder as GroupViewHolder;

                if (item.GroupImage == null)
                    await ImageService.Instance.LoadUrl(item.GroupImage).IntoAsync(viewHolder?.GroupImage);
                else
                    await ImageService.Instance.LoadUrl(_groups.ElementAt(position).GroupImage)
                        .ErrorPlaceholder("user.png", ImageSource.CompiledResource)
                        .LoadingPlaceholder("loading.png", ImageSource.CompiledResource)
                        .IntoAsync(viewHolder?.GroupImage);

                
                var layoutManager = new LinearLayoutManager(this._context, LinearLayoutManager.Horizontal, false);
                viewHolder?.GroupMembersRecyclerView.SetLayoutManager(layoutManager);

                var groupMemberAdapter = new GroupMembersAdapter(item.GroupMembers, this._context);
                viewHolder?.GroupMembersRecyclerView.SetAdapter(groupMemberAdapter);

            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.GroupItem, parent, false);

            var viewHolder = new GroupViewHolder(itemView, OnClick);
            return viewHolder;

        }

        private void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }
    }

    public class GroupViewHolder : RecyclerView.ViewHolder
    {
        public ImageViewAsync GroupImage { get; set; }
        public RecyclerView GroupMembersRecyclerView { get; set; }

        public GroupViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            this.GroupImage = itemView.FindViewById<ImageViewAsync>(Resource.Id.groupImage);
            this.GroupMembersRecyclerView = itemView.FindViewById<RecyclerView>(Resource.Id.groupMemberRecyclerView);
            itemView.Click += (sender, e) => listener(base.AdapterPosition);
        }
    }
}