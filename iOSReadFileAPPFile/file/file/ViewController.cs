using Foundation;
using System;
using UIKit;

namespace file
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIButton button = new UIButton() {

                Frame = new CoreGraphics.CGRect(10, 100, 200, 80),
                BackgroundColor = UIColor.LightGray,

          };
            button.SetTitle("Click", UIControlState.Normal);
            button.TouchUpInside += Button_TouchUpInside;

            View.AddSubview(button);

            // Perform any additional setup after loading the view, typically from a nib.
        }

        private void Button_TouchUpInside(object sender, EventArgs e)
        {
            string[] strs = {"public.image","public.text", };

            //NSArray arr = NSArray.FromStrings(strs);

            UIDocumentPickerViewController controller = new UIDocumentPickerViewController(strs,UIDocumentPickerMode.Open);


            controller.Delegate = new PickerClass();

            UIApplication.SharedApplication.Windows[0].RootViewController.PresentViewController(controller,true,null);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }


    public class PickerClass : UIDocumentPickerDelegate, IUIDocumentInteractionControllerDelegate
    {
        public override void DidPickDocument(UIDocumentPickerViewController controller, NSUrl url)
        {

            var path = url.AbsoluteString;

        }
    }



}