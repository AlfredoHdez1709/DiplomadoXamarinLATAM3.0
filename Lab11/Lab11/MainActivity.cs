using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab11
{
    [Activity(Label = "Lab11", MainLauncher = true)]
    public class MainActivity : Activity
    {

        protected override void OnStart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnStart");
            base.OnStart();
        }

        protected override void OnResume()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnResume");
            base.OnResume();
        }

        protected override void OnPause()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnPause");
            base.OnPause();
        }
        protected override void OnStop()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnStop");
            base.OnStop();
        }
        protected override void OnDestroy()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnDestroy");
            base.OnDestroy();
        }

        protected override void OnRestart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnRestart");
            base.OnRestart();
        }

        int count = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A -OnCreate");
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var ClickCount = FindViewById<Button>(Resource.Id.ClicCounter);
            ClickCount.Text = Resources.GetString(Resource.String.ClickCounter_text, count);
            ClickCount.Click += (sender, e) =>
            {
                count++;
                ClickCount.Text = Resources.GetString(Resource.String.ClickCounter_text, count);
            };

            FindViewById<Button>(Resource.Id.StartActivity).Click += (sender, e) =>
            {
                var I = new Android.Content.Intent(this, typeof(SegundoActivity));
                StartActivity(I);
            };
        }


        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("CouterValue", count);
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnSaveInstanceState");

            base.OnSaveInstanceState(outState);
        }


    }
}

