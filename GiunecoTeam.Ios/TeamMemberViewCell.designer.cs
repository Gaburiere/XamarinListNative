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

namespace GiunecoTeam.Ios
{
    [Register ("TeamMemberViewCell")]
    partial class TeamMemberViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FullName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Image { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FullName != null) {
                FullName.Dispose ();
                FullName = null;
            }

            if (Image != null) {
                Image.Dispose ();
                Image = null;
            }
        }
    }
}