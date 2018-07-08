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
    [Register ("GroupMemberViewCell")]
    partial class GroupMemberViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView TeamMemberImage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TeamMemberImage != null) {
                TeamMemberImage.Dispose ();
                TeamMemberImage = null;
            }
        }
    }
}