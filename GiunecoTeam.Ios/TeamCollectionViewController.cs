using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CoreFoundation;
using FFImageLoading;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using UIKit;
using Foundation;
using GiunecoTeam.Domain.Models;
using GiunecoTeam.Domain.Resources;
using GiunecoTeam.Domain.Resources.Impl;

namespace GiunecoTeam.Ios
{
    public class TeamCollectionViewController : UICollectionViewController
    {
        private IEnumerable<TeamMember> _team;
        private readonly ITeamResource _teamResource;
        private readonly NSString _teamMemberViewCellId;

        public TeamCollectionViewController(UICollectionViewLayout collectionViewLayout): base (collectionViewLayout)
        {
            _teamResource = new TeamResource();
            _teamMemberViewCellId = new NSString(typeof(TeamMemberViewCell).Name);

            _teamResource.Get().ContinueWith(c => _team = c.Result);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CollectionView.RegisterClassForCell(typeof(TeamMemberViewCell), _teamMemberViewCellId);

        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return _team.Count();
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var teamMemberViewCell = (TeamMemberViewCell)collectionView.DequeueReusableCell(_teamMemberViewCellId, indexPath);

            var team = _team.ElementAt(indexPath.Row);

            ImageService.Instance.LoadUrl(_team.ElementAt(indexPath.Row).Images.ImgPic)
                .Transform(new CircleTransformation())
                .ErrorPlaceholder("user.png", ImageSource.CompiledResource)
                .LoadingPlaceholder("loading.png", ImageSource.CompiledResource)
                .IntoAsync(teamMemberViewCell.ImageView);


            return teamMemberViewCell;
        }

        public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return false;
        }
    }
}