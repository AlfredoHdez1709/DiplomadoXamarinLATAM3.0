using Android.App;
using Android.Widget;
using Android.OS;

namespace PhoneApp
{
    [Activity(Label = "Phone App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Validate();
            var PhoneNumber = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            var TranslateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            var CallButton = FindViewById<Button>(Resource.Id.CallButton);

            CallButton.Enabled = false;

            var TranslatedNumber = string.Empty;

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
                    var CallI = new Android.Content.Intent(Android.Content.Intent.ActionCall);
                    CallI.SetData(Android.Net.Uri.Parse($"tel:{TranslatedNumber}"));
                    StartActivity(CallI);
                });
                CallDialog.SetNegativeButton("Cancelar", delegate { });
                CallDialog.Show();
            };


        }


        private async void Validate()

        {

            SALLab05.ServiceClient ServiceClient = new SALLab05.ServiceClient();

            string studentemail = "correo";

            string password = "contraseña";

            string myDevice = Android.Provider.Settings.Secure.GetString(

                ContentResolver,

                Android.Provider.Settings.Secure.AndroidId

                );

            SALLab05.ResultInfo Result = await ServiceClient.ValidateAsync(studentemail, password, myDevice);
            TextView txtvalidate = FindViewById<TextView>(Resource.Id.txtValidate);

            txtvalidate.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";

            // $"{Result.Status}\n{Result.Fullname}\n{Result.Token}");
        }

    }
}

