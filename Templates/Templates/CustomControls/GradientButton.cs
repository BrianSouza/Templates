
using Xamarin.Forms;

namespace Templates.CustomControls
{
    public class GradientButton : Button
    {
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }

        //public static readonly BindableProperty StartColorProperty =
        //    BindableProperty.Create(nameof(StartColor), typeof(Xamarin.Forms.Color), typeof(GradientButton));

        //public static readonly BindableProperty EndColorProperty =
        //    BindableProperty.Create(nameof(EndColor), typeof(Xamarin.Forms.Color), typeof(GradientButton));
    }
}
