using CoreGraphics;
using UIKit;

namespace GiunecoTeam.Ios
{
    public sealed class TeamMemberViewCell: UICollectionViewCell
    {
        public UIImageView ImageView;

        public TeamMemberViewCell(CGRect frame): base(frame)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.Orange };

            SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Green };

            ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
            ContentView.Layer.BorderWidth = 2.0f;
            ContentView.BackgroundColor = UIColor.White;
            ContentView.Transform = CGAffineTransform.MakeScale(0.8f, 0.8f);

            ImageView = new UIImageView(UIImage.FromBundle("placeholder.png"))
            {
                Center = ContentView.Center,
                Transform = CGAffineTransform.MakeScale(0.7f, 0.7f)
            };

            ContentView.AddSubview(ImageView);
        }

        public UIImage ContactImage
        {
            set => ImageView.Image = value;
        }
    }
}