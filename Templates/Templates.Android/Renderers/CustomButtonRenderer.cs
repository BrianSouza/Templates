﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Templates.CustomControls;
using Templates.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton),typeof(CustomButtonRenderer))]
namespace Templates.Droid.Renderers
{
        public class CustomButtonRenderer : ButtonRenderer

        {

            private GradientDrawable _gradientBackground;



            public CustomButtonRenderer(Context context) : base(context)

            {

            }



            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)

            {

                base.OnElementChanged(e);



                var view = (CustomButton)Element;

                if (view == null) return;



                Paint(view);

            }

            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)

            {

                base.OnElementPropertyChanged(sender, e);

                if

                   (e.PropertyName == CustomButton.CustomBorderColorProperty.PropertyName ||

                     e.PropertyName == CustomButton.CustomBorderRadiusProperty.PropertyName ||

                     e.PropertyName == CustomButton.CustomBorderWidthProperty.PropertyName)

                {



                    if (Element != null)

                    {

                        Paint((CustomButton)Element);

                    }

                }

            }

            private void Paint(CustomButton view)

            {



                int[] colors = { view.StartColor.ToAndroid(), view.EndColor.ToAndroid() };



                _gradientBackground = new GradientDrawable(

                        GradientDrawable.Orientation.LeftRight, colors);

                _gradientBackground.SetShape(ShapeType.Rectangle);







                // Thickness of the stroke line

                _gradientBackground.SetStroke((int)view.CustomBorderWidth, view.CustomBorderColor.ToAndroid());



                // Radius for the curves

                _gradientBackground.SetCornerRadius(

                    DpToPixels(this.Context, Convert.ToSingle(view.CustomBorderRadius)));



                // set the background of the label

                Control.SetBackground(_gradientBackground);

            }



            public static float DpToPixels(Context context, float valueInDp)

            {

                DisplayMetrics metrics = context.Resources.DisplayMetrics;

                return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);

            }



        }
    
}