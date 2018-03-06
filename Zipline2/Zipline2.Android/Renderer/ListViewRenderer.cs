using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Zipline2.CustomControls;
using Zipline2.Droid.Renderer;

[assembly: ExportRenderer(typeof(CustomListView), typeof(AndroidListViewRenderer))]
namespace Zipline2.Droid.Renderer
{
    public class AndroidListViewRenderer : ListViewRenderer
    {
        Context _context;
        public AndroidListViewRenderer(Context context) : base(context)
        {
            _context = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // unsubscribe
                Control.ItemClick -= OnItemClick;
            }

            if (e.NewElement != null)
            {
                // subscribe
                //TODO:  Create a ListViewAdapter....
                //Control.Adapter = new AndroidListViewAdapter(_context as Android.App.Activity, e.NewElement as CustomListView);
                Control.ItemClick += OnItemClick;
            }
        }

        void OnItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            ((CustomListView)Element).NotifyItemSelected(((CustomListView)Element).Items.ToList()[e.Position - 1]);
        }
    }
}