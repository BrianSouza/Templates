using Android.Content;
using Android.Graphics;
using System;
using Templates.CustomControls;
using Templates.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientFrame),typeof(GradientFrameRenderer))]
namespace Templates.Droid.Renderers
{
    public class GradientFrameRenderer : FrameRenderer
    {
        private Context _context;

        private Xamarin.Forms.Color StartColor { get; set; }

        private Xamarin.Forms.Color EndColor { get; set; }

        private float _cornerRadius { get; set; }

        public GradientFrameRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
        {

            #region for Horizontal Gradient

            var gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0,

            #endregion
                
                   this.StartColor.ToAndroid(),

                   this.EndColor.ToAndroid(),

                   Android.Graphics.Shader.TileMode.Mirror);
            
            var paint = new Android.Graphics.Paint()
            {
                Dither = true
            };

            float rx = _context.ToPixels(_cornerRadius);

            float ry = _context.ToPixels(_cornerRadius);

            var rect = new RectF(0, 0, Width, Height);

            var path = new Path();

            path.AddRoundRect(rect, rx, ry, Path.Direction.Cw);



            paint.StrokeWidth = 5f;  //set outline stroke

            paint.SetShader(gradient);

            canvas.DrawPath(path, paint);

            base.DispatchDraw(canvas);

        }



        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            
            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {

                var stack = e.NewElement as GradientFrame;

                this.StartColor = stack.StartColor;

                this.EndColor = stack.EndColor;

                this._cornerRadius = stack.CornerRadius;
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }

        }
    }
}