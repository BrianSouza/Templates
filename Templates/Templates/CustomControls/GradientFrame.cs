
using Xamarin.Forms;

namespace Templates.CustomControls
{
    public class GradientFrame : Frame
    {
        public static readonly BindableProperty StartColorProperty =
            BindableProperty.Create("StartColor", typeof(Xamarin.Forms.Color), typeof(GradientFrame));

        public static readonly BindableProperty EndColorProperty =
            BindableProperty.Create("EndColor", typeof(Xamarin.Forms.Color), typeof(GradientFrame));
        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }

        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty); }
            set { SetValue(EndColorProperty, value); }
        }
    }
}
