using System;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using GiunecoTeam.Domain.Models;

namespace GiunecoTeam.Android.Adapter
{
    public class GroupsAdapter: RecyclerView.Adapter
    {
        private readonly IEnumerable<Group> _groups;

        public event EventHandler<int> ItemClick;

        public GroupsAdapter(IEnumerable<Group> groups)
        {
            _groups = groups;
        }

        public override int ItemCount => this._groups.Count();

        public override long GetItemId(int position)
        {
            return this._groups.ElementAt(position).Id;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            throw new System.NotImplementedException();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            throw new System.NotImplementedException();
        }

        private void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }
    }
}