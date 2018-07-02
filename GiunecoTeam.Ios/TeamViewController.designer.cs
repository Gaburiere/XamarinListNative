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
    [Register ("TeamViewController")]
    partial class TeamViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TeamTable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TeamTable != null) {
                TeamTable.Dispose ();
                TeamTable = null;
            }
        }
    }
}