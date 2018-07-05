using Foundation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GiunecoTeam.Domain.Models;
using GiunecoTeam.Domain.Resources.Impl;
using UIKit;

namespace GiunecoTeam.Ios2
{
    public partial class GroupsViewController : UITableViewController
    {
        private readonly GroupsResource _groupsResource;
        private IEnumerable<Group> _groups;

        public GroupsViewController (IntPtr handle, GroupsResource groupsResource) : base (handle)
        {
            _groupsResource = groupsResource;
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            _groups = await this.GetGroups();
            this.TableView.Source = new GroupSource(_groups, this);
            TableView.ReloadData();

        }

        private Task<IEnumerable<Group>> GetGroups()
        {
            return _groupsResource.Get();
        }
    }
}