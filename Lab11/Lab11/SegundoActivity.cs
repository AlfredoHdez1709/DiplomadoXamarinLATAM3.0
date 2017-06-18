
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

namespace Lab11
{
    [Activity(Label = "SegundoActivity")]
    public class SegundoActivity : Activity
    {

        protected override void OnStart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnStart");
            base.OnStart();
        }

        protected override void OnResume()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnResume");
            base.OnResume();
        }

        protected override void OnPause()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnPause");
            base.OnPause();
        }
        protected override void OnStop()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnStop");
            base.OnStop();
        }
        protected override void OnDestroy()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnDestroy");
            base.OnDestroy();
        }

        protected override void OnRestart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnRestart");
            base.OnRestart();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Segundo);
        }
    }
}
