using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab9
{
    [Activity(Label = "Lab9", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            validar();

        }



        public async void validar()
        {
            var txtname = FindViewById<TextView>(Resource.Id.txtUserName);
            var txtestatus = FindViewById<TextView>(Resource.Id.txtUserEstatus);
            var txtcodigo = FindViewById<TextView>(Resource.Id.txtUserCodi);

            var studentemail = "alfredo_hernandez_rguez@outlook.com";
            var password = "Al09her.ro17";

            SALLab09.ServiceClient ServiceClient = new SALLab09.ServiceClient();

            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver,

                    Android.Provider.Settings.Secure.AndroidId

                    );

            SALLab09.ResultInfo Result = await ServiceClient.ValidateAsync(studentemail, password, myDevice);

            txtname.Text = $"{Result.Fullname}";
            txtestatus.Text = $"{Result.Status}";
            txtcodigo.Text = $"{Result.Token}";



        }


    }
}

