using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Lab07
{
    [Activity(Label = "Lab07", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var btnvalidate = FindViewById<Button>(Resource.Id.btnValidate);


            btnvalidate.Click += (sender, e) => Btnvalidate_ClickAsync(sender, e);

        }

        private async System.Threading.Tasks.Task Btnvalidate_ClickAsync(object sender, EventArgs e)
        {
            if (Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {


                var editemail = FindViewById<EditText>(Resource.Id.editemail);
                var editpassword = FindViewById<EditText>(Resource.Id.editpass);

                var studentemail = string.Empty;
                var password = string.Empty;

                studentemail = (editemail.Text);
                password = (editpassword.Text);


                SALLab07.ServiceClient ServiceClient = new SALLab07.ServiceClient();
                string myDevice = Android.Provider.Settings.Secure.GetString(

                    ContentResolver,

                    Android.Provider.Settings.Secure.AndroidId

                    );
                var txtvalidate = FindViewById<TextView>(Resource.Id.txtresult);

                SALLab07.ResultInfo Result = await ServiceClient.ValidateAsync(studentemail, password, myDevice);


                var Builder = new Notification.Builder(this)
               .SetContentTitle("Validación de practica")
               .SetContentText($"{Result.Status}{Result.Fullname}{Result.Token}")
                                              .SetSmallIcon(Resource.Drawable.Icon);
                Builder.SetCategory(Notification.CategoryMessage);
                var ObjectNotification = Builder.Build();
                var Manager = GetSystemService(
                    Android.Content.Context.NotificationService) as NotificationManager;
                Manager.Notify(0, ObjectNotification);

            }
            else
            {




                var editemail = FindViewById<EditText>(Resource.Id.editemail);
                var editpassword = FindViewById<EditText>(Resource.Id.editpass);


                var studentemail = string.Empty;
                var password = string.Empty;

                studentemail = (editemail.Text);
                password = (editpassword.Text);

                SALLab07.ServiceClient ServiceClient = new SALLab07.ServiceClient();
                string myDevice = Android.Provider.Settings.Secure.GetString(

                    ContentResolver,

                    Android.Provider.Settings.Secure.AndroidId

                    );
                var txtvalidate = FindViewById<TextView>(Resource.Id.txtresult);

                SALLab07.ResultInfo Result = await ServiceClient.ValidateAsync(studentemail, password, myDevice);
                txtvalidate.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";

            }
        }
    }

}


