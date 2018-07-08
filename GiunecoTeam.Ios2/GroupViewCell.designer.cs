// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace GiunecoTeam.Ios2
{
    [Register ("GroupViewCell")]
    partial class GroupViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView GroupImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView GroupsCollectionView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (GroupImage != null) {
                GroupImage.Dispose ();
                GroupImage = null;
            }

            if (GroupsCollectionView != null) {
                GroupsCollectionView.Dispose ();
                GroupsCollectionView = null;
            }
        }
    }
}