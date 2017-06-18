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
namespace Lab10
{
    [Activity(Label = "lab10")]
    public class ValidateActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Validate);
            var btnvalidate = FindViewById<Button>(Resource.Id.btnvalidateprueba);

            btnvalidate.Click += Btnvalidate_Click;

        }

        private async void Btnvalidate_Click(object sender, EventArgs e)
        {

            var editemail = FindViewById<EditText>(Resource.Id.editemail);
            var editpassword = FindViewById<EditText>(Resource.Id.editpassword);


            var studentemail = string.Empty;
            var password = string.Empty;

            studentemail = (editemail.Text);
            password = (editpassword.Text);

            SALLab10.ServiceClient ServiceClient = new SALLab10.ServiceClient();


            string myDevice = Android.Provider.Settings.Secure.GetString(

                ContentResolver,

                Android.Provider.Settings.Secure.AndroidId

                );

            SALLab10.ResultInfo Result = await ServiceClient.ValidateAsync(studentemail, password, myDevice);
            var txtvalidate = FindViewById<TextView>(Resource.Id.txtValidate);
            txtvalidate.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";
        }
    }
}
