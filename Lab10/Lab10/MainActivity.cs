using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab10
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {

        int Counter = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var ContentHeader = FindViewById<TextView>(Resource.Id.ContenrHeader);
            ContentHeader.Text = GetText(Resource.String.ContentHeader);
            var ClickConter = FindViewById<TextView>(Resource.Id.ClickContenr);
            var ClickMe = FindViewById<Button>(Resource.Id.btn);
            ClickMe.Click += (s, e) =>
             {

                 var i = new Android.Content.Intent(this, typeof(ValidateActivity));
                 StartActivity(i);


                 Counter++;
                 ClickConter.Text = Resources.GetQuantityString(Resource.Plurals.numberOfClick, Counter, Counter);
                 var player = Android.Media.MediaPlayer.Create(this, Resource.Raw.sound);
                 player.Start();




             };

            Android.Content.Res.AssetManager Manager = this.Assets;
            using (var Reader = new System.IO.StreamReader(Manager.Open("Contenido.txt")))
            {
                ContentHeader.Text += $"\n \n {Reader.ReadToEnd()}";
            }

        }
    }
}

