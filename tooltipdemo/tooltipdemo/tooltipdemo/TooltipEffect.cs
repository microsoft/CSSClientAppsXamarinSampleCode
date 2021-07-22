using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace tooltipdemo
{
    public enum TooltipPosition
    {
        Top,
        Bottom,
        Left,
        Right
    }


    public static class TooltipEffect
    {

        public static readonly BindableProperty HasTooltipProperty =
          BindableProperty.CreateAttached("HasTooltip", typeof(bool), typeof(TooltipEffect), false, propertyChanged: OnHasTooltipChanged);
       
        public static readonly BindableProperty TextProperty =
          BindableProperty.CreateAttached("Text", typeof(string), typeof(TooltipEffect), string.Empty);
        public static readonly BindableProperty PositionProperty =
          BindableProperty.CreateAttached("Position", typeof(TooltipPosition), typeof(TooltipEffect), TooltipPosition.Bottom);

        public static bool GetHasTooltip(BindableObject view)
        {
            return (bool)view.GetValue(HasTooltipProperty);
        }

        public static void SetHasTooltip(BindableObject view, bool value)
        {
            view.SetValue(HasTooltipProperty, value);
        }

      
        public static string GetText(BindableObject view)
        {
            return (string)view.GetValue(TextProperty);
        }

        public static void SetText(BindableObject view, string value)
        {
            view.SetValue(TextProperty, value);
        }

        public static TooltipPosition GetPosition(BindableObject view)
        {
            return (TooltipPosition)view.GetValue(PositionProperty);
        }

        public static void SetPosition(BindableObject view, TooltipPosition value)
        {
            view.SetValue(PositionProperty, value);
        }


        static void OnHasTooltipChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
            {
                return;
            }

            bool hasTooltip = (bool)newValue;
            if (hasTooltip)
            {
                view.Effects.Add(new ControlTooltipEffect());
            }
            else
            {
                var toRemove = view.Effects.FirstOrDefault(e => e is ControlTooltipEffect);
                if (toRemove != null)
                {
                    view.Effects.Remove(toRemove);
                }
            }
        }
    }

    class ControlTooltipEffect : RoutingEffect
    {
        public ControlTooltipEffect() : base("CrossGeeks.TooltipEffect")
        {

        }
    }
}
