using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Views.Animations;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;

namespace GiunecoTeam.Android
{
    [Activity(Theme = "@style/CustomTheme", MainLauncher = true, NoHistory = true, Label = "Giuneco Team")]
    public class SpashActivity : Activity
    {
        private Animation _scaleDownAnimation;
        private Animation _scaleUpAnimation;
        private ImageViewAsync _logoLauncher;
        private Button _btn;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Splash);
            
            _logoLauncher = this.FindViewById<ImageViewAsync>(Resource.Id.logoLauncher);
            _btn = this.FindViewById<Button>(Resource.Id.btn);

            _btn.Click += async (sender, e) =>
            {
                _logoLauncher.StartAnimation(_scaleDownAnimation);
                await Task.Delay(300);
                _logoLauncher.StartAnimation(_scaleDownAnimation);
            };

            ImageService.Instance.LoadCompiledResource("launcher.png").Into(_logoLauncher);

            this._scaleDownAnimation = new ScaleAnimation
            (
                1f, 1.5f, 1f, 1.5f, Dimension.RelativeToSelf, 0.5f, Dimension.RelativeToSelf, 0.5f
            )
            {
                FillAfter = true,
                Duration = 500
            };

            //Animate();

            //RunOnUiThread(() => StartActivity(typeof(MainActivity)));
        }

        private void Animate()
        {
            _logoLauncher.StartAnimation(_scaleDownAnimation);
            System.Threading.Thread.Sleep(10000); // Simulate a long loading process on app      


        }
    }
}