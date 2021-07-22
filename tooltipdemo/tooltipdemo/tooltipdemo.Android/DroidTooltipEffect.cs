using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Tomergoldst.Tooltips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tooltipdemo;
using tooltipdemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Com.Tomergoldst.Tooltips.ToolTipsManager;

[assembly: ResolutionGroupName("CrossGeeks")]
[assembly: ExportEffect(typeof(DroidTooltipEffect), nameof(TooltipEffect))]
namespace tooltipdemo.Droid
{
    public class DroidTooltipEffect : PlatformEffect
    {
        ToolTip toolTipView;
        ToolTipsManager _toolTipsManager;
        ITipListener listener;

        public DroidTooltipEffect()
        {
            listener = new TipListener();
            _toolTipsManager = new ToolTipsManager(listener);
        }

        void OnTap(object sender, EventArgs e)
        {
            var control = Control ?? Container;
            var text = TooltipEffect.GetText(Element);

            if (!string.IsNullOrEmpty(text))
            {
                ToolTip.Builder builder;
                var parentContent = control.RootView;

                var position = TooltipEffect.GetPosition(Element);
                switch (position)
                {
                    case TooltipPosition.Top:
                        builder = new ToolTip.Builder(control.Context, control, parentContent as ViewGroup, text.PadRight(80, ' '), ToolTip.PositionAbove);
                        break;
                    case TooltipPosition.Left:
                        builder = new ToolTip.Builder(control.Context, control, parentContent as ViewGroup, text.PadRight(80, ' '), ToolTip.PositionLeftTo);
                        break;
                    case TooltipPosition.Right:
                        builder = new ToolTip.Builder(control.Context, control, parentContent as ViewGroup, text.PadRight(80, ' '), ToolTip.PositionRightTo);
                        break;
                    default:
                        builder = new ToolTip.Builder(control.Context, control, parentContent as ViewGroup, text.PadRight(80, ' '), ToolTip.PositionBelow);
                        break;
                }

                builder.SetAlign(ToolTip.AlignLeft);          
                toolTipView = builder.Build();

                _toolTipsManager?.Show(toolTipView);
            }
        }


        protected override void OnAttached()
        {
            var control = Control ?? Container;
            control.LongClick += OnTap;
            control.Click += HideTooltip;
        }

        private void HideTooltip(object sender, EventArgs e)
        {
            var control = Control ?? Container;
            _toolTipsManager.FindAndDismiss(control);
        }

        protected override void OnDetached()
        {
            var control = Control ?? Container;
            control.LongClick -= OnTap;
            control.Click -= OnTap;
            _toolTipsManager.FindAndDismiss(control);
        }

        class TipListener : Java.Lang.Object, ITipListener
        {
            public void OnTipDismissed(Android.Views.View p0, int p1, bool p2)
            {

            }
        }
    }
}