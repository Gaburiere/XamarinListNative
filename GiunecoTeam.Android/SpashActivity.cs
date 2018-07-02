using System.Threading.Tasks;
using Android.App;
using Android.Media;
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
        private MediaPlayer _player;


        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Splash);
            
            _logoLauncher = this.FindViewById<ImageViewAsync>(Resource.Id.logoLauncher);
            _btn = this.FindViewById<Button>(Resource.Id.btn);

            _player = MediaPlayer.Create(this, null);

            _btn.Click += async (sender, e) =>
            {
                _logoLauncher.StartAnimation(_scaleDownAnimation);
                await Task.Delay(300);
                _logoLauncher.StartAnimation(_scaleDownAnimation);
            };

            this._scaleDownAnimation = new ScaleAnimation
            (
                1f, 1.5f, 1f, 1.5f, Dimension.RelativeToSelf, 0.5f, Dimension.RelativeToSelf, 0.5f
            )
            {
                FillAfter = true,
                Duration = 500
            };

            await ImageService.Instance.LoadCompiledResource("launcher.png")
                .Success(async () => await this.Splash())
                .IntoAsync(_logoLauncher);


            //RunOnUiThread(() => StartActivity(typeof(MainActivity)));
        }

        private Task Splash()
        {
            var animateTask = Task.Run(async () => await Animate());
            var soundTask = Task.Run(async () => await Sound());
        }

        private Task Sound()
        {
            
        }

        private async Task Animate()
        {
            while (true)
            {
                _logoLauncher.StartAnimation(_scaleDownAnimation);
                await Task.Delay(350);
                _logoLauncher.StartAnimation(_scaleDownAnimation);
                await Task.Delay(650);

            }
        }
    }
}