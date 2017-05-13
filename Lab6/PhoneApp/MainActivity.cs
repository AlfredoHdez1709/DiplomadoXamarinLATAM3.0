using Android.App;
using Android.Widget;
using Android.OS;

namespace PhoneApp
{
    [Activity(Label = "Phone App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        static readonly System.Collections.Generic.List<string> PhoneNumbers = new System.Collections.Generic.List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

          
            var PhoneNumber = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            var TranslateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            var CallButton = FindViewById<Button>(Resource.Id.CallButton);
            var CallHistorybutton = FindViewById<Button>(Resource.Id.CallHistoryButton);
            var Validatebutton = FindViewById<Button>(Resource.Id.ValidateButton);
            CallButton.Enabled = false;



            var TranslatedNumber = string.Empty;


            Validatebutton.Click += (sender, e) =>
            {
                var i = new Android.Content.Intent(this, typeof (ValidationClass));
                StartActivity(i);
            };

            CallHistorybutton.Click += (sender, e) =>
             {
                 var i = new Android.Content.Intent(this, typeof(CallHistoryActivity));
                 i.PutStringArrayListExtra("phone_numbers", PhoneNumbers);
                 StartActivity(i);
             };

            TranslateButton.Click += (object sender, System.EventArgs e) =>
            {
                var Translator = new PhoneTranslator();
                TranslatedNumber = Translator.ToNumber(PhoneNumber.Text);

                if (string.IsNullOrWhiteSpace(TranslatedNumber))
                {
                    CallButton.Text = "Llamar";
                    CallButton.Enabled = false;
                }
                else
                {
                    CallButton.Text = $"Llamar al {TranslatedNumber}";
                    CallButton.Enabled = true;
                }
            };


            CallButton.Click += (object sender, System.EventArgs e) =>
            {

                var CallDialog = new AlertDialog.Builder(this);
                CallDialog.SetMessage($"Llamar al numero {TranslatedNumber}?");
                CallDialog.SetNeutralButton("Llamar", delegate
                {
                    PhoneNumbers.Add(TranslatedNumber);
                    CallHistorybutton.Enabled = true;

                    var CallI = new Android.Content.Intent(Android.Content.Intent.ActionCall);
                    CallI.SetData(Android.Net.Uri.Parse($"tel:{TranslatedNumber}"));
                    StartActivity(CallI);
                });
                CallDialog.SetNegativeButton("Cancelar", delegate { });
                CallDialog.Show();
            };


        }

    }
}

