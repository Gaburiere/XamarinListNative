using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GiunecoTeam.Android
{
    [Activity(Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true, Label = "Giuneco Team")]
    public class SpashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            LoadActivity();
        }

        private void LoadActivity()
        {
            System.Threading.Thread.Sleep(10000); // Simulate a long loading process on app      
            RunOnUiThread(() => StartActivity(typeof(MainActivity)));
        }
    }
}