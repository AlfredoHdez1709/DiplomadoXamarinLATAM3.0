using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            validate();
            //llamarcompaertido();
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }

        public void llamarcompaertido()
        {
            var Helper = new SharedProject.MySharedCode();
            new AlertDialog.Builder(this)
                .SetMessage(Helper.GetFilePath("demo.dat"))
                .Show();
        }


        private async void validate()
        {
            var ServiceClient = new SALLab03.ServiceClient();
            string studentemail = "correo";
            string password = "password";
            string MyDevice = Android.Provider.Settings.Secure.GetString(
                ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);
            var Result = await ServiceClient.ValidateAsync(studentemail, password, MyDevice);
            Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
            AlertDialog Alert = Builder.Create();
            Alert.SetTitle("Resultado de la verificación");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetMessage(
                $"{Result.Status}\n{Result.Fullname}\n{Result.Token}");
            Alert.SetButton("OK", (s, ev) => { });
            Alert.Show();
        }

    }
}

